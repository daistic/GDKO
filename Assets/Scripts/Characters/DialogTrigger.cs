using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] GameObject dialogObject;
    [SerializeField] Dialog dialog;

    private void OnEnable()
    {
        dialog = dialogObject.GetComponent<Dialog>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("mak");

            if (GameManager.Instance.playerController.isSpacebarPressed)
            {
                Debug.Log("detectes");
            }

            if (!dialogObject.activeSelf && GameManager.Instance.playerController.isSpacebarPressed)
            {
                dialogObject.SetActive(true);
            }

            if (dialogObject.activeSelf && GameManager.Instance.playerController.isSpacebarPressed)
            {
                if (!dialog.isPlaying)
                {
                    if (dialog.isLastSentence())
                    {
                        dialogObject.SetActive(false);
                    }

                    else
                    {
                        dialog.playNextLine();
                    }
                }

                else
                {
                    dialog.FinishSentence();
                }
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(GameManager.Instance.dialogCoroutine);
            dialogObject.SetActive(false);
        }
    }
}
