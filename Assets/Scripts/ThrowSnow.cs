using System;
using UnityEngine;

public class ThrowSnow : CollectableBase
{
    [SerializeField] public GameObject character;
    [SerializeField] public GameObject snowball;
    [SerializeField] public int rotationSpeed;
    private bool _rotate;

    private void Start()
    {
        character = GameObject.Find("Character");
    }

    private void Update()
    {
        if (_rotate)
        {
            snowball.transform.Rotate(rotationSpeed * 100 * Time.deltaTime * Vector3.down);
        }
    }

    private void ThrowSnowBall()
    {
        Vector3 pos = character.transform.position + Vector3.right;
        snowball = Instantiate(snowball, pos, Quaternion.identity);
        _rotate = true;
        Invoke(nameof(Stop),0.5f);
        //Check if hit
    }

    private void Stop()
    {
        _rotate = false;
        Destroy(snowball);
    }
    
    public override void Use()
    {
        ThrowSnowBall();
    }
}