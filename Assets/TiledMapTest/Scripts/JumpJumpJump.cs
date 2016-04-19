using UnityEngine;
using System.Collections;

namespace ScreenShaking
{
    public class JumpJumpJump : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
    }
}
