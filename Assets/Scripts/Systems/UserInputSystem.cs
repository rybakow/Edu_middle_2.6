using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : ComponentSystem
{

    private EntityQuery _entityQuery;

    private InputAction _moveAction;

    private float2 _moveInput;

    protected override void OnCreate()
    {
        _entityQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        _moveAction = new InputAction("move", binding:"<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        
        
        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_entityQuery).ForEach((Entity entity, ref InputData inputData) =>
        {
            inputData.Move = _moveInput;
        });
    }
}
