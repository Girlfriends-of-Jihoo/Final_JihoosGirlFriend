using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea] public string sentences;
    public Sprite image;
    public bool isNPC;
}

public class ChatSystem : MonoBehaviour
{
    [SerializeField] public Dialogue[] dialogues;
    [SerializeField] private GameObject npcDialogue;
    [SerializeField] private GameObject userDialogue;
    [SerializeField] private Button mapButton;
    [SerializeField] private string diaglogueKey;

    public bool isDialogue = false;
    private int cnt = 0;
    private string MAIN = "1_Main";
    private string ECC = "ECC";

    public void ShowDialogue()
    {
        // 대화 시작
        OnOff(true);
        cnt = 0;
        NextDialogue();
    }

    private void OnOff(bool flag)
    {
        npcDialogue.SetActive(false);
        userDialogue.SetActive(false);

        isDialogue = flag;
    }

    private void NextDialogue()
    {
        if (cnt >= dialogues.Length)
        {
            OnOff(false);
            SetChatManager();
            mapButton.gameObject.SetActive(true);
            return;
        }

        Dialogue currentDialogue = dialogues[cnt];
        Transform[] dialogueChildren;
        if (currentDialogue.isNPC)
        {
            // NPC 대화일 경우
            npcDialogue.SetActive(true);
            userDialogue.SetActive(false);

            // npcDialogue 오브젝트의 자식 오브젝트들을 가져옴
            dialogueChildren = npcDialogue.GetComponentsInChildren<Transform>(true);
        }
        else
        {
            // 사용자 대화일 경우
            npcDialogue.SetActive(false);
            userDialogue.SetActive(true);

            // userDialogue 오브젝트의 자식 오브젝트들을 가져옴
            dialogueChildren = userDialogue.GetComponentsInChildren<Transform>(true);
        }

        // 가져온 자식 오브젝트들 중에서 Name, TextBox, Character를 찾아서 값을 대응시킴
        foreach (Transform child in dialogueChildren)
        {
            if (child.name == "NameTxt")
            {
                if (child.TryGetComponent<TextMeshProUGUI>(out var nameText))
                {
                    nameText.text = currentDialogue.name;
                }
            }
            else if (child.name == "TextBoxTxt")
            {
                if (child.TryGetComponent<TextMeshProUGUI>(out var dialogueTextBox))
                {
                    dialogueTextBox.text = currentDialogue.sentences;
                }
            }
            else if (child.name == "Character")
            {
                Image characterImage = child.GetComponent<Image>();
                if (characterImage != null && currentDialogue.image != null)
                {
                    characterImage.sprite = currentDialogue.image;
                }
            }
        }

        cnt++;
    }

    private void SetChatManager()
    {
        if (SceneManager.GetActiveScene().name == ECC)
        {
            ChatManager.manager.ecc = true;
        }
        else if (SceneManager.GetActiveScene().name == MAIN)
        {
            ChatManager.manager.main = true;
        }
    }

    private bool CheckIsDialogueEnd()
    {
        if (SceneManager.GetActiveScene().name == ECC)
        {
            return ChatManager.manager.ecc;
        }
        else if (SceneManager.GetActiveScene().name == MAIN)
        {
            return ChatManager.manager.main;
        }
        return false;
    }

    private void Update()
    {
        if (isDialogue && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            NextDialogue();
        }
    }

   void Start()
    {
        if(CheckIsDialogueEnd())
        {
            userDialogue.SetActive(false);
            npcDialogue.SetActive(false);
            return;
        }
        ShowDialogue();
    }

    public bool CheckIsNpc()
    {
        if(cnt < dialogues.Length)
        {
            return dialogues[cnt].isNPC;
        }
        return true;
    }
}
