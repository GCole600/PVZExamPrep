using Singleton;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

namespace ObjectPool
{
    public class Zombie : MonoBehaviour
    {
        public IObjectPool<Zombie> Pool { get; set; }
        
        public Vector3 startPosition;
        private Vector3 _targetPosition;
        private float _lerpProgress;
        
        public float lerpTime = 10f;

        public void SetTargetPosition()
        {
            startPosition = transform.position;
            _targetPosition = startPosition + new Vector3(-48, 0, 0);
        }
        
        private void Update()
        {
            _lerpProgress += Time.deltaTime / lerpTime;
            
            transform.position = Vector3.Lerp(startPosition, _targetPosition, _lerpProgress);

            // Return to pool when it reaches the target position
            if (_lerpProgress >= 1f)
                GameManager.Instance.EndGame();
        }
        
        public void ReturnToPool()
        {
            Pool.Release(this);
        }
        
        private void OnDisable()
        {
            ResetPosition();
        }

        private void ResetPosition()
        {
            transform.position = startPosition;
            _lerpProgress = 0f;
        }
    }
}