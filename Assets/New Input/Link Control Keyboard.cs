//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/New Input/Link Control Keyboard.inputactions
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

public partial class @LinkControlKeyboard: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @LinkControlKeyboard()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Link Control Keyboard"",
    ""maps"": [
        {
            ""name"": ""movement"",
            ""id"": ""664fbe98-256d-4f32-ac74-af723c30425c"",
            ""actions"": [
                {
                    ""name"": ""run"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b1205747-a468-442d-a320-c9e10e280c7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""51e145bf-d9b6-4a09-8aef-9bd226bfa26a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6d97426d-cf56-4025-ade8-5cd8fea7dd81"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f263505b-8315-49d1-b605-f59423ed3c4f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5c348beb-fb2e-4834-bd10-246d2fc5c621"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e08394df-791b-4d43-b06d-a2b5cf920b3e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""mando"",
                    ""id"": ""2ad05ea8-f8f7-4241-ad63-2fa85566e195"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1525f4c8-58a5-4566-8413-b1f776952bdb"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""abb89c57-8b39-4ada-950a-2204147c79a1"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9b5753a1-dcee-4b5b-b1b7-01b176034101"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""04d6f8c3-a646-40ff-9a2f-3efc9fbab4a3"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""wasd"",
                    ""id"": ""fd07f96e-31aa-4b50-a459-80750275890c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""190b99fa-b106-4b93-88cc-ec665fa1183c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e631860b-c41d-421f-b571-5a5b3ae397d8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6e3ee593-adee-4169-884d-3b0d34f2a70e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""29e5cbcb-bb71-43c3-ad11-135f4617bebc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""cruzeta"",
                    ""id"": ""97ba0243-6db7-409f-8292-95e6204a692a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f6f48c5d-5de6-408a-8d2c-8463ccbd6f57"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""da1a600c-3548-40c6-9e89-1432cdfb8c31"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""32a600f2-cc85-4ee3-a31e-5a4b677587ca"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9ba837ca-7b25-4f78-afa0-0aca1b675e83"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""aciones aceptar"",
            ""id"": ""08a37f7a-baa7-4d04-aa28-84f46384eef9"",
            ""actions"": [
                {
                    ""name"": ""b"",
                    ""type"": ""Button"",
                    ""id"": ""3d9bfa4a-1029-4011-88d3-4e07f9973fa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""94176730-3dd8-4d64-9db0-9d52152c8f93"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""b"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""043b3ab6-7681-4d1a-a085-789dfa2472b5"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""b"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32fabc90-d011-4f2d-8b01-ddb6ff850394"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""b"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Attack"",
            ""id"": ""6bd8488a-4e87-4743-b1e8-ad2350d6ccf4"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""abccd54e-389d-40a1-a938-6f227a809ef0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack cancel"",
                    ""type"": ""Button"",
                    ""id"": ""8003448d-226e-4802-9cff-15eeb7942692"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5be5fe90-3449-479a-8aa0-28724b826dd6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c0639d1-9030-49b7-8975-36d13e0f29e0"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27f7bb98-4744-47ea-a57c-8bb9515a3249"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09ffea23-329e-4943-9fe2-cb4a4fa704d9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""584d3c68-33aa-4d2b-8739-4c10f21aa962"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a48031f1-cf26-4c68-9ac1-fbe68d52be05"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""776a6ced-d789-4acb-a299-55cff6cfe478"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ad52f60-185b-4d41-9e94-d2c9b9b6fccf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // movement
        m_movement = asset.FindActionMap("movement", throwIfNotFound: true);
        m_movement_run = m_movement.FindAction("run", throwIfNotFound: true);
        // aciones aceptar
        m_acionesaceptar = asset.FindActionMap("aciones aceptar", throwIfNotFound: true);
        m_acionesaceptar_b = m_acionesaceptar.FindAction("b", throwIfNotFound: true);
        // Attack
        m_Attack = asset.FindActionMap("Attack", throwIfNotFound: true);
        m_Attack_Attack = m_Attack.FindAction("Attack", throwIfNotFound: true);
        m_Attack_Attackcancel = m_Attack.FindAction("Attack cancel", throwIfNotFound: true);
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

    // movement
    private readonly InputActionMap m_movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_movement_run;
    public struct MovementActions
    {
        private @LinkControlKeyboard m_Wrapper;
        public MovementActions(@LinkControlKeyboard wrapper) { m_Wrapper = wrapper; }
        public InputAction @run => m_Wrapper.m_movement_run;
        public InputActionMap Get() { return m_Wrapper.m_movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @run.started += instance.OnRun;
            @run.performed += instance.OnRun;
            @run.canceled += instance.OnRun;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @run.started -= instance.OnRun;
            @run.performed -= instance.OnRun;
            @run.canceled -= instance.OnRun;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @movement => new MovementActions(this);

    // aciones aceptar
    private readonly InputActionMap m_acionesaceptar;
    private List<IAcionesaceptarActions> m_AcionesaceptarActionsCallbackInterfaces = new List<IAcionesaceptarActions>();
    private readonly InputAction m_acionesaceptar_b;
    public struct AcionesaceptarActions
    {
        private @LinkControlKeyboard m_Wrapper;
        public AcionesaceptarActions(@LinkControlKeyboard wrapper) { m_Wrapper = wrapper; }
        public InputAction @b => m_Wrapper.m_acionesaceptar_b;
        public InputActionMap Get() { return m_Wrapper.m_acionesaceptar; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AcionesaceptarActions set) { return set.Get(); }
        public void AddCallbacks(IAcionesaceptarActions instance)
        {
            if (instance == null || m_Wrapper.m_AcionesaceptarActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AcionesaceptarActionsCallbackInterfaces.Add(instance);
            @b.started += instance.OnB;
            @b.performed += instance.OnB;
            @b.canceled += instance.OnB;
        }

        private void UnregisterCallbacks(IAcionesaceptarActions instance)
        {
            @b.started -= instance.OnB;
            @b.performed -= instance.OnB;
            @b.canceled -= instance.OnB;
        }

        public void RemoveCallbacks(IAcionesaceptarActions instance)
        {
            if (m_Wrapper.m_AcionesaceptarActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAcionesaceptarActions instance)
        {
            foreach (var item in m_Wrapper.m_AcionesaceptarActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AcionesaceptarActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AcionesaceptarActions @acionesaceptar => new AcionesaceptarActions(this);

    // Attack
    private readonly InputActionMap m_Attack;
    private List<IAttackActions> m_AttackActionsCallbackInterfaces = new List<IAttackActions>();
    private readonly InputAction m_Attack_Attack;
    private readonly InputAction m_Attack_Attackcancel;
    public struct AttackActions
    {
        private @LinkControlKeyboard m_Wrapper;
        public AttackActions(@LinkControlKeyboard wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Attack_Attack;
        public InputAction @Attackcancel => m_Wrapper.m_Attack_Attackcancel;
        public InputActionMap Get() { return m_Wrapper.m_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActions set) { return set.Get(); }
        public void AddCallbacks(IAttackActions instance)
        {
            if (instance == null || m_Wrapper.m_AttackActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AttackActionsCallbackInterfaces.Add(instance);
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Attackcancel.started += instance.OnAttackcancel;
            @Attackcancel.performed += instance.OnAttackcancel;
            @Attackcancel.canceled += instance.OnAttackcancel;
        }

        private void UnregisterCallbacks(IAttackActions instance)
        {
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Attackcancel.started -= instance.OnAttackcancel;
            @Attackcancel.performed -= instance.OnAttackcancel;
            @Attackcancel.canceled -= instance.OnAttackcancel;
        }

        public void RemoveCallbacks(IAttackActions instance)
        {
            if (m_Wrapper.m_AttackActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAttackActions instance)
        {
            foreach (var item in m_Wrapper.m_AttackActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AttackActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AttackActions @Attack => new AttackActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnRun(InputAction.CallbackContext context);
    }
    public interface IAcionesaceptarActions
    {
        void OnB(InputAction.CallbackContext context);
    }
    public interface IAttackActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnAttackcancel(InputAction.CallbackContext context);
    }
}
