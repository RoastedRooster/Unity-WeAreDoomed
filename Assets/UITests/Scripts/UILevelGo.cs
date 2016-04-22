using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILevelGo : MonoBehaviour {

    public GameObject canvas;

    public void FixedUpdate()
    {
        if (Input.anyKeyDown || AxisMoved())
        {
            canvas.GetComponent<Animator>().Play("End");
            gameObject.SetActive(false);
        }
            
    }

    private bool AxisMoved()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.7 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.7)
            return true;

        return false;
    }
}
