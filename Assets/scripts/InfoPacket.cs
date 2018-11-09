using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPacket : MonoBehaviour {

    public string[] FirstRead;
    public string[] SubsequentRead;
    public string ImportantText;

    public enum doodadType { Document, Key, Door };

    public doodadType myType;
    public bool hasBeenRead;

	// Use this for initialization
	void Start () {
        hasBeenRead = false;
	}
	
}
