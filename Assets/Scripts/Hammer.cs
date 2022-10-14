using System;
using UnityEngine;

public class Hammer : CollectableBase
{
    [SerializeField] public GameObject pickAxe;

    private void Start()
    {
        pickAxe = GameObject.Find("Pickaxe");
    }

    private void TransformHammer()
    {
        pickAxe.GetComponent<Pickaxe>().hammerMode = true;
        pickAxe.transform.Find("Top").localScale = new Vector3(0.25f, 0.25f, 0.2f);
        pickAxe.GetComponentInChildren<MeshRenderer>().material = pickAxe.GetComponent<Pickaxe>().hammerMaterial;
    }
    
    public override void Use()
    {
        TransformHammer();
    }
}