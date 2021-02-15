using UnityEngine;
using Random = System.Random;

namespace Group_7.Breakout.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    { 
        private Rigidbody _rigidbody;
        [SerializeField] private float speed;
        
        private readonly Random _random = new Random();  

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            var manager = FindObjectOfType<GameManager>();
            if (other.gameObject.CompareTag("Brick"))
            {
                manager.CollideBrick(other);
            }
            else if (other.gameObject.CompareTag("Water"))
            {
                manager.CollideWater(other);
            }
        }

        private void Reset()
        {
            speed = 12;
        }

        private void Start()
        {
            _rigidbody.AddForce(new Vector3((float) (_random.NextDouble() * (0.5 + 0.5) + -0.5), -speed, 0), ForceMode.VelocityChange);
        }
    }
}
