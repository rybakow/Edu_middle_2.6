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

    private InputAction _rushAction;

    private float2 _moveInput;

    private float _rushInput;

    protected override void OnCreate()
    {
        _entityQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        // Rightstick for moving
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

        // Leftstick and space for rush
        _rushAction = new InputAction("rush", binding: "<Gamepad>/leftStickPress");
        //_rushAction.AddCompositeBinding("Dpad").With("Spacebar", "<Keyboard>/space");
        
        _rushAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _rushAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _rushAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _rushAction.Enable();
        
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_entityQuery).ForEach((Entity entity, ref InputData inputData, ref RushData rushData) =>
        {
            inputData.Move = _moveInput;
            Debug.Log("_rushInput = " + _rushInput);
        });
    }
}
