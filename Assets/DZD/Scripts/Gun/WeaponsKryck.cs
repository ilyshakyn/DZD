using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsKryck : MonoBehaviour
{
    [SerializeField] private float maxDistance = 5f; // Максимальная длина цепи
    [SerializeField] private float kryckForce = 15f; // Сила притяжения
    [SerializeField] private GameObject chainSegmentPrefab; // Префаб звена цепи
    [SerializeField] private float segmentLength = 0.5f; // Длина одного звена цепи
    [SerializeField] private LayerMask groundLayer;

    private GameObject player = null;
    private Rigidbody2D rb;

    private bool isAttached = false; // Флаг, показывает, что игрок прицеплён
    private Vector2 hitPoint;        // Точка прицепления
    private List<GameObject> chainSegments = new List<GameObject>(); // Список звеньев цепи
    public AudioClip jumpSound;
    public AudioSource audioKryckSourceEffects;
    private void Start()
    {
        // Ищем игрока по тегу и получаем его Rigidbody2D
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            rb = player.GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.LogError("Игрок с тегом 'Player' не найден!");
        }
    }

    private void Update()
    {
        // Сбрасываем флаг при отпускании кнопки мыши
        if (Input.GetMouseButtonUp(1))
        {
            isAttached = false;

            // Удаляем звенья цепи
            ClearChainSegments();
            player.GetComponent<MovePlayer>().enabled = true;
        }

        // Фиксируем точку прицепления, если кнопка нажата
        if (Input.GetMouseButtonDown(1) && !isAttached)
        {
            RaycastToMouse();
        }

        // Обновляем цепь, если игрок прицеплён
        if (isAttached)
        {
            UpdateChainSegments();
        }
    }

    private void FixedUpdate()
    {
        if (isAttached)
        {
            
            float distanceToPoint = Vector2.Distance(rb.position, hitPoint);

           
            if (distanceToPoint > maxDistance)
            {
                
                Vector2 direction = (hitPoint - rb.position).normalized;
                rb.position = hitPoint - direction * maxDistance;
            }

            
            Vector2 pullDirection = (hitPoint - rb.position).normalized;
            rb.AddForce(pullDirection * kryckForce, ForceMode2D.Force);

            
            if (distanceToPoint < 1.5f)
            {
                rb.velocity = Vector2.zero;
                player.GetComponent<MovePlayer>().enabled = false;
            }
        }
    }

    private void RaycastToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - transform.position).normalized;

        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, groundLayer);

        Debug.DrawLine(transform.position, transform.position + (Vector3)direction * maxDistance, Color.red);

        
        if (hit.collider != null)
        {
            hitPoint = hit.point;
            isAttached = true;
            audioKryckSourceEffects.PlayOneShot(jumpSound);

            UpdateChainSegments();
        }
    }

    private void UpdateChainSegments()
    {
        
        ClearChainSegments();

        
        float distanceToPoint = Vector2.Distance(rb.position, hitPoint);
        int segmentCount = Mathf.CeilToInt(distanceToPoint / segmentLength);

        
        Vector2 direction = (hitPoint - rb.position).normalized;

        for (int i = 0; i < segmentCount; i++)
        {
            
            Vector2 segmentPosition = rb.position + direction * (segmentLength * i);

            
            GameObject segment = Instantiate(chainSegmentPrefab, segmentPosition, Quaternion.identity);
            chainSegments.Add(segment);

            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            segment.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void ClearChainSegments()
    {
        
        foreach (GameObject segment in chainSegments)
        {
            Destroy(segment);
        }
        chainSegments.Clear();
    }
    public void ResetHook()
    {
        isAttached = false; 
        ClearChainSegments(); 
    }
}
