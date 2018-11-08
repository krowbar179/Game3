using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using cakeslice;

public class MouseoverToggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Outline outline;
	// Use this for initialization
	void Start () {
        outline = GetComponent<Outline>();
        outline.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData pData)
    {
        if (!(outline.enabled))
        {
            outline.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData pData)
    {
        if (outline.enabled)
        {
            outline.enabled = false;
        }
    }
}
