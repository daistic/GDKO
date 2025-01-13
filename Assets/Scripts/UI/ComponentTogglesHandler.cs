using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComponentTogglesHandler : MonoBehaviour
{
    public List<Toggle> toggles = new List<Toggle>();

    public void maxMemSlotReached()
    {
        for (int i = 0; i < toggles.Count; i++)
        {
            if (!toggles[i].isOn)
            {
                toggles[i].interactable = false;
            }
        }
    }

    public void returnTogglesState()
    {
        for (int i = 0;i < toggles.Count; i++)
        {
            toggles[i].interactable = true;
        }
    }
}
