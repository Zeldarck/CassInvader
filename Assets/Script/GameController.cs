using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController INSTANCE;

	private float _timeBetweenSpawn = 2;
	private float _lastSpawnTime;

	private float _timeBetweenLevel = 90;
	private float _lastLevelTime;

	private int _nbEnemyPerLevel;
	private int _nbEnemyToSpawn;


	[SerializeField]
	private GameObject _enemy1;


    void Start () {
		if(INSTANCE != null && INSTANCE != this)
        {
			Destroy(this);
        }
        else
        {
			INSTANCE = this;
        }

		// wait 5 sec before spawning begin
		_lastSpawnTime = 3;
		_nbEnemyPerLevel = 10;
		_nbEnemyToSpawn = _nbEnemyPerLevel;

		_lastLevelTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= (_lastSpawnTime + _timeBetweenSpawn) && _nbEnemyToSpawn > 0){
			Instantiate(_enemy1);
			_lastSpawnTime = Time.time;
			_nbEnemyToSpawn--;
		}

		if(Time.time >= (_lastLevelTime + _timeBetweenLevel)){
			_nbEnemyToSpawn = _nbEnemyPerLevel;
		}
	}


}
