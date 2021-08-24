using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public enum InputType
{
    mkb = 0,
    touch = 1,
    gamepad = 2
}

public class PlayerController : MonoBehaviour
{
    private Controls controls;
    private Player m_pPlayer;
    private GraphicRaycaster m_pGraphicRaycaster;
    private TextMeshProUGUI m_tRicochetOnOffText;
    private bool m_bFireInputIsActive;
    private float m_fPlayerHorizontalMovementMultiplier;

    private void Awake()
    {
        controls = new Controls();

        controls.Gameplay.MoveRight.performed += ctx => m_fPlayerHorizontalMovementMultiplier = ctx.ReadValue<float>();
        controls.Gameplay.MoveRight.canceled += ctx => m_fPlayerHorizontalMovementMultiplier = 0;
        controls.Gameplay.Jump.performed += ctx => JumpPlayer();
        controls.Gameplay.AimWithStick.performed += ctx => AimWithStick(ctx.ReadValue<Vector2>());
        controls.Gameplay.AimWithMouse.performed += ctx => m_pPlayer.SetInputType(InputType.mkb);
        controls.Gameplay.FireGun.performed += ctx => FirePlayerGun();
        controls.Gameplay.FireGun.canceled += ctx => StopFiringPlayerGun();
        controls.Gameplay.FireGunRicochet.performed += ctx => FirePlayerGun(true);
        controls.Gameplay.FireGunRicochet.canceled += ctx => StopFiringPlayerGun();
        controls.Gameplay.NextGun.performed += ctx => m_pPlayer.ScrollThroughGuns(ctx.ReadValue<float>());
        controls.Gameplay.Reload.performed += ctx => m_pPlayer.Reload();
        controls.Gameplay.SelectPistol.performed += ctx => m_pPlayer.EquipGunAtIndex(0);
        controls.Gameplay.SelectAssaultRifle.performed += ctx => m_pPlayer.EquipGunAtIndex(1);
        controls.Gameplay.SelectShotgun.performed += ctx => m_pPlayer.EquipGunAtIndex(2);
        controls.Gameplay.SelectRocketLauncher.performed += ctx => m_pPlayer.EquipGunAtIndex(3);
        controls.Gameplay.PressScreen.performed += ctx => RegisterScreenPress();
        controls.Gameplay.PressScreen.canceled += ctx => StopFiringPlayerGun();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_pPlayer = GameObject.Find("Player").GetComponent<Player>();
        m_pGraphicRaycaster = GameObject.Find("LevelCanvas").GetComponent<GraphicRaycaster>();
        m_tRicochetOnOffText = GameObject.Find("OnOffText").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(m_fPlayerHorizontalMovementMultiplier);
    }

    void MovePlayer(float _horizontalMovementMultiplier)
    {
        if (PlayerCanJump())
        {
            m_pPlayer.Move(_horizontalMovementMultiplier);
        }
    }

    void JumpPlayer()
    {
        if (PlayerCanJump())
        {
            m_pPlayer.Jump();
        }
    }

    void AimWithStick(Vector2 _aimDirection)
    {
        m_pPlayer.SetInputType(InputType.gamepad);
        m_pPlayer.AimWithStick(_aimDirection);
    }

    void FirePlayerGun(bool _ricochet = false)
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = Input.touchCount > 0 ? Input.touches[0].position : new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        m_pGraphicRaycaster.Raycast(ped, raycastResults);
        
        if (raycastResults.Count == 0 || raycastResults[0].gameObject.GetComponent<Timer>() != null)
        {
            m_pPlayer.PointGun();

            m_pPlayer.SetIsFiringRicochets(_ricochet);
            m_tRicochetOnOffText.text = _ricochet ? "On" : "Off";
            m_bFireInputIsActive = true;
            if (m_pPlayer.IsWieldingAutomatic())
            {
                m_pPlayer.StartFiringAutomatic();
            }
            else
            {
                m_pPlayer.FireGun();
            }
        }
    }

    void RegisterScreenPress()
    {
        m_pPlayer.SetInputType(InputType.touch);

        FirePlayerGun(m_pPlayer.IsFiringRicochets());
    }

    void StopFiringPlayerGun()
    {
        m_bFireInputIsActive = false;
        m_pPlayer.StopFiringAutomatic();
    }

    bool PlayerCanJump()
    {
        return m_pPlayer.IsJumping() || (m_pPlayer.m_bRegularMovementAllowed && m_pPlayer.IsGrounded() && !m_bFireInputIsActive);
    }
}
