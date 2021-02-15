using UnityEngine;

namespace Group_7.Breakout.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Paddle : MonoBehaviour
    {
        private Rigidbody _rigidBody;
        [SerializeField] private float left, right, speed;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.isKinematic = true;
            _rigidBody.useGravity = false;
        }

        private void Reset()
        {
            left = -3;
            right = 3;
            speed = 12;
        }

        private void Update()
        {
            if (Input.GetKey("left"))
            {
                var nextLeft = Vector3.left * (speed * Time.deltaTime);
                if ((transform.position + nextLeft).x < left) return;
                transform.position += nextLeft;
            }
            else if (Input.GetKey("right"))
            {
                var nextRight = Vector3.right * (speed * Time.deltaTime);
                if ((transform.position + nextRight).x > right) return;
                transform.position += nextRight;
            }
        }
    }
}
