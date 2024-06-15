using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickFlower : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // ���� ������Ʈ�� Ŭ���� ���
                {
                    SceneManager.LoadScene("1_Main"); // "Main" ������ ��ȯ
                }
            }
        }
    }
}
