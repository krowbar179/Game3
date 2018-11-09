using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using interact;
using visible;
public interface ReactionHandler : IEventSystemHandler
{
    void Process(InfoPacket packet);
}

public class PlayerController : MonoBehaviour, ReactionHandler {

    public float HMouseSpeed;
    public float VMouseSpeed;

    private enum State { Roam, Read, Inventory};
    private State state;

    private GameObject UI;
    private GameObject cursor;
    private GameObject textBox;
    private GameObject text;

    private float speed;
    private CharacterController Player;
    private float pitch;
    private float yaw;

    private InfoPacket myPacket;
    private int packetPage;

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
        textBox = GameObject.Find("/Canvas/Text Box");
        text = GameObject.Find("/Canvas/Text Box/Text");

        myPacket = null;
	}

    public void Process(InfoPacket packet)
    {
        myPacket = packet;
        packetPage = 0;
        text.GetComponent<Text>().text = myPacket.contents[packetPage];
        ChangeState(true);
    }

    void stashPacket()
    {
        myPacket = null;
    }

    void ChangeState(bool ReceivedPacket)
    {
        if(state == State.Roam)
        {
            if (ReceivedPacket)
            {
                state = State.Read;
            }
            else
            {
                state = State.Inventory;
            }
            ExecuteEvents.Execute<VisibilityHandler>(cursor, null, (x, y) => x.Visible());
            ExecuteEvents.Execute<VisibilityHandler>(textBox, null, (x, y) => x.Visible());
            ExecuteEvents.Execute<VisibilityHandler>(text, null, (x, y) => x.Visible());
            Cursor.lockState = CursorLockMode.None;
        }
        else if(state == State.Read)
        {
            stashPacket();
            ExecuteEvents.Execute<VisibilityHandler>(cursor, null, (x, y) => x.Visible());
            ExecuteEvents.Execute<VisibilityHandler>(textBox, null, (x, y) => x.Visible());
            ExecuteEvents.Execute<VisibilityHandler>(text, null, (x, y) => x.Visible());
            Cursor.lockState = CursorLockMode.Locked;
            state = State.Roam;
        }
        else if(state == State.Inventory)
        {
            ExecuteEvents.Execute<VisibilityHandler>(cursor, null, (x, y) => x.Visible());
            ExecuteEvents.Execute<VisibilityHandler>(textBox, null, (x, y) => x.Visible());
            ExecuteEvents.Execute<VisibilityHandler>(text, null, (x, y) => x.Visible());
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
                        ExecuteEvents.Execute<InteractionHandler>(obj, null, (x, y) => x.Trigger(this.transform.gameObject));
                    }
                }
            }
        }

        if(state == State.Read)
        {
            if (Input.GetMouseButtonDown(0))
            {
                packetPage++;
                if(packetPage < myPacket.contents.Length)
                {
                    text.GetComponent<Text>().text = myPacket.contents[packetPage];
                }
                else
                {
                    ChangeState(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeState(false);
        }
    }
}
