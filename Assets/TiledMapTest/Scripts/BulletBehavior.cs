using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
    public float lifeDuration = 2;

	// Use this for initialization
	void Start () {
	   Destroy(gameObject, lifeDuration);
	}

	// Update is called once per frame
	void Update () {

	}
}
