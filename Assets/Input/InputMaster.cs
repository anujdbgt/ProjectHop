// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0bfd2133-8eb2-40a3-bd1e-1024b12e5297"",
            ""actions"": [
                {
                    ""name"": ""JumpAndSlideRight"",
                    ""type"": ""Button"",
                    ""id"": ""152b002e-9285-404f-9f93-bc4ebcfda79d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpAndSlideLeft"",
                    ""type"": ""Button"",
                    ""id"": ""e2a5939e-aa01-4af3-af0b-77b8f81b7912"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e7057a4-b0ce-4c2f-bf2b-616033bbbf65"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""KeyBoardAndMouse"",
                    ""action"": ""JumpAndSlideRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""052fa464-2510-49a3-a4e4-03ecba264b7c"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""JumpAndSlideRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f46ffbfe-6068-453c-a378-7f424d403560"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardAndMouse"",
                    ""action"": ""JumpAndSlideLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7c31d89-d2e9-442e-aeca-ec9cec89d238"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""JumpAndSlideLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoardAndMouse"",
            ""bindingGroup"": ""KeyBoardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""TouchScreen"",
            ""bindingGroup"": ""TouchScreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_JumpAndSlideRight = m_Player.FindAction("JumpAndSlideRight", throwIfNotFound: true);
        m_Player_JumpAndSlideLeft = m_Player.FindAction("JumpAndSlideLeft", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_JumpAndSlideRight;
    private readonly InputAction m_Player_JumpAndSlideLeft;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @JumpAndSlideRight => m_Wrapper.m_Player_JumpAndSlideRight;
        public InputAction @JumpAndSlideLeft => m_Wrapper.m_Player_JumpAndSlideLeft;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @JumpAndSlideRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpAndSlideRight;
                @JumpAndSlideRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpAndSlideRight;
                @JumpAndSlideRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpAndSlideRight;
                @JumpAndSlideLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpAndSlideLeft;
                @JumpAndSlideLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpAndSlideLeft;
                @JumpAndSlideLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpAndSlideLeft;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JumpAndSlideRight.started += instance.OnJumpAndSlideRight;
                @JumpAndSlideRight.performed += instance.OnJumpAndSlideRight;
                @JumpAndSlideRight.canceled += instance.OnJumpAndSlideRight;
                @JumpAndSlideLeft.started += instance.OnJumpAndSlideLeft;
                @JumpAndSlideLeft.performed += instance.OnJumpAndSlideLeft;
                @JumpAndSlideLeft.canceled += instance.OnJumpAndSlideLeft;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyBoardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyBoardAndMouseScheme
    {
        get
        {
            if (m_KeyBoardAndMouseSchemeIndex == -1) m_KeyBoardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyBoardAndMouse");
            return asset.controlSchemes[m_KeyBoardAndMouseSchemeIndex];
        }
    }
    private int m_TouchScreenSchemeIndex = -1;
    public InputControlScheme TouchScreenScheme
    {
        get
        {
            if (m_TouchScreenSchemeIndex == -1) m_TouchScreenSchemeIndex = asset.FindControlSchemeIndex("TouchScreen");
            return asset.controlSchemes[m_TouchScreenSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJumpAndSlideRight(InputAction.CallbackContext context);
        void OnJumpAndSlideLeft(InputAction.CallbackContext context);
    }
}
