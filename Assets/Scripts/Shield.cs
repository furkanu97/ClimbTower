using System;
using UnityEngine;

public class Shield : CollectableBase
{
    [SerializeField] public GameObject character;

    private void Start()
    {
        character = GameObject.Find("Character");
    }

    private void ActivateShield()
    {
        character.transform.Find("Protection").gameObject.SetActive(true);
        character.GetComponent<Character>().shieldActive = true;
        Invoke(nameof(DeactivateShield),3f);
    }
    
    private void DeactivateShield()
    {
        character.transform.Find("Protection").gameObject.SetActive(false);
        character.GetComponent<Character>().shieldActive = false;
    }
    
    public override void Use()
    {
        ActivateShield();
    }
}