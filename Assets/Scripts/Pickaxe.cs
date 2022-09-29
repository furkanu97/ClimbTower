using System;
using UnityEditor.Rendering;
using UnityEngine;
using Random = System.Random;

public class Pickaxe : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] public GameObject step;
    [HideInInspector] public bool rotate;
    [SerializeField] public int rotateSpeed;

    private void Start()
    {
        rotate = false;
    }

    private void Update()
    {
        RotateAxe();
    }

    private void RotateAxe()
    {
        if (rotate)
        {
            transform.Rotate(rotateSpeed * 100 * Time.deltaTime * Vector3.back);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Concrete"))
        {
            rotate = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (collision.gameObject.CompareTag("Holdable"))
        {
            rotate = false;
            PutStep();
        }
    }
    
    
    private void PutStep()
    {
        character.GetComponent<Rigidbody>().velocity = Vector3.zero;
        step.transform.position = transform.position - new Vector3(0.2f,0.7f,-0.2f);
        step.SetActive(true);
    }
    
    
    
    // [SerializeField] public Material hammerMaterial;
    // [SerializeField] public Material pickaxeMaterial; 
    // private bool _hammerMode;
    //
    // private void TransformHammer()
    // {
    //     ctrl.rotate = false;
    //     ctrl.ResetRotation();
    //     _hammerMode = true;
    //     transform.localScale = new Vector3(0.25f, 0.25f, 0.2f);
    //     gameObject.GetComponent<MeshRenderer>().material = hammerMaterial;
    // }
    //
    // private void TransformPickaxe()
    // {
    //     ctrl.rotate = false;
    //     ctrl.ResetRotation();
    //     _hammerMode = false;
    //     transform.localScale = new Vector3(0.3f, 0.07f, 0.05f);
    //     gameObject.GetComponent<MeshRenderer>().material = pickaxeMaterial;
    // }
    //
    //
    //
    // private void OnCollisionExit(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Concrete"))
    //     {
    //         Debug.Log("Reset!");
    //         ctrl.hammerCounter = 0;
    //     }
    //     else if (other.gameObject.CompareTag("Holdable"))
    //     {
    //         ctrl.hammerCounter++;
    //         if (ctrl.hammerCounter == 3)
    //         {
    //             TransformHammer();
    //         }
    //         Debug.Log("Counter: " + ctrl.hammerCounter);
    //     }
    // }
    //
    // private void Swing(GameObject go)
    // {
    //     go.transform.position += Vector3.right*1.1f;
    //     go.GetComponent<Rigidbody>().useGravity = true;
    // }
}
