using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    public string nextLevelName;
    public float delayBeforeLoad = 2.0f;

    private bool player1Inside;
    private bool player2Inside;

    public GameObject escapeUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1Inside = true;
            TryLoadNextLevel();
        }
        else if (other.CompareTag("Player2"))
        {
            player2Inside = true;
            TryLoadNextLevel();
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

    private void TryLoadNextLevel()
    {
        if (player1Inside && player2Inside)
        {
            StartCoroutine(LoadNextLevelWithDelay());
        }
    }

    private IEnumerator LoadNextLevelWithDelay()
    {
        escapeUI.SetActive(true);
        
        yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(nextLevelName);
    }
}
