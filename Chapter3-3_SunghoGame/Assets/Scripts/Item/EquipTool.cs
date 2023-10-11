using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : Equip
{
	[Header("Resource Gathering")]
	public bool doesGatherResources;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Resource")
		{
			Resource resource = other.gameObject.GetComponent<Resource>();
			resource.Gather();
		}
	}

	//private void OnCollisionExit(Collision collision)
	//{
	//	if(collision.gameObject.tag == "Resource")
	//	{
	//		Debug.Log("�浹");
	//		Resource resource = collision.gameObject.GetComponent<Resource>();
	//		resource.Gather();
	//	}
	//}
}
