using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interact;

public class Readable : MonoBehaviour, InteractionHandler {

    string readtext;
    string copytext;
    bool hasBeenRead;

	// Use this for initialization
	void Start () {
        hasBeenRead = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {

    }
}
