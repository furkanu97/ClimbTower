using UnityEngine;

public class Bomb : CollectableBase
{
    [SerializeField] public GameObject character;
    [SerializeField] public GameObject explosive;

    private void Start()
    {
        character = GameObject.Find("Character");
    }
    
    private void PlantBomb()
    {
        Vector3 pos = character.transform.position + new Vector3(1.5f, 0, -0.5f);
        Quaternion rot = new Quaternion(0, 0, -0.25f, 1);
        Instantiate(explosive, pos,rot);
        Invoke(nameof(Explosion),2f);
    }

    private void Explosion()
    {
        Debug.Log("BOM!!");
        //Make character fall if it is around explosion
    }
    
    public override void Use()
    {
        PlantBomb();
    }
}