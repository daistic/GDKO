using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComponentTogglesHandler : MonoBehaviour
{
    [SerializeField] List<Toggle> toggles = new List<Toggle>();

    private void Start()
    {
        toggles = UIManager.Instance.getAllToggles();
    }

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
