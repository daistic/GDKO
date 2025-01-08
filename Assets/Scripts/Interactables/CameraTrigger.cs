using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] CinemachineCamera defaultCamera;
    [SerializeField] CinemachineCamera newCamera;  

    CinemachineBrain brain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            brain = Camera.main.GetComponent<CinemachineBrain>();
            CinemachineCamera currentCamera = brain.ActiveVirtualCamera as CinemachineCamera;

            if (currentCamera == defaultCamera)
            {
                newCamera.Prioritize();
            }

            else
            {
                defaultCamera.Prioritize();
            }
        }
    }
}
