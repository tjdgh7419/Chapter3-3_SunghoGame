using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
	protected PlayerStateMachine stateMachine;
	protected readonly PlayerGroundData groundData;

	public PlayerBaseState(PlayerStateMachine PlayerstateMachine)
	{
		stateMachine = PlayerstateMachine;
		groundData = stateMachine.player.Data.GroundedData;
	}

	public void Enter()
	{
		throw new System.NotImplementedException();
	}

	public void Exit()
	{
		throw new System.NotImplementedException();
	}

	public void HandleInput()
	{
		throw new System.NotImplementedException();
	}

	public void PhysicsUpdate()
	{
		throw new System.NotImplementedException();
	}

	public void Update()
	{
		throw new System.NotImplementedException();
	}
}
