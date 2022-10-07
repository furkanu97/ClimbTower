using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCollectable : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] public CollectableList collectable;
    private Sprite _sprite;
    private void Start()
    {
        collectable = CollectableList.Empty;
        _sprite = GetComponentInChild<SpriteRenderer>().sprite;
    }

    private void Update()
    {
        ChangeIcon();
    }
    public void UseOnClick()
    {
        if (character.GetComponent<Hammer>())
        {
            character.GetComponent<Hammer>().Use();
        }
        else if (character.GetComponent<Bomb>())
        {
            character.GetComponent<Bomb>().Use();
        }
        else if (character.GetComponent<Nest>())
        {
            character.GetComponent<Nest>().Use();
        }
        else if (character.GetComponent<ThrowSnow>())
        {
            character.GetComponent<ThrowSnow>().Use();
        }
        else if (character.GetComponent<Shield>())
        {
            character.GetComponent<Shield>().Use();
        }
    }

    private void ChangeIcon()
    {
        if(collectable != CollectableList.Empty){}
        //GetChild(0).GetComponent<Image>().sprite = Resources.Load <Sprite>(collectable.ToString());
    }
}
