using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace interact
{

    public interface InteractionHandler : IEventSystemHandler
    {
        void OnClick();
    }

}

public class Interactable : MonoBehaviour
{

    //This class literally exists only as a flag that an object has one of many possible InteractionHandle components
}
