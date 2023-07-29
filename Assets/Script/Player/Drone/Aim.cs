using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    Vector3 screenPosition;//���������������ת��Ϊ��Ļ����
    Vector3 mousePositionOnScreen;//��ȡ�������Ļ����Ļ����
    Vector3 mousePositionInWorld;//�������Ļ����Ļ����ת��Ϊ��������
    void Update()
    {
        MouseFollow();
    }
    void MouseFollow()
    {
        screenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(screenPosition.x, screenPosition.y, transform.position.z);
    }
}
