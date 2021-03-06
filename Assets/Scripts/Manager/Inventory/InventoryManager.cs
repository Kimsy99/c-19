﻿using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Reponsible for the storing of actual items and updating the inventory UI. Can handle item adding and removal.
/// </summary>
public class InventoryManager : Singleton<InventoryManager>
{
	/** Items in inventory. */
	private readonly Weapon[] weapons = new Weapon[5];
	private readonly Dictionary<int, InventorySlot> slotDictionary = new Dictionary<int, InventorySlot>();

	private RectTransform slot0, slot1, slot2, slot3, slot4;
	private RectTransform activeSlot;
	private TextMeshProUGUI weaponLabel;

	private int activeSlotIndex = 0;
	public Action<int> OnActiveSlotIndexChanged;

	public int ActiveSlotIndex
	{
		get => activeSlotIndex;
		set
		{
			activeSlotIndex = value;
			activeSlot.anchoredPosition = ((RectTransform)slotDictionary[value].gameObject.transform).anchoredPosition;
			AudioManager.Instance.Play(AudioEnum.KenSelect);
			OnActiveSlotIndexChanged?.Invoke(value);
		}
	}

	protected override void Awake()
	{
		slot0 = (RectTransform)GameObject.Find("InventorySlot0").transform;
		slot1 = (RectTransform)GameObject.Find("InventorySlot1").transform;
		slot2 = (RectTransform)GameObject.Find("InventorySlot2").transform;
		slot3 = (RectTransform)GameObject.Find("InventorySlot3").transform;
		slot4 = (RectTransform)GameObject.Find("InventorySlot4").transform;
		activeSlot = (RectTransform)GameObject.Find("ActiveInventorySlot").transform;
		weaponLabel = GameObject.Find("WeaponLabel").GetComponent<TextMeshProUGUI>();

		slotDictionary.Add(0, slot0.GetComponent<InventorySlot>());
		slotDictionary.Add(1, slot1.GetComponent<InventorySlot>());
		slotDictionary.Add(2, slot2.GetComponent<InventorySlot>());
		slotDictionary.Add(3, slot3.GetComponent<InventorySlot>());
		slotDictionary.Add(4, slot4.GetComponent<InventorySlot>());

		OnActiveSlotIndexChanged += UpdateWeaponLabel;
	}

	void Update()
	{
		// Switch inventory slot with number keys
		if (Input.GetKeyDown(KeyCode.Alpha1))
			ActiveSlotIndex = 0;
		else if (Input.GetKeyDown(KeyCode.Alpha2))
			ActiveSlotIndex = 1;
		else if (Input.GetKeyDown(KeyCode.Alpha3))
			ActiveSlotIndex = 2;
		else if (Input.GetKeyDown(KeyCode.Alpha4))
			ActiveSlotIndex = 3;
		else if (Input.GetKeyDown(KeyCode.Alpha5))
			ActiveSlotIndex = 4;

		// Switch inventory slot with scroll wheel
		if (Input.mouseScrollDelta.y < 0)
			ActiveSlotIndex = (ActiveSlotIndex + 1) % 5;
		else if (Input.mouseScrollDelta.y > 0)
			ActiveSlotIndex = (ActiveSlotIndex + 4) % 5;
	}

	public Weapon GetWeapon(int index)
	{
		return weapons[index];
	}

	public void SetWeapon(int index, Weapon weapon)
	{
		weapons[index] = weapon; // Add the item
		BindInventorySlot(slotDictionary[index], weapon);
	}

	/// <summary>
	/// Adds a weapon to the inventory by finding an empty slot. If the inventory slot is full, then the
	/// current active slot will be replaced with the new weapon.
	/// </summary>
	/// <param name="weapon">the new weapon</param>
	/// <returns>If the inventory is full, the old weapon that got replaced is returned.</returns>
	public Weapon AddWeapon(Weapon weapon)
	{
		for (int i = 0; i < weapons.Length; i++)
		{
			if (weapons[i] == null) // Is the slot empty?
			{
				SetWeapon(i, weapon);
				ActiveSlotIndex = i;
				return null;
			}
		}
		Weapon oldWeapon = weapons[ActiveSlotIndex];
		SetWeapon(ActiveSlotIndex, weapon);
		OnActiveSlotIndexChanged?.Invoke(ActiveSlotIndex);
		return oldWeapon;
	}

	/// <summary>
	/// Removes a specific item from the inventory.
	/// </summary>
	/// <param name="index">index of the item</param>
	public void RemoveWeapon(int index)
	{
		SetWeapon(index, null);
	}

	private void BindInventorySlot(InventorySlot slot, Weapon weapon)
	{
		slot.Weapon = weapon;
		if (weapon != null)
			weapon.inventorySlot = slot;
	}

	private void UpdateWeaponLabel(int index)
	{
		CancelInvoke(nameof(HideWeaponLabel));
		Weapon weapon = weapons[index];
		weaponLabel.text = weapon?.weaponSettings.displayName ?? "";
		Invoke(nameof(HideWeaponLabel), 2);
	}

	private void HideWeaponLabel()
	{
		weaponLabel.text = "";
	}
}
