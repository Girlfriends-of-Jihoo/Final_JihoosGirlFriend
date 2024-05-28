using UnityEngine;
using Vuforia;

public class ShowCube : MonoBehaviour
{
    private DefaultObserverEventHandler observerEventHandler;
    public GameObject cube;

    void Start()
    {
        observerEventHandler = GetComponent<DefaultObserverEventHandler>();
        if (observerEventHandler)
        {
            observerEventHandler.OnTargetFound.AddListener(OnTargetFound);
            observerEventHandler.OnTargetLost.AddListener(OnTargetLost);
        }
        cube.SetActive(false); // ť�긦 �ʱ⿡�� ������ �ʰ� ����
    }

    void OnTargetFound()
    {
        // �̹��� Ÿ���� �����Ǿ��� �� ť�긦 Ȱ��ȭ
        cube.SetActive(true);
    }

    void OnTargetLost()
    {
        // �̹��� Ÿ���� �������� �ʾ��� �� ť�긦 ��Ȱ��ȭ
        cube.SetActive(false);
    }
}
