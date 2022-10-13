using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class UseCollectable : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] public List<Sprite> sprites;
    private Sprite _sprite;
    private SpriteRenderer _mSpriteRenderer;
    private void Start()
    {
        _mSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
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

    public void ChangeIcon(CollectableList collectable)
    {
        if (collectable != CollectableList.Empty)
        {
            _sprite = sprites.Find(sp => sp.name == collectable.ToString());
            Debug.Log("Name: " + _sprite.name);
            _mSpriteRenderer.sprite = _sprite;
        }
    }
}
