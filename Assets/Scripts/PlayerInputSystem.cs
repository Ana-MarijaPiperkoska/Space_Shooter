using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.InputSystem;
using System;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = false)]
public partial class PlayerInputSystem : SystemBase
{
    private GameInput InputActions;
    private Entity Player;

    protected override void OnCreate()
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerMoveInput>();
        InputActions = new GameInput();
    }

    protected override void OnStartRunning()
    {
        InputActions.Enable();
        InputActions.GamePlay.Shoot.performed += OnShoot;
        Player = SystemAPI.GetSingletonEntity<PlayerTag>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (!SystemAPI.Exists(Player)) return;

        SystemAPI.SetComponentEnabled<FireProjectileTag>(Player, true);
    }

    protected override void OnUpdate()
    {
        Dependency.Complete();
        Vector2 moveInput = InputActions.GamePlay.Move.ReadValue<Vector2>();

        SystemAPI.SetSingleton(new PlayerMoveInput { Value = moveInput });
    }

    protected override void OnStopRunning()
    {
        InputActions.Disable();
        Player = Entity.Null;
    }

}
