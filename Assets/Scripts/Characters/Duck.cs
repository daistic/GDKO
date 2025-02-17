using UnityEngine;

public class Duck : MonoBehaviour
{
    [Header("Duck Stuffs")]
    [SerializeField] GameObject dialogObject;
    DuckDialog dialog;
    [SerializeField] GameObject dialogTriggerObject;
    DuckDialoogTrigger dialogTrigger;
    [SerializeField] int duckHealth;

    [Header("Dialog Scipts")]
    [SerializeField] duckDialog defaulter;
    [SerializeField] duckDialog repeater;
    [SerializeField] duckDialog[] shotResponse;

    [SerializeField] GameObject relic;

    private void Start()
    {
        dialog = dialogObject.GetComponent<DuckDialog>();
        dialogTrigger = dialogTriggerObject.GetComponent<DuckDialoogTrigger>();
    }


    public void changeToReapeat()
    {
        Debug.Log(repeater);
        dialog.dialogScript = repeater;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hehhe");
        duckHealth--;
        ChangeEvent();
    }

    private void ChangeEvent()
    {
        if (duckHealth == 4)
        {
            dialogShotResponse(0);

            if (dialogTrigger.speechBubble != null) dialogTrigger.speechBubble.SetActive(true);
            dialogObject.SetActive(true);

            dialogTrigger.dialogEvent.RemoveAllListeners();
        }

        else if (duckHealth == 3)
        {
            dialogShotResponse(1);

            if (dialogTrigger.speechBubble != null) dialogTrigger.speechBubble.SetActive(true);
            dialogObject.SetActive(true);

            dialogTrigger.dialogEvent.RemoveAllListeners();
        }

        else if (duckHealth == 2)
        {
            dialogShotResponse(2);

            if (dialogTrigger.speechBubble != null) dialogTrigger.speechBubble.SetActive(true);
            dialogObject.SetActive(true);

            dialogTrigger.dialogEvent.RemoveAllListeners();
        }

        else if (duckHealth == 1)
        {
            dialogShotResponse(3);

            if (dialogTrigger.speechBubble != null) dialogTrigger.speechBubble.SetActive(true);
            dialogObject.SetActive(true);

            dialogTrigger.dialogEvent.RemoveAllListeners();

            relic.SetActive(true);
        }
    }

    public void dialogShotResponse(int index)
    {
        dialog.enabled = false;
        dialog.dialogScript = shotResponse[index];
        dialog.enabled = true;
    }
}