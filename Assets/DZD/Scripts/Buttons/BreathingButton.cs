using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingButton : MonoBehaviour
{
    public float moveDistance = 10f;
    public float scaleMultiplier = 0.9f;
    public float speed = 2f;

    private RectTransform rectTransform;
    private Vector3 startPos;
    private Vector3 targetPos;
    private Vector3 startScale;
    private Vector3 targetScale;
    private float t;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.localPosition;
        targetPos = startPos + new Vector3(0, moveDistance, 0);
        startScale = rectTransform.localScale;
        targetScale = startScale * scaleMultiplier;
    }

    void Update()
    {
        // Используем unscaledTime, чтобы анимация не зависела от Time.timeScale
        t = (Mathf.Sin(Time.unscaledTime * speed) + 1f) / 2f;

        rectTransform.localPosition = Vector3.Lerp(startPos, targetPos, t);
        rectTransform.localScale = Vector3.Lerp(startScale, targetScale, t);
    }
}