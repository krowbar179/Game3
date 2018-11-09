using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using interact;

public class Readable : MonoBehaviour, InteractionHandler {

    
    public bool hasBeenRead;
    public string[] FirstRead;
    public string[] SubsequentRead;
    public string ImportantText;
    public doodadType myType;
	// Use this for initialization
	void Start () {
        hasBeenRead = false;
	}

    public void Trigger(GameObject player)
    {
        if (!hasBeenRead) {
            ExecuteEvents.Execute<ReactionHandler>(player, null, (x, y) => x.Process(new InfoPacket(FirstRead, ImportantText, myType)));
            hasBeenRead = true;
        }
        else
        {
            ExecuteEvents.Execute<ReactionHandler>(player, null, (x, y) => x.Process(new InfoPacket(SubsequentRead, ImportantText, myType)));
        }
    }
}
