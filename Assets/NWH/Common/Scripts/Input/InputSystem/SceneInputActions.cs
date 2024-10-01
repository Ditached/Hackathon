//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/NWH/Common/Scripts/Input/InputSystem/SceneInputActions.inputactions
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

namespace NWH.Common.Input
{
    public partial class @SceneInputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @SceneInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""SceneInputActions"",
    ""maps"": [
        {
            ""name"": ""CameraControls"",
            ""id"": ""f9b2c2eb-8265-4430-a0ac-4cf8495a2002"",
            ""actions"": [
                {
                    ""name"": ""ChangeCamera"",
                    ""type"": ""Button"",
                    ""id"": ""71ec0b0c-0911-4b04-a2cc-424b01ebe88e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraRotation"",
                    ""type"": ""Value"",
                    ""id"": ""8f870466-b390-4fae-a439-ccb19a4537c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraPanning"",
                    ""type"": ""Value"",
                    ""id"": ""08d3e09d-7ab8-4f42-976a-530f947fe4c8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraRotationModifier"",
                    ""type"": ""Button"",
                    ""id"": ""124e3374-e4a2-4e74-b0cf-c8959a11ac39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraPanningModifier"",
                    ""type"": ""Button"",
                    ""id"": ""ce8eda53-b48a-45c4-83c7-3f0b44ad36f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Value"",
                    ""id"": ""018cdf61-e865-49da-9064-33dc2ae63580"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""24fa1b4b-fa43-49bc-ba60-3aedbe8d6c1f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""530b85ac-4cae-49f9-804b-3a0dbaeb4a7b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d0ae04c-f252-4dd6-824a-27baa3d26db7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.2,y=0.2)"",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""2cb8a8bc-5e28-4393-bc30-fe55c9d9ffc7"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2"",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a144950a-0314-41fb-b0a3-0fa7943d12f1"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a039c90a-129d-43ea-b2ec-bffde20e618a"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e78f01bc-414a-4ba8-83e0-02deb5f631c6"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3cd6cbde-a6f8-4da4-8cc2-9c8c1edc133e"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9e78c527-4641-4f9b-98e4-fb7f87edf64d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.2,y=0.2)"",
                    ""groups"": """",
                    ""action"": ""CameraPanning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3968d956-a143-403b-87e5-0b91afb999eb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotationModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f3a4e0e-6782-4b53-8c26-e06e68d8e1ee"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotationModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a15b75c-fd20-4def-8b73-5d8273fe3364"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPanningModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee7ac85-80d0-4018-bbe7-114eecc930ae"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPanningModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""93e86e22-3ea3-4e7f-b800-9fc9575e9190"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2"",
                    ""groups"": """",
                    ""action"": ""CameraPanning"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9e35bef4-dec2-47ce-a040-063273bd2183"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPanning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ca312712-12f3-438c-a542-d998b4fca387"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPanning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""16a19e86-eb75-40ef-a937-cc69f5c57971"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPanning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""338131ba-47f8-4fc8-b137-39be986200ed"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPanning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2553a5ac-0892-4d77-a408-8b5fced329a8"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.1)"",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""aeaabcc3-6825-4a24-b1b3-13b3a70fff59"",
                    ""path"": ""1DAxis(whichSideWins=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d55890ea-00d2-483e-9b0a-e2ba85f4b2dd"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3ce859ed-6297-4bab-b40b-d6436bacd5ab"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""SceneControls"",
            ""id"": ""abb87e97-bffa-439c-a42d-7b1a9497c4cc"",
            ""actions"": [
                {
                    ""name"": ""ChangeVehicle"",
                    ""type"": ""Button"",
                    ""id"": ""a6ddd2a4-de73-4949-8b79-fef6d4b4bc3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FPSMovement"",
                    ""type"": ""Value"",
                    ""id"": ""347a1c7d-d6ca-4838-9d67-ca3bece4074f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ToggleGUI"",
                    ""type"": ""Button"",
                    ""id"": ""420fdb48-6cea-444b-8cd6-256097129d3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DragObjectModifier"",
                    ""type"": ""Button"",
                    ""id"": ""1fd9ef37-8fcf-43c4-9b96-ed432f843af4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShowCursor"",
                    ""type"": ""Button"",
                    ""id"": ""4566d436-6301-4d31-bd9b-984b19b6cc9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""02e5b759-a74a-41e1-af72-80c6990f0d95"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeVehicle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01597fdb-29e0-4e77-a920-ba59240fe6d6"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeVehicle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""59431748-63e9-4210-8dd9-590e23bcdf0c"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e0b8875d-06d4-467d-b8f0-61da2e804895"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""87e4ea7c-c07f-491e-8dc6-36f79dbf9805"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9bba77a1-921c-493d-b881-6f14f1eb377b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cfa4cf6d-3fe9-4930-847f-b59a8277a8fc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""208efade-fdb9-49b9-a679-eb44b6ed6ac2"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8087e701-d9e1-454b-8b70-50813a31516b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0b594ea6-b48c-4805-9cea-77058ade6d6a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e7548400-0520-4980-aded-b6d0ac753e4a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b46be990-1176-4948-8642-dddc1bf5ee6c"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FPSMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9f9f8d86-cd0b-4953-8490-e72ab4b7d8f0"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleGUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d06a9ed-570c-45df-ae1b-aec7652096fd"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DragObjectModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2685a4d7-beae-479c-a63b-f7cd494f9c8a"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CameraControls
            m_CameraControls = asset.FindActionMap("CameraControls", throwIfNotFound: true);
            m_CameraControls_ChangeCamera = m_CameraControls.FindAction("ChangeCamera", throwIfNotFound: true);
            m_CameraControls_CameraRotation = m_CameraControls.FindAction("CameraRotation", throwIfNotFound: true);
            m_CameraControls_CameraPanning = m_CameraControls.FindAction("CameraPanning", throwIfNotFound: true);
            m_CameraControls_CameraRotationModifier = m_CameraControls.FindAction("CameraRotationModifier", throwIfNotFound: true);
            m_CameraControls_CameraPanningModifier = m_CameraControls.FindAction("CameraPanningModifier", throwIfNotFound: true);
            m_CameraControls_CameraZoom = m_CameraControls.FindAction("CameraZoom", throwIfNotFound: true);
            // SceneControls
            m_SceneControls = asset.FindActionMap("SceneControls", throwIfNotFound: true);
            m_SceneControls_ChangeVehicle = m_SceneControls.FindAction("ChangeVehicle", throwIfNotFound: true);
            m_SceneControls_FPSMovement = m_SceneControls.FindAction("FPSMovement", throwIfNotFound: true);
            m_SceneControls_ToggleGUI = m_SceneControls.FindAction("ToggleGUI", throwIfNotFound: true);
            m_SceneControls_DragObjectModifier = m_SceneControls.FindAction("DragObjectModifier", throwIfNotFound: true);
            m_SceneControls_ShowCursor = m_SceneControls.FindAction("ShowCursor", throwIfNotFound: true);
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

        // CameraControls
        private readonly InputActionMap m_CameraControls;
        private List<ICameraControlsActions> m_CameraControlsActionsCallbackInterfaces = new List<ICameraControlsActions>();
        private readonly InputAction m_CameraControls_ChangeCamera;
        private readonly InputAction m_CameraControls_CameraRotation;
        private readonly InputAction m_CameraControls_CameraPanning;
        private readonly InputAction m_CameraControls_CameraRotationModifier;
        private readonly InputAction m_CameraControls_CameraPanningModifier;
        private readonly InputAction m_CameraControls_CameraZoom;
        public struct CameraControlsActions
        {
            private @SceneInputActions m_Wrapper;
            public CameraControlsActions(@SceneInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @ChangeCamera => m_Wrapper.m_CameraControls_ChangeCamera;
            public InputAction @CameraRotation => m_Wrapper.m_CameraControls_CameraRotation;
            public InputAction @CameraPanning => m_Wrapper.m_CameraControls_CameraPanning;
            public InputAction @CameraRotationModifier => m_Wrapper.m_CameraControls_CameraRotationModifier;
            public InputAction @CameraPanningModifier => m_Wrapper.m_CameraControls_CameraPanningModifier;
            public InputAction @CameraZoom => m_Wrapper.m_CameraControls_CameraZoom;
            public InputActionMap Get() { return m_Wrapper.m_CameraControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraControlsActions set) { return set.Get(); }
            public void AddCallbacks(ICameraControlsActions instance)
            {
                if (instance == null || m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Add(instance);
                @ChangeCamera.started += instance.OnChangeCamera;
                @ChangeCamera.performed += instance.OnChangeCamera;
                @ChangeCamera.canceled += instance.OnChangeCamera;
                @CameraRotation.started += instance.OnCameraRotation;
                @CameraRotation.performed += instance.OnCameraRotation;
                @CameraRotation.canceled += instance.OnCameraRotation;
                @CameraPanning.started += instance.OnCameraPanning;
                @CameraPanning.performed += instance.OnCameraPanning;
                @CameraPanning.canceled += instance.OnCameraPanning;
                @CameraRotationModifier.started += instance.OnCameraRotationModifier;
                @CameraRotationModifier.performed += instance.OnCameraRotationModifier;
                @CameraRotationModifier.canceled += instance.OnCameraRotationModifier;
                @CameraPanningModifier.started += instance.OnCameraPanningModifier;
                @CameraPanningModifier.performed += instance.OnCameraPanningModifier;
                @CameraPanningModifier.canceled += instance.OnCameraPanningModifier;
                @CameraZoom.started += instance.OnCameraZoom;
                @CameraZoom.performed += instance.OnCameraZoom;
                @CameraZoom.canceled += instance.OnCameraZoom;
            }

            private void UnregisterCallbacks(ICameraControlsActions instance)
            {
                @ChangeCamera.started -= instance.OnChangeCamera;
                @ChangeCamera.performed -= instance.OnChangeCamera;
                @ChangeCamera.canceled -= instance.OnChangeCamera;
                @CameraRotation.started -= instance.OnCameraRotation;
                @CameraRotation.performed -= instance.OnCameraRotation;
                @CameraRotation.canceled -= instance.OnCameraRotation;
                @CameraPanning.started -= instance.OnCameraPanning;
                @CameraPanning.performed -= instance.OnCameraPanning;
                @CameraPanning.canceled -= instance.OnCameraPanning;
                @CameraRotationModifier.started -= instance.OnCameraRotationModifier;
                @CameraRotationModifier.performed -= instance.OnCameraRotationModifier;
                @CameraRotationModifier.canceled -= instance.OnCameraRotationModifier;
                @CameraPanningModifier.started -= instance.OnCameraPanningModifier;
                @CameraPanningModifier.performed -= instance.OnCameraPanningModifier;
                @CameraPanningModifier.canceled -= instance.OnCameraPanningModifier;
                @CameraZoom.started -= instance.OnCameraZoom;
                @CameraZoom.performed -= instance.OnCameraZoom;
                @CameraZoom.canceled -= instance.OnCameraZoom;
            }

            public void RemoveCallbacks(ICameraControlsActions instance)
            {
                if (m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICameraControlsActions instance)
            {
                foreach (var item in m_Wrapper.m_CameraControlsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CameraControlsActions @CameraControls => new CameraControlsActions(this);

        // SceneControls
        private readonly InputActionMap m_SceneControls;
        private List<ISceneControlsActions> m_SceneControlsActionsCallbackInterfaces = new List<ISceneControlsActions>();
        private readonly InputAction m_SceneControls_ChangeVehicle;
        private readonly InputAction m_SceneControls_FPSMovement;
        private readonly InputAction m_SceneControls_ToggleGUI;
        private readonly InputAction m_SceneControls_DragObjectModifier;
        private readonly InputAction m_SceneControls_ShowCursor;
        public struct SceneControlsActions
        {
            private @SceneInputActions m_Wrapper;
            public SceneControlsActions(@SceneInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @ChangeVehicle => m_Wrapper.m_SceneControls_ChangeVehicle;
            public InputAction @FPSMovement => m_Wrapper.m_SceneControls_FPSMovement;
            public InputAction @ToggleGUI => m_Wrapper.m_SceneControls_ToggleGUI;
            public InputAction @DragObjectModifier => m_Wrapper.m_SceneControls_DragObjectModifier;
            public InputAction @ShowCursor => m_Wrapper.m_SceneControls_ShowCursor;
            public InputActionMap Get() { return m_Wrapper.m_SceneControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SceneControlsActions set) { return set.Get(); }
            public void AddCallbacks(ISceneControlsActions instance)
            {
                if (instance == null || m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Add(instance);
                @ChangeVehicle.started += instance.OnChangeVehicle;
                @ChangeVehicle.performed += instance.OnChangeVehicle;
                @ChangeVehicle.canceled += instance.OnChangeVehicle;
                @FPSMovement.started += instance.OnFPSMovement;
                @FPSMovement.performed += instance.OnFPSMovement;
                @FPSMovement.canceled += instance.OnFPSMovement;
                @ToggleGUI.started += instance.OnToggleGUI;
                @ToggleGUI.performed += instance.OnToggleGUI;
                @ToggleGUI.canceled += instance.OnToggleGUI;
                @DragObjectModifier.started += instance.OnDragObjectModifier;
                @DragObjectModifier.performed += instance.OnDragObjectModifier;
                @DragObjectModifier.canceled += instance.OnDragObjectModifier;
                @ShowCursor.started += instance.OnShowCursor;
                @ShowCursor.performed += instance.OnShowCursor;
                @ShowCursor.canceled += instance.OnShowCursor;
            }

            private void UnregisterCallbacks(ISceneControlsActions instance)
            {
                @ChangeVehicle.started -= instance.OnChangeVehicle;
                @ChangeVehicle.performed -= instance.OnChangeVehicle;
                @ChangeVehicle.canceled -= instance.OnChangeVehicle;
                @FPSMovement.started -= instance.OnFPSMovement;
                @FPSMovement.performed -= instance.OnFPSMovement;
                @FPSMovement.canceled -= instance.OnFPSMovement;
                @ToggleGUI.started -= instance.OnToggleGUI;
                @ToggleGUI.performed -= instance.OnToggleGUI;
                @ToggleGUI.canceled -= instance.OnToggleGUI;
                @DragObjectModifier.started -= instance.OnDragObjectModifier;
                @DragObjectModifier.performed -= instance.OnDragObjectModifier;
                @DragObjectModifier.canceled -= instance.OnDragObjectModifier;
                @ShowCursor.started -= instance.OnShowCursor;
                @ShowCursor.performed -= instance.OnShowCursor;
                @ShowCursor.canceled -= instance.OnShowCursor;
            }

            public void RemoveCallbacks(ISceneControlsActions instance)
            {
                if (m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ISceneControlsActions instance)
            {
                foreach (var item in m_Wrapper.m_SceneControlsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public SceneControlsActions @SceneControls => new SceneControlsActions(this);
        public interface ICameraControlsActions
        {
            void OnChangeCamera(InputAction.CallbackContext context);
            void OnCameraRotation(InputAction.CallbackContext context);
            void OnCameraPanning(InputAction.CallbackContext context);
            void OnCameraRotationModifier(InputAction.CallbackContext context);
            void OnCameraPanningModifier(InputAction.CallbackContext context);
            void OnCameraZoom(InputAction.CallbackContext context);
        }
        public interface ISceneControlsActions
        {
            void OnChangeVehicle(InputAction.CallbackContext context);
            void OnFPSMovement(InputAction.CallbackContext context);
            void OnToggleGUI(InputAction.CallbackContext context);
            void OnDragObjectModifier(InputAction.CallbackContext context);
            void OnShowCursor(InputAction.CallbackContext context);
        }
    }
}
