using UnityEngine;
using System.Collections;

public class IARusher : MonoBehaviour {

    public float rangeAttack;
    public float speed;
    public float rangeAcquisition;
    public float shootPeriod;

    private GameObject _player;
    private float _nextShootTime;
    private bool _chasing = false;
    private Vector3 _origin;
    private bool _init = true;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        var playerPos = _player.transform.position;
        var currentPos = gameObject.transform.position;

        if(_chasing)
        {
            if(Vector2.Distance(playerPos, currentPos) < rangeAttack)
            {
                GetComponent<MeshRenderer>().material.color = Color.red;
                var now = Time.realtimeSinceStartup;
                if (now > _nextShootTime)
                {
                    Debug.Log("CLING!");
                    _nextShootTime = now + shootPeriod;
                }
            }
            else if (Vector2.Distance(playerPos, currentPos) < rangeAcquisition * 1.5) // once chasing the player, remember where he is for a while
            {
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                gameObject.transform.position = Vector2.MoveTowards(currentPos, playerPos, Time.deltaTime * speed);
            }
            else
            {
                _chasing = false;
                GetComponent<MeshRenderer>().material.color = Color.white;
                if(Vector2.Distance(currentPos, _origin) > 1)
                    gameObject.transform.position = Vector2.MoveTowards(currentPos, _origin, Time.deltaTime * speed);
            }
        }
        else
        {
            if(Vector2.Distance(playerPos, currentPos) < rangeAcquisition)
            {
                _init = false;
                _origin = currentPos;
                _chasing = true;
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                gameObject.transform.position = Vector2.MoveTowards(currentPos, playerPos, Time.deltaTime * speed);
            }
            else
            {
                if(!_init)
                {
                    _chasing = false;
                    GetComponent<MeshRenderer>().material.color = Color.white;
                    if (Vector2.Distance(currentPos, _origin) > 1)
                        gameObject.transform.position = Vector2.MoveTowards(currentPos, _origin, Time.deltaTime * speed);
                }
            }
        }
    }
}
