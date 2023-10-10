using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
	public PlayerIdleState(PlayerStateMachine PlayerstateMachine) : base(PlayerstateMachine)
	{
	}
	public override void Enter()
	{
		stateMachine.MovementSpeedModifier = 0f; //가만히 있는 상태
		base.Enter();
		StartAnimation(stateMachine.player.AnimationData.IdleParameterHash);
	}

	public override void Exit()
	{
		base.Exit();
		StopAnimation(stateMachine.player.AnimationData.IdleParameterHash);
	}

	public override void Update()
	{
		base.Update();

		//if (stateMachine.MovementInput != Vector2.zero)
		//{
		//	OnMove();
		//	return;
		//}
	}
}
