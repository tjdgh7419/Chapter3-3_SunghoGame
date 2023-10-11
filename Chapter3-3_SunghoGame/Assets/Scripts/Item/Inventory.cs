using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
	public GameObject inventoryWindow;
	public PlayerInput input;
	private void Awake()
	{
		input.PlayerActions.Inventory.started += OnToggle;
	}

	public void OnToggle(InputAction.CallbackContext context)
	{
		if (inventoryWindow.activeInHierarchy)
		{
			inventoryWindow.SetActive(false);
		}
		else
		{
			inventoryWindow.SetActive(true);
		}
	}
}
