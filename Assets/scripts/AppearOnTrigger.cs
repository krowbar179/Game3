using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using interact;

public class AppearOnTrigger : MonoBehaviour, InteractionHandler
{

    private Image image;
    private Text text;
    private Color originalColor;
    public bool clear;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        if (image)
        {
            originalColor = image.color;
            if (clear)
            {
                image.color = Color.clear;
            }
        }
        text = GetComponent<Text>();
        if (text)
        {
            originalColor = text.color;
            if (clear)
            {
                text.color = Color.clear;
            }
        }
        
        List<GameObject> childList = new List<GameObject>();
        Transform[] children = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < children.Length; i++)
        {
            Transform child = children[i];
            if (child != transform)
            {
                childList.Add(child.gameObject);
            }
        }
        for (int i = 0; i < childList.Count; i++)
        {
            AppearOnTrigger AOT = childList[i].AddComponent<AppearOnTrigger>();
            AOT.clear = clear;
        }
        

    }

    public void Trigger()
    {
        if (clear)
        {
            if (image)
            {
                image.color = originalColor;
            }
            if(text)
            {
                text.color = originalColor;
            }
            clear = false;
        }
        else
        {
            if (image)
            {
                image.color = Color.clear;
            }
            if (text)
            {
                text.color = Color.clear;
            }
            clear = true;
        }
    }

}
