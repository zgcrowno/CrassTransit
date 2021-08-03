using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Controls controls;
    private Player m_pPlayer;
    private bool m_bFireInputIsActive;
    private float m_fPlayerHorizontalMovementMultiplier;

    private void Awake()
    {
        controls = new Controls();

        controls.Gameplay.MoveRight.performed += ctx => m_fPlayerHorizontalMovementMultiplier = ctx.ReadValue<float>();
        controls.Gameplay.MoveRight.canceled += ctx => m_fPlayerHorizontalMovementMultiplier = 0;
        controls.Gameplay.Jump.performed += ctx => JumpPlayer();
        controls.Gameplay.AimWithStick.performed += ctx => AimWithStick(ctx.ReadValue<Vector2>());
        controls.Gameplay.AimWithMouse.performed += ctx => m_pPlayer.SetAimType(false);
        controls.Gameplay.FireGun.performed += ctx => FirePlayerGun();
        controls.Gameplay.FireGun.canceled += ctx => StopFiringPlayerGun();
        controls.Gameplay.NextGun.performed += ctx => m_pPlayer.ScrollThroughGuns(ctx.ReadValue<float>());
        controls.Gameplay.Reload.performed += ctx => m_pPlayer.Reload();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_pPlayer = GameObject.Find("Player").GetComponent<Player>();
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
        m_pPlayer.SetAimType(true);
        m_pPlayer.AimWithStick(_aimDirection);
    }

    void FirePlayerGun()
    {
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
