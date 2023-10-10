using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
