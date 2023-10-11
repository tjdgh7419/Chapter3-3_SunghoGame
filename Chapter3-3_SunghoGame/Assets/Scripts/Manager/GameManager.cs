using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private GameObject player;
	public ConditionManager conditionManager;
	public UIManager uiManager;
	public Inventory inventory;

	

	private void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
	}

	private void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	public GameObject GetPlayer()
	{
		if (!player)
			player = GameObject.FindWithTag("Player");
		return player;
	}
}
