using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnClick : MonoBehaviour {

    private Rigidbody body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            body.AddForce(new Vector3(0, 10, 10), ForceMode.VelocityChange);
        }
		
	}
}
