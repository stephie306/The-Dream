using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventory;
    public event EventHandler listChanged;
    public Inventory_UI inventoryUI;

    void Start()
    {
        inventoryUI.SetInventory(this);
    }

    void Update()
    {
        slotsInput();
    }


    public void addItem(Item item)
    {
        inventory.Add(item);
        listChanged?.Invoke(this, EventArgs.Empty);
    }

    public void removeItem(Item item)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        Instantiate(item.prefab, position, Quaternion.identity);
        inventory.Remove(item);
        listChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetList()
    {
        return inventory;
    }

    void slotsInput()
    {
        if (Input.GetButtonDown("Slot1"))
        {
            if (inventory.Count > 0)
            {
                removeItem(inventory[0]);
            }
            else
            {
                Debug.Log("Error");
            }
        }
        if (Input.GetButtonDown("Slot2"))
        {
            if (inventory.Count > 1)
            {
                removeItem(inventory[1]);
            }
            else
            {
                Debug.Log("Error");
            }
        }
        if (Input.GetButtonDown("Slot3"))
        {
            if (inventory.Count > 2)
            {
                removeItem(inventory[2]);
            }
            else
            {
                Debug.Log("Error");
            }
        }
        if (Input.GetButtonDown("Slot4"))
        {
            if (inventory.Count > 3)
            {
                removeItem(inventory[3]);
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }

}
