using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueUI; // Assign your UI GameObject in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            dialogueUI.SetActive(true);
        }
        if (collision.CompareTag("Player2"))
        {
            dialogueUI.SetActive(true);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player1"))
    //    {
    //        dialogueUI.SetActive(false);
    //    }
    //}
}
