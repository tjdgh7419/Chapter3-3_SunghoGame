using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundState
{
	public PlayerWalkState(PlayerStateMachine PlayerstateMachine) : base(PlayerstateMachine)
	{
	}

	public override void Enter()
	{
		// MovementSpeedModifier은 BaseState에서 쓰인다
		stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier; 
		base.Enter();
		StartAnimation(stateMachine.player.AnimationData.WalkParameterHash);
	}

	public override void Exit()
	{
		base.Exit();
		StopAnimation(stateMachine.player.AnimationData.WalkParameterHash);
	}

	protected override void OnRunStarted(InputAction.CallbackContext context)
	{
		base.OnRunStarted(context);
		stateMachine.ChangeState(stateMachine.runState);
	}
}
