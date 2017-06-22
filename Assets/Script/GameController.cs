using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController INSTANCE;


    void Start () {
		if(INSTANCE != null && INSTANCE != this)
        {
			Destroy(this);
        }
        else
        {
			INSTANCE = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
	}


}
