using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] Toggle sidewaysComponent;
    [SerializeField] Toggle moveRightComponent;
    [SerializeField] Toggle moveLeftComponent;
    [SerializeField] Toggle JumpComponent;
    [SerializeField] Toggle swordComponent;
    [SerializeField] Toggle shootComponent;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI memSlotText;
    [SerializeField] TextMeshProUGUI componentsExplanation;

    private void Start()
    {
        componentsTogglesHandler.startCheck();
    }

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

    public void toggleMoveSideways()
    {
        GameManager.Instance.playerController.handleMoveSideways(sidewaysComponent.isOn);
        handleMemSlot(sidewaysComponent.isOn);
    }

    public void toggleJump()
    {
        GameManager.Instance.playerController.handleJump(JumpComponent.isOn);
        handleMemSlot(JumpComponent.isOn);
    }

    public void toggleSword()
    {
        GameManager.Instance.playerController.handleSword(swordComponent.isOn);
        handleMemSlot(swordComponent.isOn);
    }

    public void toggleShoot()
    {
        GameManager.Instance.playerController.handleShoot(shootComponent.isOn);
        handleMemSlot(shootComponent.isOn);
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

            if (GameManager.Instance.currentMemSlot <= 0)
            {
                componentsTogglesHandler.maxMemSlotReached();
            }
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
        componentsTogglesHandler.toggles.Add(moveLeftComponent);
        checkMemSlot(moveLeftComponent);
    }

    public void gotJumpComponent()
    {
        JumpComponent.gameObject.SetActive(true);
        componentsTogglesHandler.toggles.Add(JumpComponent);
        checkMemSlot(JumpComponent);
    }

    public void gotSwordComponent()
    {
        swordComponent.gameObject.SetActive(true);
        componentsTogglesHandler.toggles.Add(swordComponent);
        checkMemSlot(swordComponent);
    }


    private void checkMemSlot(Toggle componentToggle)
    {
        if (GameManager.Instance.currentMemSlot == 0)
        {
            componentToggle.interactable = false;
        }
    }

    public void grantedMoveRight()
    {
        moveRightComponent.gameObject.SetActive(true);
        componentsTogglesHandler.toggles.Add(moveRightComponent);
        moveRightComponent.isOn = true;
        checkMemSlot(moveRightComponent);
    }

    public void grantedShoot()
    {
        shootComponent.gameObject.SetActive(true);
        componentsTogglesHandler.toggles.Add(shootComponent);
    }

    public void upgradeToMoveSideways()
    {
        moveRightComponent.isOn = false;
        moveRightComponent.gameObject.SetActive(false);
        componentsTogglesHandler.toggles.Remove(moveRightComponent);

        moveLeftComponent.isOn = false;
        moveLeftComponent.gameObject.SetActive(false);
        componentsTogglesHandler.toggles.Remove(moveLeftComponent);

        sidewaysComponent.gameObject.SetActive(true);
        componentsTogglesHandler.toggles.Add(sidewaysComponent);
        checkMemSlot(sidewaysComponent);
    }
}
