using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
	public PlayerFallState(PlayerStateMachine PlayerstateMachine) : base(PlayerstateMachine)
	{
	}

	public override void Enter()
	{
		base.Enter();

		StartAnimation(stateMachine.player.AnimationData.fallParameterHash);
	}

	public override void Exit()
	{
		base.Exit();

		StopAnimation(stateMachine.player.AnimationData.fallParameterHash);
	}

	public override void Update()
	{
		base.Update();

		if (stateMachine.player.Controller.isGrounded) //컨트롤러는 Ground 판별 기능 제공
		{
			stateMachine.ChangeState(stateMachine.idleState);
			return;
		}
	}
}
