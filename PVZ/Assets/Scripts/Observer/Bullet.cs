using System;
using ObjectPool;
using Singleton;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Observer
{
    public class Bullet : Subject
    {
        private void OnEnable()
        {
            AddObserver(FindObjectOfType<UiManager>());
        }
        
        private void OnDisable()
        {
            RemoveObserver(FindObjectOfType<UiManager>());
        }

        private void Start()
        {
            Destroy(gameObject, 3);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sunflower"))
            {
                other.GetComponent<Zombie>().ReturnToPool();
                GameManager.Instance.sun += 25;

                if (Random.Range(0, 2) == 1)
                    ZombiePool.Instance.SpawnZombie();
                
                NotifyObservers();
            }
        }
    }
}