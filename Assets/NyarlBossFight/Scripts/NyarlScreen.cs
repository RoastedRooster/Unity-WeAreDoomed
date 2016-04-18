using UnityEngine;
using System.Collections;

public class NyarlScreen : MonoBehaviour {

    public Material defaultMaterial;
    public Material chargingMaterial;
    public float damageWindowAfterShot = 1;
    public GameObject projectile;

    private GameObject _player;
    private float _lastShot;
    private bool _charging = false;

	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        // Always face the player
        gameObject.transform.LookAt(_player.transform);

        if(Time.realtimeSinceStartup > _lastShot + damageWindowAfterShot && !_charging)
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    public void Charge()
    {
        gameObject.GetComponent<MeshRenderer>().material = chargingMaterial;
        _charging = true;
    }

    public void Shoot()
    {
        GameObject proj = GameObject.Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        proj.transform.Rotate(90, 0, 0);
        var pos = _player.transform.position;
        proj.GetComponent<NyarlProjectile>().SetTarget(pos);

        _lastShot = Time.realtimeSinceStartup;
        _charging = false;
    }
}
