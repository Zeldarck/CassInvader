using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour {

	[SerializeField]
	private float enemySpeed = 1;

	private Rigidbody _enemyRB;
	private Vector2 _direction;

	// Use this for initialization
	void Start () {
		_enemyRB = gameObject.GetComponent<Rigidbody>();

		_direction = new Vector2(1,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionToGo = new Vector3(0,0,0);
		directionToGo.x = _direction.x * enemySpeed;
		directionToGo.y = _direction.y * enemySpeed;

		_enemyRB.velocity = directionToGo;
	}

	public void SetDirection(Vector2 dir){
		_direction = dir;
	}


	// Destroy an ennemy when it collides with a projectile
	public void Destroy(){

	}
}
