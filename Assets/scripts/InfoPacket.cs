using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum doodadType { Document, Key, Door };

public class InfoPacket{

    public string[] contents;
    public string ImportantText;

    public doodadType myType;

	// Use this for initialization
	public InfoPacket (string[] c, string i, doodadType type) {
        contents = c;
        ImportantText = i;
        myType = type;
	}
	
}
