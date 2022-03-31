using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScrollOpen : MonoBehaviour
{
    public Item data;
    public Transform message;
    public Text scrollTextUI;

    void OnCollisionEnter(Collision collision)
    {
        Image image = message.Find("Image").GetComponent<Image>();
        if (collision.gameObject.tag == "Player" && data.iname == "Scroll")
        {
            image.gameObject.SetActive(true);
            scrollTextUI.gameObject.SetActive(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Image image = message.Find("Image").GetComponent<Image>();
        if (collision.gameObject.tag == "Player" && data.iname == "Scroll")
        {
            image.gameObject.SetActive(false);
            scrollTextUI.gameObject.SetActive(false);
        }
    }
}
