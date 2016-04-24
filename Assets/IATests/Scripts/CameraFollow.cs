using UnityEngine;
using System.Collections;

namespace Parallax
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject player;
        private Vector3 initDelta;

        void Start()
        {
            initDelta = player.transform.position - gameObject.transform.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            var shift = player.transform.position - initDelta;
            shift.y = gameObject.transform.position.y;
            gameObject.transform.position = shift;

        }
    }
}
