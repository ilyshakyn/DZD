using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingprincess : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float startHeight; // ��������� ������
    private float relativeHeight = 0; // ������ ������������ ��������� �����
    private bool movingUp = true; // ����������� ��������
    [SerializeField] private float hight = 5f;

    void Start()
    {
        startHeight = transform.position.y; // ���������� ��������� ������
    }

    void Update()
    {
        // ��������� ������������� ������
        relativeHeight = transform.position.y - startHeight;

        // �������� �����
        if (movingUp)
        {
            transform.position += Vector3.up * (Time.deltaTime * speed);

            // ���� �������� 5 ������ �� ��������� ������, ������ �����������
            if (relativeHeight >= hight)
            {
                movingUp = false;
            }
        }
        // �������� ����
        else
        {
            transform.position -= Vector3.up * (Time.deltaTime * speed);

            // ���� ��������� � ��������� ������, ������ ����������� �������
            if (relativeHeight <= 0)
            {
                movingUp = true;
            }
        }
    }
}
