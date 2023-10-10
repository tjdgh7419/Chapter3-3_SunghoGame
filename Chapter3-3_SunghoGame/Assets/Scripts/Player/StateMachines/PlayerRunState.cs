using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundState
{
	public PlayerRunState(PlayerStateMachine PlayerstateMachine) : base(PlayerstateMachine)
	{
	}

	public override void Enter()
	{
		stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
		base.Enter();
		StartAnimation(stateMachine.player.AnimationData.RunParameterHash);
	}

	public override void Exit()
	{
		base.Exit();
		StopAnimation(stateMachine.player.AnimationData.RunParameterHash);
	}
}
