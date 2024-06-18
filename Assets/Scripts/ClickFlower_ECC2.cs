using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickFlower_ECC2 : MonoBehaviour
{
    public void SceneChange()
    {
        StartCoroutine(ChangeSceneWithDelay());
    }

    private IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(2.0f);

        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "AR_ECC1")
        {
            SceneManager.LoadScene("inside_ECC_B4");
        }
        else if (currentSceneName == "AR_ECC2")
        {
            SceneManager.LoadScene("inside_ECC");
        }
        else if (currentSceneName == "AR_ENG")
        {
            SceneManager.LoadScene("inside_GONG_SIN_B2");
        }
        else if (currentSceneName == "AR_Library")
        {
            SceneManager.LoadScene("inside_Library");
        }
    }
}
