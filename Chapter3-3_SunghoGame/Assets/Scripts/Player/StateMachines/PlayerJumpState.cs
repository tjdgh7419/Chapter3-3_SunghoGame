using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
	public PlayerJumpState(PlayerStateMachine PlayerstateMachine) : base(PlayerstateMachine)
	{
	}
	public override void Enter()
	{
		stateMachine.JumpForce = stateMachine.player.Data.AirData.JumpForce;
		stateMachine.player.ForceReceiver.Jump(stateMachine.JumpForce);

		base.Enter();

		StartAnimation(stateMachine.player.AnimationData.JumpParameterHash);
	}

	public override void Exit()
	{
		base.Exit();

		StopAnimation(stateMachine.player.AnimationData.JumpParameterHash);
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();

		if (stateMachine.player.Controller.velocity.y <= 0) // 점프에서 떨어지는 시점
		{
			stateMachine.ChangeState(stateMachine.fallState);
			return;
		}
	}
}
