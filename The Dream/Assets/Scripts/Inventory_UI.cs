using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public PlayerInventory inventory;
    public List<Transform> slot;

    public void SetInventory(PlayerInventory inventory)
    {
        this.inventory = inventory;
        inventory.listChanged += Inventory_listChanged;
        RefreshItems();
    }

    public void Inventory_listChanged(object sender, System.EventArgs e)
    {
        RefreshItems();
    }

    private void RefreshItems()
    {
        for (int i = 0; i < slot.Count; i++)
        {
            Transform curr_slot = slot[i];

            Image image = curr_slot.Find("Icon").GetComponent<Image>();
            if (i < inventory.GetList().Count)
            {
                Item curr_item = inventory.GetList()[i];

                image.sprite = curr_item.icon;
                image.gameObject.SetActive(true);
            }
            else
            {
                image.gameObject.SetActive(false);
            }

        }
    }

}
