//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/Input Actions/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2b80ceaa-2059-4ac3-8c34-3259f803a9d6"",
            ""actions"": [
                {
                    ""name"": ""Dbutton"",
                    ""type"": ""Button"",
                    ""id"": ""2103007a-2db1-4705-a1d3-79b4da8a61fd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AButton"",
                    ""type"": ""Button"",
                    ""id"": ""2ecd1552-b42c-4c7c-beae-a20aca2ae5c6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WButton"",
                    ""type"": ""Button"",
                    ""id"": ""a77d3856-22fa-43c8-b232-f8bec1f72886"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SButton"",
                    ""type"": ""Button"",
                    ""id"": ""06e23270-1b0b-41d6-b42a-acbda80e8adb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpaceButton"",
                    ""type"": ""Button"",
                    ""id"": ""6c9ccd32-9a37-44c3-b786-e2c1a60527d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""14523f19-b563-4040-90fb-472367e4ab78"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dbutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f66ee96b-f5c5-4a74-adc0-0725d75c90b0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aeb5ace-172a-446f-b220-e0ab81adfccd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb8e2ddf-9c74-4439-a57d-8b0c33b04bf8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd8d57d3-7f37-49fd-9d0c-9d688c9f986f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpaceButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Dbutton = m_Player.FindAction("Dbutton", throwIfNotFound: true);
        m_Player_AButton = m_Player.FindAction("AButton", throwIfNotFound: true);
        m_Player_WButton = m_Player.FindAction("WButton", throwIfNotFound: true);
        m_Player_SButton = m_Player.FindAction("SButton", throwIfNotFound: true);
        m_Player_SpaceButton = m_Player.FindAction("SpaceButton", throwIfNotFound: true);
    }

    ~@PlayerInput()
    {
        UnityEngine.Debug.Assert(!m_Player.enabled, "This will cause a leak and performance issues, PlayerInput.Player.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Dbutton;
    private readonly InputAction m_Player_AButton;
    private readonly InputAction m_Player_WButton;
    private readonly InputAction m_Player_SButton;
    private readonly InputAction m_Player_SpaceButton;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dbutton => m_Wrapper.m_Player_Dbutton;
        public InputAction @AButton => m_Wrapper.m_Player_AButton;
        public InputAction @WButton => m_Wrapper.m_Player_WButton;
        public InputAction @SButton => m_Wrapper.m_Player_SButton;
        public InputAction @SpaceButton => m_Wrapper.m_Player_SpaceButton;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Dbutton.started += instance.OnDbutton;
            @Dbutton.performed += instance.OnDbutton;
            @Dbutton.canceled += instance.OnDbutton;
            @AButton.started += instance.OnAButton;
            @AButton.performed += instance.OnAButton;
            @AButton.canceled += instance.OnAButton;
            @WButton.started += instance.OnWButton;
            @WButton.performed += instance.OnWButton;
            @WButton.canceled += instance.OnWButton;
            @SButton.started += instance.OnSButton;
            @SButton.performed += instance.OnSButton;
            @SButton.canceled += instance.OnSButton;
            @SpaceButton.started += instance.OnSpaceButton;
            @SpaceButton.performed += instance.OnSpaceButton;
            @SpaceButton.canceled += instance.OnSpaceButton;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Dbutton.started -= instance.OnDbutton;
            @Dbutton.performed -= instance.OnDbutton;
            @Dbutton.canceled -= instance.OnDbutton;
            @AButton.started -= instance.OnAButton;
            @AButton.performed -= instance.OnAButton;
            @AButton.canceled -= instance.OnAButton;
            @WButton.started -= instance.OnWButton;
            @WButton.performed -= instance.OnWButton;
            @WButton.canceled -= instance.OnWButton;
            @SButton.started -= instance.OnSButton;
            @SButton.performed -= instance.OnSButton;
            @SButton.canceled -= instance.OnSButton;
            @SpaceButton.started -= instance.OnSpaceButton;
            @SpaceButton.performed -= instance.OnSpaceButton;
            @SpaceButton.canceled -= instance.OnSpaceButton;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnDbutton(InputAction.CallbackContext context);
        void OnAButton(InputAction.CallbackContext context);
        void OnWButton(InputAction.CallbackContext context);
        void OnSButton(InputAction.CallbackContext context);
        void OnSpaceButton(InputAction.CallbackContext context);
    }
}
