using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBaseState : IState
{
	protected PlayerStateMachine stateMachine;
	protected readonly PlayerGroundData groundData;

	public PlayerBaseState(PlayerStateMachine PlayerstateMachine)
	{
		stateMachine = PlayerstateMachine;
		groundData = stateMachine.player.Data.GroundedData;
	}

	public virtual void Enter()
	{
		AddInputActionsCallbacks();
	}

	public virtual void Exit()
	{
		RemoveInputActionsCallbacks();
	}

	public virtual void HandleInput()
	{
		ReadMovementInput();
	}

	public virtual void PhysicsUpdate()
	{

	}

	public virtual void Update()
	{
		Move();
	}

	private void ReadMovementInput()
	{ //�÷��̾��� ���Ͱ��� �������� �κ�
		stateMachine.MovementInput = stateMachine.player.Input.PlayerActions.Move.ReadValue<Vector2>();
	}

	private void Move()
	{
		Vector3 movementDirection = GetMovementDirection();
		Rotate(movementDirection);
		Move(movementDirection);
	}

	private void Move(Vector3 movementDirection)
	{
		float movementSpeed = GetMovementSpeed();
		stateMachine.player.Controller.Move(
			(movementDirection * movementSpeed) * Time.deltaTime);
	}

	private float GetMovementSpeed()
	{
		// ���� ���� ������ �⺻ �ӵ��� ����� ���� ���ǵ带 ���Ͽ� �̵� �ӵ��� ��ȯ
		float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
		return movementSpeed;
	}

	private void Rotate(Vector3 movementDirection)
	{
		if(movementDirection != Vector3.zero)
		{
			Transform playerTransform = stateMachine.player.transform;
			Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
			//Ȯ ���ư��� �ʰ� 0.0 �̳� 1.0��ó������ ������ Ÿ�������� 
			playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
		}
	}

	private Vector3 GetMovementDirection() // ī�޶��� �������� �̵��ϱ� ���� �ڵ�
	{
		Vector3 forward = stateMachine.MainCameraTransform.forward;
		Vector3 right = stateMachine.MainCameraTransform.right;

		forward.y = 0;
		right.y = 0;

		forward.Normalize();
		right.Normalize();

		return forward * stateMachine.MovementInput.y + right * stateMachine.MovementInput.x;
	}


	protected virtual void AddInputActionsCallbacks()
	{
		PlayerInput input = stateMachine.player.Input;
		input.PlayerActions.Move.canceled += OnMovementCanceled;
		input.PlayerActions.Run.started += OnRunStarted;
	}

	protected virtual void OnRunStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
	{
		
	}

	protected virtual void OnMovementCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
	{
		
	}

	protected virtual void RemoveInputActionsCallbacks()
	{
		PlayerInput input = stateMachine.player.Input;
		input.PlayerActions.Move.canceled -= OnMovementCanceled;
		input.PlayerActions.Run.started -= OnRunStarted;
	}

	protected void StartAnimation(int animationHash)
	{
		stateMachine.player.Animator.SetBool(animationHash, true);
	}

	protected void StopAnimation(int animationHash)
	{
		stateMachine.player.Animator.SetBool(animationHash, false);
	}
}
