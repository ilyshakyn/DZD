using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeadPlayer : MonoBehaviour
{
    [Header("Ссылки на игрока и компоненты")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weapon;
    [SerializeField] private AudioSource audioJump;
    [SerializeField] private WeaponsKryck hookScript;

    [Header("Объект, у которого меняется цвет")]
    [SerializeField] private GameObject colorTarget;
    [SerializeField] private Color deadColor = Color.red;

    [Header("Точка проверки тела")]
    [SerializeField] private Transform bodyCheckPoint;
    [SerializeField] private Vector2 bodyCheckSize = new Vector2(1f, 1f);

    [Header("Точка проверки ног")]
    [SerializeField] private Transform legsCheckPoint;
    [SerializeField] private Vector2 legsCheckSize = new Vector2(1f, 0.5f);

    [Header("Слой DeadZone")]
    [SerializeField] private LayerMask deadZoneLayer;

    public bool isDeadZone = false;
    private bool isFrozen = false;

    private SpriteRenderer colorRenderer;
    public Color originalColor;

    private void Start()
    {
        if (colorTarget != null)
        {
            colorRenderer = colorTarget.GetComponent<SpriteRenderer>();
            if (colorRenderer != null)
                originalColor = colorRenderer.color;
            else
                Debug.LogWarning("На colorTarget нет SpriteRenderer!");
        }
        else
        {
            Debug.LogWarning("colorTarget не назначен! Цвет не будет меняться.");
        }
    }

    private void Update()
    {
        if (player == null || bodyCheckPoint == null || legsCheckPoint == null)
            return;


        bool bodyInside = Physics2D.OverlapBox(bodyCheckPoint.position, bodyCheckSize, 0f, deadZoneLayer);
        bool legsInside = Physics2D.OverlapBox(legsCheckPoint.position, legsCheckSize, 0f, deadZoneLayer);

        bool nowInDeadZone = bodyInside || legsInside;

        if (nowInDeadZone && !isDeadZone)
        {
            isDeadZone = true;
            StartCoroutine(FreezeTemporarily(2f));
        }

        if (isDeadZone && player.GetComponent<MovePlayer>().isGrounded)
        {
            var rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0,rb.velocity.y); // Сразу остановить
        }

        if (!isDeadZone)
        {
                colorRenderer.color = originalColor;
        }

        // Выход из зоны — только если не заморожен
        else if (!nowInDeadZone && isDeadZone && !isFrozen)
        {
            isDeadZone = false;
            ExitDeadZone();
        }
    }

    private IEnumerator FreezeTemporarily(float duration)
    {
        Debug.Log("Вход в мёртвую зону");

        isFrozen = true;

        hookScript.ResetHook();

        var rb = player.GetComponent<Rigidbody2D>();
       
       

        SetPlayerControl(false);

        if (colorRenderer != null)
            colorRenderer.color = deadColor;

        yield return new WaitForSeconds(duration);

        isFrozen = false;

        // Теперь разморозка произойдёт в Update только после выхода из зоны
    }

    private void ExitDeadZone()
    {
        Debug.Log("Выход из мёртвой зоны");

        SetPlayerControl(true);

      
    }

    private void SetPlayerControl(bool enabled)
    {
        player.GetComponent<MovePlayer>().enabled = enabled;
        weapon.GetComponent<WeaponsKryck>().enabled = enabled;
        audioJump.enabled = enabled;
    }

    private void OnDrawGizmosSelected()
    {
        if (bodyCheckPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(bodyCheckPoint.position, bodyCheckSize);
        }

        if (legsCheckPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(legsCheckPoint.position, legsCheckSize);
        }
    }
}