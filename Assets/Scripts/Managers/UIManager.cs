using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    [Header("Canvases")]
    [SerializeField] GameObject componentsCanvas;

    [Header("Components Toggle")]
    [SerializeField] ComponentTogglesHandler componentsTogglesHandler;
    [SerializeField] Toggle moveRightComponent;
    [SerializeField] Toggle moveLeftComponent;
    [SerializeField] Toggle JumpComponent;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI memSlotText;
    [SerializeField] TextMeshProUGUI componentsExplanation;

    public void toggleComponentsMenu()
    {
        if (!componentsCanvas.activeSelf)
        {
            componentsCanvas.SetActive(true);
        } 
        
        else
        {
            componentsCanvas.SetActive(false);
        }
    }

    public void toggleMoveRight()
    {
        GameManager.Instance.playerController.handleMoveRight(moveRightComponent.isOn);
        handleMemSlot(moveRightComponent.isOn);
    }

    public void toggleMoveLeft()
    {
        GameManager.Instance.playerController.handleMoveLeft(moveLeftComponent.isOn);
        handleMemSlot(moveLeftComponent.isOn);
    }

    public void toggleJump()
    {
        GameManager.Instance.playerController.handleJump(JumpComponent.isOn);
        handleMemSlot(JumpComponent.isOn);
    }

    private void handleMemSlot(bool isToggleOn)
    {
        if (isToggleOn)
        {
            substractMemSlot();
        }

        else
        {
            incrementMemSlot();
        }
    }

    private void substractMemSlot()
    {

        if (GameManager.Instance.currentMemSlot > 0)
        {
            changeMemSlotText(--GameManager.Instance.currentMemSlot);
        }

        if (GameManager.Instance.currentMemSlot == 0)
        {
            componentsTogglesHandler.maxMemSlotReached();
        }
    }

    private void incrementMemSlot()
    {
        if (GameManager.Instance.currentMemSlot == 0)
        {
            componentsTogglesHandler.returnTogglesState();
        }

        if (GameManager.Instance.currentMemSlot < GameManager.Instance.maxMemSlot)
        {
            changeMemSlotText(++GameManager.Instance.currentMemSlot);
        }
    }

    private void changeMemSlotText(int memSlot)
    {
        memSlotText.text = "Mem Slot: " + memSlot.ToString();
    }

    public void changeComponentExplainText(string text)
    {
        componentsExplanation.text = text;
    }

    public void gotMoveLeftComponent()
    { 
        moveLeftComponent.gameObject.SetActive(true);
    }

    public void gotJumpComponent()
    {
        JumpComponent.gameObject.SetActive(true);
    }

    public void turnOnMoveRight()
    {
        moveRightComponent.isOn = true;
    }

    public List<Toggle> getAllToggles()
    {
        List<Toggle> toggles = new List<Toggle>();

        toggles.Add(moveRightComponent);
        toggles.Add(moveLeftComponent);
        toggles.Add(JumpComponent);

        return toggles;
    }
}
