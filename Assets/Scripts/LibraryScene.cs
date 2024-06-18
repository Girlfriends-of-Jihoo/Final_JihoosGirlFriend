using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LibraryScene : MonoBehaviour
{
    [SerializeField] private Animator mapAnimator;
    [SerializeField] private GameObject modal;
    [SerializeField] private GameObject mapButton;
    [SerializeField] private ChatSystem chatSystem;

    void Update()
    {
        if (!chatSystem.isDialogue)
        {
        modal.SetActive(true);
        mapButton.SetActive(true);
        mapAnimator.SetBool("stop", true);
        }
    }

    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }
}
