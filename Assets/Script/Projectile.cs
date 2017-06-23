using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    float m_speed;

    [SerializeField]
    float m_acceleration;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, m_speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity *=  m_acceleration;
    }
}
