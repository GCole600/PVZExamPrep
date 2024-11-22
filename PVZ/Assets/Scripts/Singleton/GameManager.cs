using System.Collections;
using UnityEngine;

namespace Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject loseScreen;
        
        public bool changeRate = true;
        public float spawnRate = 10;
        public int sun; 

        private void Start()
        {
            StartCoroutine(IncreaseSpawnRate());
        }

        private IEnumerator IncreaseSpawnRate()
        {
            while (changeRate)
            {
                yield return new WaitForSeconds(2);
                spawnRate -= 0.1f;

                if (spawnRate == 0.1f)
                    changeRate = false;
            }
        }

        public void EndGame()
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
