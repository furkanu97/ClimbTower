using System;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField] public Control ctrl;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Concrete"))
        {
            ctrl.rotate = false;
            ctrl.ResetRotation();
        }
        else if (collision.gameObject.CompareTag("Holdable"))
        {
            ctrl.rotate = false;
            ctrl.PutStep();
        }
    }
}
