using UnityEngine;

public class Nest : CollectableBase
{
    [SerializeField] public GameObject character;
    [SerializeField] public GameObject bird;
    private Vector3 _pos;
    private GameObject[] _birds;
    private void Start()
    {
        character = GameObject.Find("Character");
        _birds = new GameObject[4];
    }

    private void ReleaseBirds()
    {
        _pos += character.transform.position;
        for (var i = 0; i < 4; i++)
        {
            _birds[i] = Instantiate(bird, _pos + i * 0.1f *  Vector3.right, Quaternion.identity);
            _birds[i].GetComponent<Rigidbody>().AddForce(1f,0.3f,i*0.3f);
        }
        foreach (var b in _birds)
        {
            Destroy(b, 5f);
        }
    }
    
    public override void Use()
    {
        ReleaseBirds();
    }
}