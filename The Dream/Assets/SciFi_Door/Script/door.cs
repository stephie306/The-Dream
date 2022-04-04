using UnityEngine;
using System.Collections;

public class door : MonoBehaviour
{
    GameObject thedoor;

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "")
        {
            thedoor = GameObject.FindWithTag("SF_Door");
            thedoor.GetComponent<Animation>().Play("open");
        }
    }
}