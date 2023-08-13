using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
    public SpriteRenderer fadeImage;
    public float fadeDuration = 1.0f;
    private bool transitioning;

    private void Start()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 1f); // Start with black overlay
        StartCoroutine(FadeIn());
    }

    public void TransitionToNextScene(string sceneName)
    {
        if (!transitioning)
        {
            StartCoroutine(Transition(sceneName));
        }
    }

    private IEnumerator Transition(string sceneName)
    {
        transitioning = true;
        yield return StartCoroutine(FadeOut());

        SceneManager.LoadScene(sceneName);

        yield return StartCoroutine(FadeIn());
        transitioning = false;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(0f, 0f, 0f, 0f);
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(0f, 0f, 0f, 1f);
    }
}
