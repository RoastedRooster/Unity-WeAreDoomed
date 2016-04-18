using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Nyarl : MonoBehaviour {

    public List<GameObject> screens;
    public float attackPeriod;
    public float chargeDuration;
    public int screensByAttack;

    private float               _nextCharge;
    private float               _nextShot;
    private float               _currentTime;
    private bool                _charging;
    private Random              _rng;
    private List<GameObject>    _shootingScreens;

    void Start()
    {
        _rng = new Random();
        _nextCharge = Time.realtimeSinceStartup + attackPeriod / 2;
    }

	void Update () {
        _currentTime = Time.realtimeSinceStartup;

        if(_currentTime > _nextShot && _charging)
        {
            foreach (var screen in _shootingScreens)
            {
                screen.GetComponent<NyarlScreen>().Shoot();
            }
            _shootingScreens.Clear();

            _nextCharge = _currentTime + attackPeriod;
            _charging = false;
        }
        else if(_currentTime > _nextCharge && !_charging)
        {
            // select the shooting screens
            _shootingScreens = pickN(screensByAttack, screens);
            foreach(var screen in _shootingScreens)
            {
                screen.GetComponent<NyarlScreen>().Charge();
            }

            // program the firing
            _nextShot = _currentTime + chargeDuration;
            _charging = true;
        }

	}

    private List<GameObject> pickN(int n, List<GameObject> values)
    {
        var temp = new List<GameObject>(values);
        var result = new List<GameObject>();
        int index;
        for(int i = 0; i < n; i++)
        {
            index = Random.Range(0, temp.Count);
            result.Add(temp[index]);
            temp.Remove(temp[index]);

            if (temp.Count == 0)
                break;
        }

        return result;
    }
}
