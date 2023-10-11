using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
	public ItemData item;
	public GameObject UI;
	public string GetInteractPrompt()
	{
		return string.Format("Click {0}", item.itemName);
	}

	public void OnInteract()
	{
		UI.SetActive(true);
	}
}
