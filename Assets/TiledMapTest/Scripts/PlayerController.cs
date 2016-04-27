using UnityEngine;
using System.Collections;

namespace Parallax
{
    public class PlayerController : MonoBehaviour
    {

        public float speed = 10;
        public float maxSpeed = 5f;
        public float moveForce = 365f;
        public int jumpVelocity = 5;

        private Rigidbody2D rb2d;

        void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            /*
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            */

            if(Input.GetKeyDown(KeyCode.Space))
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }

        void FixedUpdate() {
            float h = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(h *maxSpeed,rb2d.velocity.y);
        }
    }
}


