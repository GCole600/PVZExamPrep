using System.Collections;
using Singleton;
using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPool
{
    public class ZombiePool : Singleton<ZombiePool>
    {
        public GameObject zombiePrefab;
        public Vector3[] spawnPosition;

        public int maxPoolSize = 20;
        public int stackDefaultCapacity = 20;
        
        private IObjectPool<Zombie> _pool;

        private IObjectPool<Zombie> Pool
        {
            get
            {
                if (_pool == null)
                    _pool = new ObjectPool<Zombie>(CreatedPooledItem, OnTakeFromPool, OnReturnedToPool, 
                        OnDestroyPoolObject, true, stackDefaultCapacity, maxPoolSize);
                return _pool;
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnLoop());
        }

        IEnumerator SpawnLoop()
        {
            while (true)
            {
                SpawnZombie();
                yield return new WaitForSeconds(GameManager.Instance.spawnRate);
            }
        }

        public void SpawnZombie()
        {
            var zombie = Pool.Get();
            
            // Get the zombie component and set its target position
            Zombie mover = zombie.GetComponent<Zombie>();
            
            mover.transform.position = spawnPosition[Random.Range(0, spawnPosition.Length)];
            
            if (mover != null)
                mover.SetTargetPosition();
        }
        
        // Callback implementation
        private Zombie CreatedPooledItem()
        {
            GameObject zombie = Instantiate(zombiePrefab, spawnPosition[Random.Range(0, spawnPosition.Length)], Quaternion.identity);

            Zombie mover = zombie.GetComponent<Zombie>();
            
            mover.Pool = Pool;
            
            return mover;
        }

        // Object gets deactivated and removed from scene
        private void OnReturnedToPool(Zombie zomb)
        {
            zomb.gameObject.SetActive(false);
        }

        // Requests an instance from the pool
        private void OnTakeFromPool(Zombie zomb)
        {
            zomb.gameObject.SetActive(true);
        }

        // Method called when there is no more space in the pool,
        // Destroying the returned instance to free memory
        private void OnDestroyPoolObject(Zombie zomb)
        {
            Destroy(zomb.gameObject);
        }
    }
}
