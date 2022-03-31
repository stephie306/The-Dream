using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject alienMushroom;
    [SerializeField]
    private Collider stumpCollider;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Stump")
        {
            PlayerInventory inv = (PlayerInventory)collision.gameObject.GetComponent<PlayerInventory>();
            foreach (Item item in inv.inventory)
            {
                if (item.iname == "Mushroom Red")
                {
                    inv.inventory.Remove(item);
                    inv.inventoryUI.Inventory_listChanged(this, System.EventArgs.Empty);
                    stumpCollider.enabled = false;
                    alienMushroom.gameObject.SetActive(true);
                    break;
                }
            }

        }
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            PlayerInventory inv = (PlayerInventory)collision.gameObject.GetComponent<PlayerInventory>();
            alienMushroom.gameObject.SetActive(true);
        }
    }
}

