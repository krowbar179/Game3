using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface InteractionHandler : IEventSystemHandler
{
    void OnClick();
}

public class Interactable : MonoBehaviour, InteractionHandler
{
    private Rigidbody body;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        body.AddForce(new Vector3(0, 10, 0), ForceMode.VelocityChange);
    }
}
