using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingprincess : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float startHeight; // Начальная высота
    private float relativeHeight = 0; // Высота относительно начальной точки
    private bool movingUp = true; // Направление движения
    [SerializeField] private float hight = 5f;

    void Start()
    {
        startHeight = transform.position.y; // Запоминаем стартовую высоту
    }

    void Update()
    {
        // Вычисляем относительную высоту
        relativeHeight = transform.position.y - startHeight;

        // Движение вверх
        if (movingUp)
        {
            transform.position += Vector3.up * (Time.deltaTime * speed);

            // Если достигли 5 метров от стартовой высоты, меняем направление
            if (relativeHeight >= hight)
            {
                movingUp = false;
            }
        }
        // Движение вниз
        else
        {
            transform.position -= Vector3.up * (Time.deltaTime * speed);

            // Если вернулись к стартовой высоте, меняем направление обратно
            if (relativeHeight <= 0)
            {
                movingUp = true;
            }
        }
    }
}
