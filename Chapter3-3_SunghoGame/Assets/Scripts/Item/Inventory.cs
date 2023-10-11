using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ItemSlot
{
	public ItemData item;
	public int quantity;
}
public class Inventory : MonoBehaviour
{
	public GameObject inventoryWindow;
	public ItemSlotUI[] uiSlot;
	public ItemSlot[] slots;

	[Header("Selected Item")]
	private ItemSlot selectedItem;
	private int selectedItemIndex;
	public TextMeshProUGUI selectedItemName;
	public TextMeshProUGUI selectedItemDescription;
	public GameObject useButton;
	public GameObject dropButton;
	private PlayerInput input;
	private Dictionary<ItemData, int> ItemTotalCount;
	private void Awake()
	{
		input = GameManager.Instance.input;
		input.PlayerActions.Inventory.started += OnInventoryButton;
		ItemTotalCount = new Dictionary<ItemData, int>();
	}

	private void Start()
	{
		
		GameManager.Instance.inventory = this;
		inventoryWindow.SetActive(false);

		slots = new ItemSlot[uiSlot.Length];

		for(int i = 0; i <slots.Length; i++)
		{
			slots[i] = new ItemSlot();
			uiSlot[i].index = i;
			uiSlot[i].Clear();
		}
		ClearSelectedItemWindow();
	}

	public void OnInventoryButton(InputAction.CallbackContext callbackContext)
	{
		if (callbackContext.phase == InputActionPhase.Started)
		{
			Toggle();
		}
	}
	public void Toggle()
	{
		if (inventoryWindow.activeInHierarchy)
		{
			OffUI();	
			inventoryWindow.SetActive(false);		
		}
		else
		{
			OnUI();
			inventoryWindow.SetActive(true);		
		}
	}

	public void OnUI()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		input.PlayerActions.Attack.Disable();
	}

	public void OffUI()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		input.PlayerActions.Attack.Enable();
	}

	public void AddItem(ItemData item)
	{
		if (item.canStack)
		{
			ItemSlot slotToStakTo = GetItemStack(item);
			if (slotToStakTo != null)
			{
				slotToStakTo.quantity++;
				UpdateUI();
				return;
			}
		}

		ItemSlot emptySlot = GetEmptySlot();

		if(emptySlot != null)
		{
			emptySlot.item = item;
			emptySlot.quantity = 1;
			UpdateUI();
			return;
		}
	}

	private ItemSlot GetEmptySlot()
	{
		for(int i = 0; i < slots.Length; i++)
		{
			if (slots[i].item == null)
				return slots[i];
		}
		return null;
	}

	public ItemSlot GetItemStack(ItemData item)
	{
		for(int i = 0; i < slots.Length; i++)
		{
			if (slots[i].item == item && slots[i].quantity < item.maxStackAmount)
			{
				return slots[i];
			}			
		}
		return null;
	}

	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].item != null)
				uiSlot[i].Set(slots[i]);
			else
				uiSlot[i].Clear();
		}
	}

	public void SelectItem(int index)
	{
		if (slots[index].item == null)
			return;

		selectedItem = slots[index];
		selectedItemIndex = index;

		selectedItemName.text = selectedItem.item.itemName;
		selectedItemDescription.text = selectedItem.item.description;

		useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
		dropButton.SetActive(true);
	}
	private void ClearSelectedItemWindow()
	{
		selectedItem = null;
		selectedItemName.text = string.Empty;
		selectedItemDescription.text = string.Empty;

		dropButton.SetActive(false);
		useButton.SetActive(false);		
	}
	public void OnDropButton()
	{
		RemoveSelectedItem();
	}

	private void RemoveSelectedItem() //use
	{
		selectedItem.quantity--;

		if (selectedItem.quantity <= 0)
		{
			selectedItem.item = null;
			ClearSelectedItemWindow();
		}
		UpdateUI();
	}
}
