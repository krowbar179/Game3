using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using interact;

public class PlayerController : MonoBehaviour {

    public float HMouseSpeed;
    public float VMouseSpeed;

    private enum State { Roam, Read, Inventory};
    private State state;

    private GameObject UI;
    private GameObject cursor;

    private float speed;
    private CharacterController Player;
    private float pitch;
    private float yaw;

	// Use this for initialization
	void Start () {
        HMouseSpeed = 10.0f;
        VMouseSpeed = 10.0f;
        speed = 7.0f;
        Player = GetComponent<CharacterController>();
        yaw = 0.0f;
        pitch = 0.0f;

        state = State.Roam;

        Cursor.lockState = CursorLockMode.Locked;

        UI = GameObject.Find("/Canvas");
        cursor = GameObject.Find("/Canvas/Cursor");
	}

    void ChangeState()
    {
        if(state == State.Roam)
        {
            ExecuteEvents.Execute<InteractionHandler>(cursor, null, (x, y) => x.Trigger());
            Cursor.lockState = CursorLockMode.None;
            state = State.Inventory;
        }
        else if(state == State.Read)
        {
            ExecuteEvents.Execute<InteractionHandler>(cursor, null, (x, y) => x.Trigger());
            Cursor.lockState = CursorLockMode.Locked;
            state = State.Roam;
        }
        else if(state == State.Inventory)
        {
            ExecuteEvents.Execute<InteractionHandler>(cursor, null, (x, y) => x.Trigger());
            Cursor.lockState = CursorLockMode.Locked;
            state = State.Roam;

        }
    }
	
	// Update is called once per frame
	void Update () {
        if (state == State.Roam)
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

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = new Ray(transform.position, transform.forward);
                if(Physics.Raycast(ray, out hit, 5.0f))
                {
                    GameObject obj = hit.transform.gameObject;
                    if (obj.GetComponent<Interactable>())
                    {
                        ExecuteEvents.Execute<InteractionHandler>(obj, null, (x, y) => x.Trigger());
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeState();
        }
    }
}
