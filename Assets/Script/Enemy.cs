using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private static int _MIN_X = -12;
	private static int _MAX_X = 12;
	private static int _MIN_Y = 0;
	private static int _MAX_Y = 19;

	[SerializeField]
	private float _enemySpeed = 6;

	private Rigidbody _enemyRB;

	private bool _descending;
	private float _direction;
	private Vector2 _lastBorderPosition;


	// Use this for initialization
	void Start () {
		_enemyRB = gameObject.GetComponent<Rigidbody>();

		gameObject.transform.position = new Vector3(_MIN_X , _MAX_Y , 0);
		_lastBorderPosition = new Vector2(_MIN_X, _MAX_Y);
		_direction = 1;
		_descending = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// check position and determine where to go next
		if (_descending) {
			if (gameObject.transform.position.y <= (_lastBorderPosition.y - 1)) {
				_lastBorderPosition.y -= 1;
				Vector3 tmpPos = gameObject.transform.position;
				tmpPos.y = _lastBorderPosition.y;
				gameObject.transform.position = tmpPos;
				_direction *= -1;
				_descending = false;
			}
		} else {
			if(gameObject.transform.position.x >= _MAX_X && _direction >= 0 ){
				Vector3 tmpPos = gameObject.transform.position;
				tmpPos.x = _MAX_X;
				gameObject.transform.position = tmpPos;
				_descending = true;
			}
			if(gameObject.transform.position.x <= _MIN_X && _direction <= 0 ){
				Vector3 tmpPos = gameObject.transform.position;
				tmpPos.x = _MIN_X;
				gameObject.transform.position = tmpPos;
				_descending = true;
			}
		}

		// move accordingly
		Vector3 directionToGo = new Vector3(0,0,0);
		if (_descending) {
			directionToGo.y = -1 * _enemySpeed;
		} else {
			directionToGo.x = _direction * _enemySpeed;
		}

		_enemyRB.velocity = directionToGo;
	}

	public void SetDirection(float dir){
		_direction = dir;
	}


	// Destroy an ennemy when it collides with a projectile
	public void Destroy(){

	}

}
