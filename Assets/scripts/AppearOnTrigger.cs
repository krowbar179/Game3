using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using interact;
using visible;

namespace visible
{
    public interface VisibilityHandler : IEventSystemHandler
    {
        void Visible();
    }
}

public class AppearOnTrigger : MonoBehaviour, VisibilityHandler
{

    private Image image;
    private Text text;
    private Color originalColor;
    private Color clearColor;
    private List<GameObject> childList;
    private Transform[] children;

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
            originalColor.a = 1;
            clearColor = originalColor;
            clearColor.a = 0;
            if (clear)
            {
                text.color = clearColor;
            }
        }
        /*
        childList = new List<GameObject>();
        children = GetComponentsInChildren<Transform>(true);
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
        */

    }

    public void Visible()
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
                text.color = clearColor;
            }
            clear = true;
        }
        /*
        for (int i = 0; i < childList.Count; i++)
        {
            childList[i].GetComponent<AppearOnTrigger>().clear = clear;
            //ExecuteEvents.Execute<InteractionHandler>(this.gameObject, null, (x, y) => x.Trigger(null));
        }
        */
    }

}
