using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] CinemachineCamera newCamera;

    CinemachineCamera defaultCamera;
    CinemachineBrain brain;

    private void Start()
    {
        defaultCamera = GameManager.Instance.defaultCamera;
    }

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
