using UnityEngine;
using UnityEngine.UI;

public class TestToggle : MonoBehaviour
{
    [SerializeField] ToggleGroup toggleGroup;

    private void OnEnable()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }


}
