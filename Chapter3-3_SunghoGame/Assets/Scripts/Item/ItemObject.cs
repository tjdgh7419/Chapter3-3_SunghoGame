using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
	public ItemData item;
	public GameObject UI;
	public string GetInteractPrompt()
	{
		return string.Format("{0}", item.itemName);
	}

	public void OnInteract()
	{
		if (UI.activeInHierarchy)
		{
			GameManager.Instance.inventory.OffUI();
			UI.SetActive(false);
		}
		else
		{
			GameManager.Instance.inventory.OnUI();
			UI.SetActive(true);
		}
	}

	public void ExitBtn()
	{
		GameManager.Instance.inventory.OffUI();
		UI.SetActive(false);
	}
}
