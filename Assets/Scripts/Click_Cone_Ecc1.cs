using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_Cone_Ecc1 : MonoBehaviour
{
    void OnMouseDown()
    {
        // Ŭ���� ������Ʈ�� "cone"�� ��� "AR_ECC1" ������ �̵�
        if (gameObject.name == "Cone")
        {
            SceneManager.LoadScene("AR_ECC1");
        }
    }
}
