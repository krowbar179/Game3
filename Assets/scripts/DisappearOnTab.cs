using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisappearOnTab : MonoBehaviour {

    public Image image;
    public Color originalColor;
    public bool clear;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        originalColor = image.color;
        clear = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (clear)
            {
                image.color = originalColor;
                clear = false;
            }
            else
            {
                image.color = Color.clear;
                clear = true;
            }
        }

	}
}
