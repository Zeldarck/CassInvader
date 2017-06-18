using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController INSTANCE;

    void Start () {
		if(INSTANCE != null && INSTANCE != this)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
