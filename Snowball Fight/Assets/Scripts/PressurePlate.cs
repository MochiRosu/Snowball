using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject doorToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {

            Debug.Log("stood on pressure plate");
            //if (doorToDeactivate != null)
            //{
                Destroy(doorToDeactivate);
            //}
        }
    }
}