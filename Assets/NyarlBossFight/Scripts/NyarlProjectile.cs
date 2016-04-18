using UnityEngine;
using System.Collections;

public class NyarlProjectile : MonoBehaviour {

    private Vector3 _target = Vector3.zero;
    public float projectileSpeed = 3;

	void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Vector3 target)
    {
        GetComponent<Rigidbody2D>().AddForce((target - gameObject.transform.position).normalized * projectileSpeed, ForceMode2D.Force);
    }

}
