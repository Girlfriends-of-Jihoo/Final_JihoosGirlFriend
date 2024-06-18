using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GongScene : MonoBehaviour
{
    [SerializeField] private Animator coneAnimator;
    [SerializeField] private GameObject cone;
    [SerializeField] private Animator mapAnimator;
    [SerializeField] private Animator stampAnimator;
    [SerializeField] private GameObject mapButton;
    [SerializeField] private GameObject mapModal;
    [SerializeField] private GameObject firstChat;
    [SerializeField] private GameObject secondChat;
    [SerializeField] private ChatSystem chatSystem;
    [SerializeField] private Image[] stamp_prev;
    [SerializeField] private Image stamp;
    private bool isFirstChatStart = false;

    void Start()
    {
        InsideSceneManager.manager.isClicked = false;

        for (int i = 0; i < stamp_prev.Length; i++)
        {
            stamp_prev[i].color = new Color(255f, 255f, 255f, 1f);
        }

        if(PlayerPrefs.GetInt("Gong") == 1)
        {
            stamp.color = new Color(255f, 255f, 255f, 1f);
            stampAnimator.SetBool("isEnd", true);
        }
        else
        {
            stamp.color = new Color(255f, 255f, 255f, 0.5f);
        }
        
        if (ChatManager.manager.gong2)
        {
            mapButton.SetActive(true);
            mapAnimator.SetBool("stop", true);
            mapModal.SetActive(false);
        }
        else if (InsideSceneManager.manager.CheckIsNavigationEnd())
        {
            coneAnimator.SetBool("stop", true);
            mapButton.SetActive(true);
            mapModal.SetActive(true);
            mapAnimator.SetBool("stop", true);

            // TODO : 미션 성공 여부로 true값 바꾸기
            stampAnimator.SetBool("success", true);
        }
        else
        {
            coneAnimator.SetBool("stop", false);
        }
    }

    void Update()
    {
        if (ChatManager.manager.gong2)
        {
            cone.SetActive(false);
        }
        else if (InsideSceneManager.manager.CheckIsNavigationEnd() && stampAnimator.GetBool("isEnd"))
        {
            ChangeStampColor();
        }
        else if (InsideSceneManager.manager.isClicked)
        {
            InsideSceneManager.manager.isClicked = false;
            InsideSceneManager.manager.SetIsReached(false);
            firstChat.SetActive(false);
        }
        else if (!isFirstChatStart && InsideSceneManager.manager.CheckIsReached())
        {
            isFirstChatStart = true;
            firstChat.SetActive(true);
        }
        else if (InsideSceneManager.manager.CheckIsNavigationEnd())
        {
            firstChat.SetActive(false);
        }
    }

    private void ChangeStampColor()
    {
        stamp.color = new Color(255f, 255f, 255f, 1f); // 변경할 색상을 설정합니다.
        PlayerPrefs.SetInt("Gong", 1); // 스탬프 획득 여부를 저장합니다.

        // 1초 뒤에 chatModal 활성화
        Invoke(nameof(ShowChat), 1f);
    }

    private void ShowChat()
    {
        mapModal.SetActive(false);
        ChatManager.manager.gong2 = false;
        secondChat.SetActive(true);
        cone.SetActive(false);
    }

    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }
}
