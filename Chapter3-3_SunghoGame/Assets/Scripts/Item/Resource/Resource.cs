using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Resource : MonoBehaviour
{
	public ItemData itemToGive;
	public int quantityPerHit = 1;

	public int capacity;

	public void Gather()
	{
		
		for (int i = 0; i < quantityPerHit; i++)
		{
			Debug.Log("게더 진입");
			if (capacity <= 0)
			{
				break;
			}
			
			capacity -= 1;
			GameManager.Instance.inventory.AddItem(itemToGive);	
		}

		//if (capacity <= 0)
		//{
		//	gameObject.SetActive(false);		
		//}

	}
}
