using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] TestController controller;

    public void testClick()
    {
        controller.changeSpacebar();
    }
}
