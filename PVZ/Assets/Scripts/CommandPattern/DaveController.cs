using System;
using UnityEngine;

namespace CommandPattern
{
    public class DaveController : MonoBehaviour
    {
        public enum Direction
        {
            Up = -1,
            Down = 1
        }
        
        private float _distance = 3.0f;
        
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private float force;

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    if (transform.position.z < 12)
                        transform.Translate(Vector3.left * _distance);
                    break;
                case Direction.Down:
                    if (transform.position.z > 0)
                        transform.Translate(Vector3.right * _distance);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }

        public void Shoot()
        {
            GameObject obj = Instantiate(bulletPrefab, shootingPoint.transform.position, bulletPrefab.transform.rotation);

            Rigidbody projectileRb = obj.GetComponent<Rigidbody>();
            projectileRb.AddForce(force * Vector3.right, ForceMode.Impulse);
        }
    }
}
