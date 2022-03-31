using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string id;
    public string iname;
    public Sprite icon;
    public GameObject prefab;

}
