using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public PlayerInputAction InputActions { get; private set; }
	public PlayerInputAction.PlayerActions PlayerActions { get; private set; }

	private void Awake()
	{
		InputActions = new PlayerInputAction();

		PlayerActions = InputActions.Player;
	}

	// 캐릭터와 관련된 변화가 일어났을 때 대비
	private void OnEnable()
	{
		InputActions.Enable();
	}

	private void OnDisable()
	{
		InputActions.Disable();
	}
}
