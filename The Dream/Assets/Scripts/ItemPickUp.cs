using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item data;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerInventory>().addItem(data);
            Destroy(gameObject);
        }
    }

}
