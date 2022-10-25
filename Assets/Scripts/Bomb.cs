using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Bomb : CollectableBase
{
    [SerializeField] public GameObject character;
    [SerializeField] public GameObject explosive;
    [SerializeField] public GameObject particle;
    private Vector3 _pos;
    private GameObject _bomb;
    private GameObject[] _particles;
    private void Start()
    {
        character = GameObject.Find("Character");
        _particles = new GameObject[4];
    }
    
    private void PlantBomb()
    {
        _pos = character.transform.position + new Vector3(1.5f, 0, -0.5f);
        Quaternion rot = new Quaternion(0, 0, -0.25f, 1);
        _bomb = Instantiate(explosive, _pos,rot);
        Invoke(nameof(Explosion),2f);
    }

    private void Explosion()
    {
        Destroy(_bomb);
        _pos += new Vector3(0, 0, 0.5f);
        for (var i = 0; i < 4; i++)
        {
            _particles[i] = Instantiate(particle, _pos + i * 0.1f *  Vector3.right, Quaternion.identity);
            _particles[i].GetComponent<Rigidbody>().AddForce(1f,0.3f,i*0.3f);
        }
        foreach (var p in _particles)
        {
            Destroy(p, 2f);
        }
    }
    
    public override void Use()
    {
        PlantBomb();
    }
}