using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goback : MonoBehaviour
{
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }

}
