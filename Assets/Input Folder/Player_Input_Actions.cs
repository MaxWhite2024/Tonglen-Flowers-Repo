//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Input Folder/Player_Input_Actions.inputactions
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

public partial class @Player_Input_Actions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Input_Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Input_Actions"",
    ""maps"": [
        {
            ""name"": ""Gameplay Actions"",
            ""id"": ""0f9c241c-f540-4adb-a3da-20b33dac2efe"",
            ""actions"": [
                {
                    ""name"": ""Breath In"",
                    ""type"": ""Button"",
                    ""id"": ""38e9fb37-1c5e-4618-afe8-05a8eee1559e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""60c76e2b-3ee7-4616-9be7-57d067fa7619"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""20435da3-9a61-4e6c-af7c-3b1c94b58f76"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Breath In"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ce8c32e-5a15-4958-b797-b29c4ba4c1f6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c60650e-a255-46c1-b0f3-9be5858d93fa"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Explore Gameplay Actions"",
            ""id"": ""49344aa4-46a6-470b-a964-5c18ad065ac6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""559452e6-5bbc-481a-8628-85266b5f1c15"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0d885db2-e3cc-4ed2-8093-8556cb66d522"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""01b2d16b-c1cd-4290-8f0c-cc0afb326c9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0d028bbf-00e1-47cb-ba23-55010d95952f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f881ddc-23d4-4cfc-bf1b-c8da5ea8026a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1a59b0c-4875-4257-a809-78911b8021be"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""fe3fa970-88c8-449b-8330-e032a9de4542"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3d118aa8-6adb-40b0-8b85-6f1ab8cb8103"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82767fa2-457d-448f-bcb3-b4afdf813d30"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""428d23b4-0ba5-426b-abe3-1124424df4e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""67f69a36-3870-481f-8dec-f6fed2b6d58a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""848f836e-b2cf-4dfd-a953-3aeb323c2dec"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d0e0fb27-3225-4cfd-84eb-9b65cfb4c930"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ef964610-0da6-489d-b1ea-dce9fc9f40d1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dde541bc-a7c7-43f5-9c25-517060e6e56d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f43afe17-cfa8-48da-b22c-4e71aee956dc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ae16d879-6ff8-44c7-b647-92e135168825"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a34f7bb-9266-4665-8c10-8cb29912309a"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay Actions
        m_GameplayActions = asset.FindActionMap("Gameplay Actions", throwIfNotFound: true);
        m_GameplayActions_BreathIn = m_GameplayActions.FindAction("Breath In", throwIfNotFound: true);
        m_GameplayActions_Pause = m_GameplayActions.FindAction("Pause", throwIfNotFound: true);
        // Explore Gameplay Actions
        m_ExploreGameplayActions = asset.FindActionMap("Explore Gameplay Actions", throwIfNotFound: true);
        m_ExploreGameplayActions_Move = m_ExploreGameplayActions.FindAction("Move", throwIfNotFound: true);
        m_ExploreGameplayActions_Interact = m_ExploreGameplayActions.FindAction("Interact", throwIfNotFound: true);
        m_ExploreGameplayActions_Pause = m_ExploreGameplayActions.FindAction("Pause", throwIfNotFound: true);
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

    // Gameplay Actions
    private readonly InputActionMap m_GameplayActions;
    private List<IGameplayActionsActions> m_GameplayActionsActionsCallbackInterfaces = new List<IGameplayActionsActions>();
    private readonly InputAction m_GameplayActions_BreathIn;
    private readonly InputAction m_GameplayActions_Pause;
    public struct GameplayActionsActions
    {
        private @Player_Input_Actions m_Wrapper;
        public GameplayActionsActions(@Player_Input_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @BreathIn => m_Wrapper.m_GameplayActions_BreathIn;
        public InputAction @Pause => m_Wrapper.m_GameplayActions_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameplayActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActionsActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsActionsCallbackInterfaces.Add(instance);
            @BreathIn.started += instance.OnBreathIn;
            @BreathIn.performed += instance.OnBreathIn;
            @BreathIn.canceled += instance.OnBreathIn;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IGameplayActionsActions instance)
        {
            @BreathIn.started -= instance.OnBreathIn;
            @BreathIn.performed -= instance.OnBreathIn;
            @BreathIn.canceled -= instance.OnBreathIn;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IGameplayActionsActions instance)
        {
            if (m_Wrapper.m_GameplayActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActionsActions @GameplayActions => new GameplayActionsActions(this);

    // Explore Gameplay Actions
    private readonly InputActionMap m_ExploreGameplayActions;
    private List<IExploreGameplayActionsActions> m_ExploreGameplayActionsActionsCallbackInterfaces = new List<IExploreGameplayActionsActions>();
    private readonly InputAction m_ExploreGameplayActions_Move;
    private readonly InputAction m_ExploreGameplayActions_Interact;
    private readonly InputAction m_ExploreGameplayActions_Pause;
    public struct ExploreGameplayActionsActions
    {
        private @Player_Input_Actions m_Wrapper;
        public ExploreGameplayActionsActions(@Player_Input_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ExploreGameplayActions_Move;
        public InputAction @Interact => m_Wrapper.m_ExploreGameplayActions_Interact;
        public InputAction @Pause => m_Wrapper.m_ExploreGameplayActions_Pause;
        public InputActionMap Get() { return m_Wrapper.m_ExploreGameplayActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExploreGameplayActionsActions set) { return set.Get(); }
        public void AddCallbacks(IExploreGameplayActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_ExploreGameplayActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ExploreGameplayActionsActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IExploreGameplayActionsActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IExploreGameplayActionsActions instance)
        {
            if (m_Wrapper.m_ExploreGameplayActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IExploreGameplayActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_ExploreGameplayActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ExploreGameplayActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ExploreGameplayActionsActions @ExploreGameplayActions => new ExploreGameplayActionsActions(this);
    public interface IGameplayActionsActions
    {
        void OnBreathIn(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IExploreGameplayActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
