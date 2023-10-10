using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
	public PlayerAirState(PlayerStateMachine PlayerstateMachine) : base(PlayerstateMachine)
	{
	}

	public override void Enter()
	{
		base.Enter();
		StartAnimation(stateMachine.player.AnimationData.AirParameterHash);
	}
	public override void Exit()
	{
		base.Exit();
		StopAnimation(stateMachine.player.AnimationData.AirParameterHash);
	}
}
