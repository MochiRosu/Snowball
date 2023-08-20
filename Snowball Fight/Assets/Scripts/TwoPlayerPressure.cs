using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerPressure : MonoBehaviour
{
    public GameObject doorToDeactivate;
    public GameObject explosionEffect;

    private bool player1Inside;
    private bool player2Inside;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1Inside = true;
            TryOpenDoor();
        }
        else if (other.CompareTag("Player2"))
        {
            player2Inside = true;
            TryOpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1Inside = false;
        }
        else if (other.CompareTag("Player2"))
        {
            player2Inside = false;
        }
    }

    private void TryOpenDoor()
    {
        if (player1Inside && player2Inside)
        {
            Debug.Log("both players on pressure plate");
            if (doorToDeactivate != null)
            {
                Destroy(doorToDeactivate);
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }
        }
    }
}
