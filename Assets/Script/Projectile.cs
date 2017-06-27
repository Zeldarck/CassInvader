using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    float m_speed;

    [SerializeField]
    float m_acceleration;

    static System.Random rnd = new System.Random();


    // Use this for initialization
    void Start () {
        double randomspeed = -1 * m_speed/2 + rnd.NextDouble() * (m_speed);
        GetComponent<Rigidbody>().velocity = new Vector3((float)randomspeed, m_speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
       // GetComponent<Rigidbody>().velocity *=  m_acceleration;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ILife life = collision.collider.gameObject.GetComponent<ILife>();
        if (life != null && life.GetDamage(1))
        {
            IScore score =  collision.collider.gameObject.GetComponent<IScore>();
            if (score != null)
            {
                GameController.AddScore(score.GetScore());
            }
        }
        GetComponent<Rigidbody>().velocity *= m_acceleration;


    }

}
