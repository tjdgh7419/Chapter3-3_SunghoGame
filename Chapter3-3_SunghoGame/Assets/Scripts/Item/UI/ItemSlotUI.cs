using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityTxt;
    private ItemSlot curSlot;
    private Outline outline;

    public int index;

	private void Awake()
	{
		outline = GetComponent<Outline>();
	}

	public void Clear()
	{
		curSlot = null;
		icon.gameObject.SetActive(false);
		quantityTxt.text = string.Empty;
	}

	public void Set(ItemSlot itemSlot)
	{
		curSlot = itemSlot;
		icon.gameObject.SetActive(true);
		icon.sprite = itemSlot.item.icon;
		quantityTxt.text = itemSlot.quantity > 1 ? itemSlot.quantity.ToString() : string.Empty;
	}

	public void OnButtonClick()
	{
		GameManager.Instance.inventory.SelectItem(index);
	}
}
