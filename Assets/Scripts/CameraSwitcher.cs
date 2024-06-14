using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // ù ��° ī�޶�
    public Camera camera2; // �� ��° ī�޶�
    public float switchTime = 2.0f; // ī�޶� ��ȯ������ ���� �ð�

    void Start()
    {
        camera1.gameObject.SetActive(true); // ù ��° ī�޶� Ȱ��ȭ
        camera2.gameObject.SetActive(false); // �� ��° ī�޶� ��Ȱ��ȭ
        StartCoroutine(SwitchCameraAfterDelay());
    }

    IEnumerator SwitchCameraAfterDelay()
    {
        yield return new WaitForSeconds(switchTime); // ���� �ð���ŭ ���

        camera1.gameObject.SetActive(false); // ù ��° ī�޶� ��Ȱ��ȭ
        camera2.gameObject.SetActive(true); // �� ��° ī�޶� Ȱ��ȭ
        Debug.Log("Camera switched");
    }
}
