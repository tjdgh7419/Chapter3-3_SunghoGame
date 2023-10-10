using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
	{ //플레이어의 벡터값을 가져오는 부분
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
		//이동하는 값과 ForceReceiver의 힘을 더해서 시간을 곱해준다.
		stateMachine.player.Controller.Move(
			((movementDirection * movementSpeed) + stateMachine.player.ForceReceiver.Movement) 
			* Time.deltaTime);
	}

	protected void ForceMove()
	{
		stateMachine.player.Controller.Move(stateMachine.player.ForceReceiver.Movement * Time.deltaTime);
	}

	private float GetMovementSpeed()
	{
		// 현재 내가 설정한 기본 속도에 사용자 설정 스피드를 곱하여 이동 속도를 반환
		float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
		return movementSpeed;
	}

	private void Rotate(Vector3 movementDirection)
	{
		if(movementDirection != Vector3.zero)
		{
			Transform playerTransform = stateMachine.player.transform;
			Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
			//확 돌아가지 않게 0.0 이나 1.0근처에서는 느리게 타원형으로 
			playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
		}
	}

	private Vector3 GetMovementDirection() // 카메라의 방향으로 이동하기 위한 코드
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
		input.PlayerActions.Move.canceled += OnMovementCanceled; //실제로 움직이는 부분
		input.PlayerActions.Run.started += OnRunStarted;
		input.PlayerActions.Jump.started += OnJumpStarted;
		
		input.PlayerActions.Attack.performed += OnAttackPerformed;
		input.PlayerActions.Attack.canceled += OnAttackCanceled;
	}

	protected virtual void RemoveInputActionsCallbacks()
	{
		PlayerInput input = stateMachine.player.Input;
		input.PlayerActions.Move.canceled -= OnMovementCanceled;
		input.PlayerActions.Run.started -= OnRunStarted;
		input.PlayerActions.Jump.started -= OnJumpStarted;
		input.PlayerActions.Attack.performed -= OnAttackPerformed;
		input.PlayerActions.Attack.canceled -= OnAttackCanceled;
	}

	protected virtual void OnRunStarted(InputAction.CallbackContext context)
	{
		
	}

	protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
	{
		
	}
	protected virtual void OnJumpStarted(InputAction.CallbackContext context)
	{

	}
	protected virtual void OnAttackPerformed(InputAction.CallbackContext obj)
	{
		stateMachine.IsAttacking = true;
	}

	protected virtual void OnAttackCanceled(InputAction.CallbackContext obj)
	{
		stateMachine.IsAttacking = false;
	}


	protected void StartAnimation(int animationHash)
	{
		stateMachine.player.Animator.SetBool(animationHash, true);
	}

	protected void StopAnimation(int animationHash)
	{
		stateMachine.player.Animator.SetBool(animationHash, false);
	}
	protected float GetNormalizedTime(Animator animator, string tag)
	{
		AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
		AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

		if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
		{
			return nextInfo.normalizedTime;
		}
		else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
		{
			return currentInfo.normalizedTime;
		}
		else
		{
			return 0f;
		}

	}
}
