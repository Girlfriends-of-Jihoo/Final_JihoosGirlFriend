using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pear_SetActive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pear;

    public void GameobjectAble()
    {
        SetNavigateEnd();
        Pear.SetActive(true);
        Debug.Log("È°¼ºÈ­");
    }

    private void SetNavigateEnd()
    {
        if(SceneManager.GetActiveScene().name == "AR_ECC1")
        {
            InsideSceneManager.manager.starbucks = true;
        }
        else if(SceneManager.GetActiveScene().name == "AR_ECC2")
        {
            InsideSceneManager.manager.ecc_stairs = true;
        }
        else if(SceneManager.GetActiveScene().name == "AR_Library")
        {
            InsideSceneManager.manager.library = true;
        }
        else if (SceneManager.GetActiveScene().name == "AR_ENG")
        {
            InsideSceneManager.manager.gong_b2 = true;
        }
    }
}
