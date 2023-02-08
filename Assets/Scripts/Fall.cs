using UnityEngine;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var character = other.gameObject.GetComponent<Character>();
            if (!character.shieldActive)
            {
                character.Fall(2f);
            }
        }
    }
}
