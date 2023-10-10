using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
	public PlayerGroundState(PlayerStateMachine PlayerstateMachine) : base(PlayerstateMachine)
	{
	}

	public override void Enter()
	{
		base.Enter();
		StartAnimation(stateMachine.player.AnimationData.GroundParameterHash);
	}

	public override void Exit()
	{
		base.Exit();
		StopAnimation(stateMachine.player.AnimationData.GroundParameterHash);
	}

	public override void Update()
	{
		base.Update();

		if (stateMachine.IsAttacking)
		{
			OnAttack();
			return;
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}

	protected override void OnMovementCanceled(InputAction.CallbackContext context)
	{
		if(stateMachine.MovementInput == Vector2.zero)
		{
			return;
		}
		stateMachine.ChangeState(stateMachine.idleState);
		base.OnMovementCanceled(context);
	}

	protected override void OnJumpStarted(InputAction.CallbackContext context)
	{
		stateMachine.ChangeState(stateMachine.jumpState);
	}

	protected virtual void OnMove()
	{
		stateMachine.ChangeState(stateMachine.walkState);
	}

	protected virtual void OnAttack()
	{
		stateMachine.ChangeState(stateMachine.ComboattackState);
	}

}
