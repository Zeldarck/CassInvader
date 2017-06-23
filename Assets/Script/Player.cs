using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}


public class Player : MonoBehaviour {

    [SerializeField]
    float m_speed = 1f;
    [SerializeField]
    Boundary boundary;

    [SerializeField]
    Slider m_chargeur;
    [SerializeField]
    float m_timeRecharge;

    [SerializeField]
    GameObject m_shot;

    [SerializeField]
    Transform m_spawn;

    float m_time = 0;


    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - m_time > m_timeRecharge)
        {
            m_chargeur.value++;
            m_time = Time.time;
        }

        if ((Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space)) && m_chargeur.value == m_chargeur.maxValue)
        {
            Instantiate(m_shot, m_spawn.position, transform.rotation);
            m_chargeur.value = m_chargeur.minValue;
        }

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            GetComponent<Rigidbody>().position.y, 0.0f
        );


    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * m_speed;


    }
}
