using UnityEngine;
using System.Collections;

public class IAStaticShooter : MonoBehaviour {

    public float range;
    public float shootPeriod;
    public GameObject projectilePrefab;

    private GameObject _player;
    private float _nextShootTime;

	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
	    if(Vector2.Distance(_player.transform.position, gameObject.transform.position) < range)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            var now = Time.realtimeSinceStartup;
            if(now > _nextShootTime)
            {
                var newProj = GameObject.Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
                newProj.GetComponent<Projectile>().target = _player.transform.position;

                _nextShootTime = now + shootPeriod;
            }
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
	}
}
