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

		if (stateMachine.player.Controller.isGrounded) //��Ʈ�ѷ��� Ground �Ǻ� ��� ����
		{
			stateMachine.ChangeState(stateMachine.idleState);
			return;
		}
	}
}
