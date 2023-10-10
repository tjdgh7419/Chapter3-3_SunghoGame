using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
	public Player player { get; }

	public PlayerIdleState idleState { get; }
	//public PlayerWalkState walkState { get; }
	//public PlayerJumpState jumpState { get; }
	//public PlayerFallState fallState { get; }
	//public PlayerRunState runState { get; }
	//public PlayerComboAttackState comboAttackState { get; }
	public Vector2 MovementInput { get; set; }
	public float MovementSpeed { get; private set; }
	public float RotationDamping { get; private set; }
	public float MovementSpeedModifier { get; set; } = 1f;
	public bool IsAttacking { get; set; }
	public int ComboIndex { get; set; }

	public float JumpForce { get; set; }

	public Transform MainCameraTransform { get; set; }

	public PlayerStateMachine(Player player)
	{
		this.player = player;

		idleState = new PlayerIdleState(this);
		//walkState = new PlayerWalkState(this);
		//runState = new PlayerRunState(this);
		//jumpState = new PlayerJumpState(this);
		//fallState = new PlayerFallState(this);
		//comboAttackState = new PlayerComboAttackState(this);
		MainCameraTransform = Camera.main.transform;

		MovementSpeed = player.Data.GroundedData.BaseSpeed;
		RotationDamping = player.Data.GroundedData.BaseRotationDamping;
	}
}
