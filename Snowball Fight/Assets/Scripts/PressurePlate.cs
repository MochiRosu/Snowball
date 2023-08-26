using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject doorToDeactivate;
    public GameObject explosionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {

            Debug.Log("player1 stood on pressure plate");
            if (doorToDeactivate != null)
            {
                Destroy(doorToDeactivate);
                //Instantiate(explosionEffect, transform.position, Quaternion.identity);

                Vector3 doorPosition = doorToDeactivate.transform.position;

                if (explosionEffect != null)
                {
                    Instantiate(explosionEffect, doorToDeactivate.transform.position, Quaternion.identity);
                }
            }
        }

        if (collision.CompareTag("Player2"))
        {
            Debug.Log("player2 stood on pressure plate");
            if (doorToDeactivate != null)
            {
                Destroy(doorToDeactivate);
                //Instantiate(explosionEffect, transform.position, Quaternion.identity);

                Vector3 doorPosition = doorToDeactivate.transform.position;

                if (explosionEffect != null)
                {
                    Instantiate(explosionEffect, doorToDeactivate.transform.position, Quaternion.identity);
                }
            }
        }
    }
}