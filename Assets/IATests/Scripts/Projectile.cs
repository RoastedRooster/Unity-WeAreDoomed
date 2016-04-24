using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileLifeDuration;
    public float projectileSpeed;
    public float projectileArrivalRadius;
    public Vector2 target;

    private float projectileDeathTime;

    void Start()
    {
        projectileDeathTime = Time.realtimeSinceStartup + projectileLifeDuration;
    }

    void Update()
    {
        if (Time.realtimeSinceStartup > projectileDeathTime)
            Destroy(gameObject);

        if (Vector2.Distance(gameObject.transform.position, target) < projectileArrivalRadius)
            Destroy(gameObject);

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, projectileSpeed * Time.deltaTime);
    }
}