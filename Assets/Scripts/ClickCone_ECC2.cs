using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickCone_ECC2 : MonoBehaviour
{
    void OnMouseDown()
    {
        // Ŭ���� ������Ʈ�� "cone"�� ��� "AR_ECC2" ������ �̵�
        if (gameObject.name == "Cone")
        {
            SceneManager.LoadScene("AR_ECC2");
        }
    }
}