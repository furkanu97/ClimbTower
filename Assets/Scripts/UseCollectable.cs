using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UseCollectable : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] public List<Sprite> sprites;
    private Sprite _sprite;
    private Transform _child;
    private Image _image;
    private void Start()
    {
        _child = transform.Find("Feature");
        _image = _child.gameObject.GetComponent<Image>();
    }
    public void UseOnClick()
    {
        if (character.GetComponent<Hammer>())
        {
            character.GetComponent<Hammer>().Use();
            _image.sprite = null;
            _image.color = Color.red;
        }
        else if (character.GetComponent<Bomb>())
        {
            character.GetComponent<Bomb>().Use();
            _image.sprite = null;
            _image.color = Color.red;
        }
        else if (character.GetComponent<Nest>())
        {
            character.GetComponent<Nest>().Use();
            _image.sprite = null;
            _image.color = Color.red;
        }
        else if (character.GetComponent<ThrowSnow>())
        {
            character.GetComponent<ThrowSnow>().Use();
            _image.sprite = null;
            _image.color = Color.red;
        }
        else if (character.GetComponent<Shield>())
        {
            character.GetComponent<Shield>().Use();
            _image.sprite = null;
            _image.color = Color.red;
        }
    }

    public void ChangeIcon(CollectableList collectable)
    {
        if (collectable != CollectableList.Empty)
        {
            _sprite = sprites.Find(sp => sp.name == collectable.ToString());
            Debug.Log("Name: " + _sprite.name);
            _image.sprite = _sprite;
            _image.color = Color.white;
        }
    }
}
