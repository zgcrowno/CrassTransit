// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""2f63d68c-1947-41b1-b5c9-b38013f8bbd9"",
            ""actions"": [
                {
                    ""name"": ""FireGun"",
                    ""type"": ""Button"",
                    ""id"": ""cc46a0cf-8f24-4e97-b361-557d2de4793f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextGun"",
                    ""type"": ""Value"",
                    ""id"": ""72731693-f29f-47c6-9710-b2d2a19a246f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Value"",
                    ""id"": ""34d55b48-2e31-4bc8-8bea-36561dce4596"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimWithStick"",
                    ""type"": ""Value"",
                    ""id"": ""14b3eeaa-a02d-446a-a348-2caac3318860"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimWithMouse"",
                    ""type"": ""Value"",
                    ""id"": ""13c51146-d3dc-4ad1-b027-04299f7fdadf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3170f09e-f4e3-4de6-8a16-d653bf7ae21a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""cd6ac9e8-7886-4979-9779-a96c67011388"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9e2cfe6a-bae1-4461-a01c-91aeb5ea285c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectPistol"",
                    ""type"": ""Button"",
                    ""id"": ""bced91be-547f-474e-9927-4e4dc95307c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectAssaultRifle"",
                    ""type"": ""Button"",
                    ""id"": ""3f5ab990-8e52-4d36-a6b5-59b030d0bfeb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectShotgun"",
                    ""type"": ""Button"",
                    ""id"": ""fef8382c-4cd3-4b11-b044-4615ef20d2c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectRocketLauncher"",
                    ""type"": ""Button"",
                    ""id"": ""1dd09918-4f6f-48e7-8ef2-807455438496"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83e58a22-771b-48a8-8a13-d84ff1f02fe0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""315a68ab-2d01-47c3-90b0-b71336453ec2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d66bb1c7-1d24-4551-92ea-9e38a28e4388"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""05e5b88c-ab55-43b6-9bcd-8901f4ccdb13"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextGun"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""de0cf726-4bac-4bb8-bd1e-d486905ce032"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b341799d-8aa1-4128-8d49-7506eece8a30"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""87151b6b-4934-4054-8264-9e5b21f23538"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f4063152-c149-4a20-bd34-f128ec091a67"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cd6259a4-5ecc-4153-b094-1926c908d380"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamepadDPad"",
                    ""id"": ""1a1e197c-d383-445f-8612-58c5c2f0559e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1bb42050-711f-47dd-8cbf-4a601f5b3cf3"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1e9f3a74-12d3-487f-bb06-57da74ea5a82"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamepadAnalogStick"",
                    ""id"": ""c3a6026c-83f4-4d02-90b3-39f802c14ae5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""aed78045-61e5-42e6-bc1c-3387e07af74d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1f72a9f6-3df0-403c-88bf-0c807baccfc2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamepadAnalogStick"",
                    ""id"": ""9d3f5de1-c9e6-41a4-ae33-f9e02a5e61bf"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0536c508-f264-4b1a-832e-89ba34f7fc42"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""71620f23-9ca5-409c-bcae-5386b39e44cd"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""36fd70c8-56af-494a-a37d-331d4ab424aa"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4f911ed1-facf-4f22-80d6-d9921ba934b5"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""47ace26b-83b6-4654-88e1-e4223d805163"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithMouse"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84988696-79a6-4cf4-b715-1c217f7e91e1"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""80b20e8b-aa8a-40ac-a7ce-3d4007a48996"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50b4d687-83e5-4787-bc6e-7a36d7cac49a"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ceb105f4-be6e-40d9-a535-72e661bce9f8"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimWithMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c21de4ba-484e-465d-b9de-09b40d3d07cc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e373d600-ea4a-4ab3-ace7-e2fb6ace97a5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e978126-5eb0-44fc-8dd4-dd41f49425fb"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eda14a3e-f6d4-4fe4-919c-b8d2c9cba407"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6133f702-dff5-4578-b20b-8e6eaf367e14"",
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
                    ""id"": ""8fbc3e39-1889-4eb1-a75e-bc517b663ddc"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectPistol"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c3e10a8-d2e9-4836-8ab7-ce3cd00ad626"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectAssaultRifle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79963d54-d5e7-462b-82ed-439fab705d48"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectShotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f25ddb25-003d-434b-86f8-5ecc35f358bd"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectRocketLauncher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_FireGun = m_Gameplay.FindAction("FireGun", throwIfNotFound: true);
        m_Gameplay_NextGun = m_Gameplay.FindAction("NextGun", throwIfNotFound: true);
        m_Gameplay_MoveRight = m_Gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_Gameplay_AimWithStick = m_Gameplay.FindAction("AimWithStick", throwIfNotFound: true);
        m_Gameplay_AimWithMouse = m_Gameplay.FindAction("AimWithMouse", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_SelectPistol = m_Gameplay.FindAction("SelectPistol", throwIfNotFound: true);
        m_Gameplay_SelectAssaultRifle = m_Gameplay.FindAction("SelectAssaultRifle", throwIfNotFound: true);
        m_Gameplay_SelectShotgun = m_Gameplay.FindAction("SelectShotgun", throwIfNotFound: true);
        m_Gameplay_SelectRocketLauncher = m_Gameplay.FindAction("SelectRocketLauncher", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_FireGun;
    private readonly InputAction m_Gameplay_NextGun;
    private readonly InputAction m_Gameplay_MoveRight;
    private readonly InputAction m_Gameplay_AimWithStick;
    private readonly InputAction m_Gameplay_AimWithMouse;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Reload;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_SelectPistol;
    private readonly InputAction m_Gameplay_SelectAssaultRifle;
    private readonly InputAction m_Gameplay_SelectShotgun;
    private readonly InputAction m_Gameplay_SelectRocketLauncher;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @FireGun => m_Wrapper.m_Gameplay_FireGun;
        public InputAction @NextGun => m_Wrapper.m_Gameplay_NextGun;
        public InputAction @MoveRight => m_Wrapper.m_Gameplay_MoveRight;
        public InputAction @AimWithStick => m_Wrapper.m_Gameplay_AimWithStick;
        public InputAction @AimWithMouse => m_Wrapper.m_Gameplay_AimWithMouse;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @SelectPistol => m_Wrapper.m_Gameplay_SelectPistol;
        public InputAction @SelectAssaultRifle => m_Wrapper.m_Gameplay_SelectAssaultRifle;
        public InputAction @SelectShotgun => m_Wrapper.m_Gameplay_SelectShotgun;
        public InputAction @SelectRocketLauncher => m_Wrapper.m_Gameplay_SelectRocketLauncher;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @FireGun.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGun;
                @FireGun.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGun;
                @FireGun.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGun;
                @NextGun.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNextGun;
                @NextGun.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNextGun;
                @NextGun.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNextGun;
                @MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @AimWithStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimWithStick;
                @AimWithStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimWithStick;
                @AimWithStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimWithStick;
                @AimWithMouse.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimWithMouse;
                @AimWithMouse.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimWithMouse;
                @AimWithMouse.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimWithMouse;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Reload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @SelectPistol.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPistol;
                @SelectPistol.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPistol;
                @SelectPistol.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPistol;
                @SelectAssaultRifle.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectAssaultRifle;
                @SelectAssaultRifle.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectAssaultRifle;
                @SelectAssaultRifle.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectAssaultRifle;
                @SelectShotgun.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectShotgun;
                @SelectShotgun.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectShotgun;
                @SelectShotgun.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectShotgun;
                @SelectRocketLauncher.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectRocketLauncher;
                @SelectRocketLauncher.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectRocketLauncher;
                @SelectRocketLauncher.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectRocketLauncher;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FireGun.started += instance.OnFireGun;
                @FireGun.performed += instance.OnFireGun;
                @FireGun.canceled += instance.OnFireGun;
                @NextGun.started += instance.OnNextGun;
                @NextGun.performed += instance.OnNextGun;
                @NextGun.canceled += instance.OnNextGun;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @AimWithStick.started += instance.OnAimWithStick;
                @AimWithStick.performed += instance.OnAimWithStick;
                @AimWithStick.canceled += instance.OnAimWithStick;
                @AimWithMouse.started += instance.OnAimWithMouse;
                @AimWithMouse.performed += instance.OnAimWithMouse;
                @AimWithMouse.canceled += instance.OnAimWithMouse;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SelectPistol.started += instance.OnSelectPistol;
                @SelectPistol.performed += instance.OnSelectPistol;
                @SelectPistol.canceled += instance.OnSelectPistol;
                @SelectAssaultRifle.started += instance.OnSelectAssaultRifle;
                @SelectAssaultRifle.performed += instance.OnSelectAssaultRifle;
                @SelectAssaultRifle.canceled += instance.OnSelectAssaultRifle;
                @SelectShotgun.started += instance.OnSelectShotgun;
                @SelectShotgun.performed += instance.OnSelectShotgun;
                @SelectShotgun.canceled += instance.OnSelectShotgun;
                @SelectRocketLauncher.started += instance.OnSelectRocketLauncher;
                @SelectRocketLauncher.performed += instance.OnSelectRocketLauncher;
                @SelectRocketLauncher.canceled += instance.OnSelectRocketLauncher;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnFireGun(InputAction.CallbackContext context);
        void OnNextGun(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnAimWithStick(InputAction.CallbackContext context);
        void OnAimWithMouse(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSelectPistol(InputAction.CallbackContext context);
        void OnSelectAssaultRifle(InputAction.CallbackContext context);
        void OnSelectShotgun(InputAction.CallbackContext context);
        void OnSelectRocketLauncher(InputAction.CallbackContext context);
    }
}
