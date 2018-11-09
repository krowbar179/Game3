using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using interact;

public class Readable : MonoBehaviour, InteractionHandler {

    InfoPacket packet;

	// Use this for initialization
	void Start () {
        packet = GetComponent<InfoPacket>();
	}

    public void Trigger(GameObject player)
    {
        ExecuteEvents.Execute<ReactionHandler>(player, null, (x, y) => x.Process(packet));
    }
}
