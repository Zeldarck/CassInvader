using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathController : MonoBehaviour {

	[SerializeField]
	public Vector2 _nextDirection;

	private SphereCollider _collider;


	// Use this for initialization
	void Start () {
		_collider = gameObject.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ())
			other.gameObject.GetComponent<Enemy> ();
	}
}
