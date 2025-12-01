using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string enemyName;
    public float healthPoints;
    public float speed = 2.0f;
    public float damageToGive;

    // Variables públicas configurables en el Inspector
    public Transform player;
    public float detectionRadius = 10.0f; // Rango Grande (Comienza a caminar: 5.0f)
    public float attackRange = 1.5f;   // Rango Pequeño (Comienza a atacar: 1.5f)
    
    // Variables privadas de control y componentes
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool enMovimiento;
    private bool enRangoDeAtaque; 
    private Animator animator;
    private float originalXScale; // Para mantener el tamaño del sprite al voltear
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        // Guardamos la escala X original para usarla en el volteo
        originalXScale = transform.localScale.x; 
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 1. Lógica de Detección (Rango Grande: 5.0f)
        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            
            // Si está dentro del Rango de Ataque (1.5f)
            if (distanceToPlayer <= attackRange)
            {
                // ESTADO DE ATAQUE: Detener el movimiento y activar la bandera de ataque
                enRangoDeAtaque = true;
                movement = Vector2.zero;
            }
            // Si está entre 5.0f y 1.5f (Rango de Caminar)
            else 
            {
                // ESTADO DE CAMINAR: Persecución
                enRangoDeAtaque = false; 
                movement = new Vector2(direction.x, 0); 
            }

            // 'enMovimiento' se establece en base a si hay vector de movimiento
            enMovimiento = (movement != Vector2.zero);
        }
        else // Fuera de rango de detección (Quieto)
        {
            movement = Vector2.zero;
            enMovimiento = false;
            enRangoDeAtaque = false;
        }

        // 2. Control del Animator
        animator.SetBool("enMovimiento", enMovimiento);
        animator.SetBool("enRangoDeAtaque", enRangoDeAtaque); 
        
        // 3. Lógica para voltear el sprite:
        if (movement.x < 0)
        {
            // Moverse a la izquierda (Escala X negativa)
            transform.localScale = new Vector3(-originalXScale, transform.localScale.y, transform.localScale.z);
        }
        else if (movement.x > 0)
        {
            // Moverse a la derecha (Escala X positiva)
            transform.localScale = new Vector3(originalXScale, transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        // El movimiento del Rigidbody2D siempre debe ir en FixedUpdate
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
