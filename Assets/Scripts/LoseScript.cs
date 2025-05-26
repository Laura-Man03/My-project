using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void StartFade()
    {
        StartCoroutine(FadeInOutRoutine());
    }

    private IEnumerator FadeInOutRoutine()
    {
        float duration = 0.5f;
        float time = 0;

        yield return new WaitForSeconds(1);
        // Fade in
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = time / duration;
            yield return null;
        }

        yield return new WaitForSeconds(1);
        // Fade out
        while (time > 0)
        {
            time -= Time.deltaTime;
            canvasGroup.alpha = time / duration;
            yield return null;
        }

        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("OverWhelmed");
    }
}
