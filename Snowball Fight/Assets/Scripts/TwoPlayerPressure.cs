using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerPressure : MonoBehaviour
{
    public GameObject doorToDeactivate;
    public GameObject explosionEffect;

    private bool player1Inside;
    private bool player2Inside;

    private AudioSource audioSource;
    public AudioSource doorAudioSource;

    private bool doorDeactivated = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on this GameObject
    }

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
        if (player1Inside && player2Inside && !doorDeactivated)
        {
            //Destroy(doorToDeactivate);
            //Instantiate(explosionEffect, transform.position, Quaternion.identity);

            Vector3 doorPosition = doorToDeactivate.transform.position;

            StartCoroutine(DeactivateAndExplode());

            PlayPressurePlateSound();

            // (explosionEffect != null)
            //{
            //    Instantiate(explosionEffect, doorToDeactivate.transform.position, Quaternion.identity);
            //}
        }
    }

    private void PlayPressurePlateSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    private IEnumerator DeactivateAndExplode()
    {
        yield return new WaitForSeconds(1.0f); // Wait for 1 second

        Destroy(doorToDeactivate);
        PlayDoorSound();
        doorDeactivated = true;

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, doorToDeactivate.transform.position, Quaternion.identity);
        }
    }

    private void PlayDoorSound()
    {
        if (doorAudioSource != null)
        {
            doorAudioSource.PlayOneShot(doorAudioSource.clip);
        }
    }
}
