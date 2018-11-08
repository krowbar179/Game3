﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float HMouseSpeed;
    public float VMouseSpeed;

    private float speed;
    private CharacterController Player;
    private float pitch;
    private float yaw;

    private bool locked;

	// Use this for initialization
	void Start () {
        HMouseSpeed = 10.0f;
        VMouseSpeed = 10.0f;
        speed = 7.0f;
        Player = GetComponent<CharacterController>();
        yaw = 0.0f;
        pitch = 0.0f;

        locked = true;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (locked)
        {
            yaw += HMouseSpeed * Input.GetAxis("Mouse X");
            pitch -= VMouseSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            if (Input.GetKey(KeyCode.W))
            {
                Player.SimpleMove(Vector3.Normalize(transform.forward) * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Player.SimpleMove(Vector3.Normalize(transform.forward) * -speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Player.SimpleMove(Vector3.Normalize(transform.right) * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player.SimpleMove(Vector3.Normalize(transform.right) * -speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (locked)
            {
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }
        }
    }
}
