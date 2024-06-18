using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationTrigger : MonoBehaviour
{
    public string nextSceneName;
    public float delayBeforeLoadingScene = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);
        if (other.gameObject.name == "Sphere")
        {
            Debug.Log("Sphere has entered the trigger zone");
            StartCoroutine(LoadSceneAfterDelay(nextSceneName, delayBeforeLoadingScene));
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
