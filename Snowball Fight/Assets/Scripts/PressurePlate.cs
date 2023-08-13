using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject doorToDeactivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {

            Debug.Log("player1 stood on pressure plate");
            if (doorToDeactivate != null)
            {
                Destroy(doorToDeactivate);
            }
        }

        if (collision.CompareTag("Player2"))
        {
            Debug.Log("player2 stood on pressure plate");
            if (doorToDeactivate != null)
            {
                Destroy(doorToDeactivate);
            }
        }
    }
}