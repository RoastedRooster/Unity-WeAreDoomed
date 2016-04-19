using UnityEngine;
using System.Collections;

namespace Parallax
{
    public class PlayerController : MonoBehaviour
    {

        public int speed = 10;
        public int jumpVelocity = 5;

        void Update()
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            if(Input.GetKeyDown(KeyCode.Space))
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }
    }
}


