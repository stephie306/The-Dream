using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRock : MonoBehaviour
{
    public string id;
    public Material other_material;
    MeshRenderer my_renderer;
    private Material startMaterial;
    public bool active;
    public RocksRow row;

    void Start()
    {
        my_renderer = GetComponent<MeshRenderer>();
        startMaterial = my_renderer.material;
        active = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !row.active)
        {
            row.setActiveRock(id);
            active = true;
            my_renderer.material = other_material;

        }
    }

    public void restartRocks()
    {
        my_renderer.material = startMaterial;
        active = false;
        row.active = false;
        row.forRestart = false;
    }

}
