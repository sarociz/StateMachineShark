
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Rigidbody2D rbObstaculo;
    public float rapidez = 3f;
    public Vector2 velocidad;
    private GameManager GameManager;

    public AudioSource auSource;

    public AudioClip enemyAudio;

    private Vector2 direction;
    private float currentSpeed;

    public float initialSpeed = 5f; // Velocidad inicial del enemigo
    public float acceleration = 0.5f; // Cantidad que aumenta la velocidad cada segundo

    public Transform player; // Referencia al jugador

    public PatrolState PatrolState = new PatrolState();
    public ChaseState ChaseState = new ChaseState();
    public AttackSate AttackState = new AttackSate();

    private IStateBase currentState;

    public Transform target;
    public float attackRange = 1.5f;

    private void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        // Iniciar en el estado de patrulla
        currentState = PatrolState;
        currentState.EnterState(this);
        Debug.Log("Estado: " + currentState);
        // Obtiene el Rigidbody2D del enemigo
        rbObstaculo = GetComponent<Rigidbody2D>();

        // Establece la velocidad inicial
        currentSpeed = initialSpeed;

        // Inicia con una direcci�n aleatoria
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        // Asigna la velocidad inicial en esa direcci�n
        rbObstaculo.velocity = direction * currentSpeed;


    }

   
    void Update()
    {
        currentState?.ExecuteState(this);
    }
  
    public void SwitchState(IStateBase newState)
    {
        currentState = newState;
        currentState.EnterState(this);
        Debug.Log("Estado: " + currentState);
    }

    public void PatrolMovement()
    {
        // Movimiento b�sico y detecci�n de l�mites
        rbObstaculo.velocity = direction * currentSpeed;

        // Si choca con algo, cambiar direcci�n (ya manejado en OnCollisionEnter2D)
    }
    public void ChasePlayer()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rbObstaculo.velocity = directionToPlayer * currentSpeed;
    }

    public void EscapeFromPlayer()
    {
        //  alejarse del jugador
    }

    public bool IsPlayerNearby()
    {
        // Implementa la l�gica para verificar si el jugador est� cerca
        return Vector3.Distance(transform.position, player.position) < 5.0f;
    }

    public bool IsPlayerFar()
    {
        // Implementa la l�gica para verificar si el jugador est� lejos
        return Vector3.Distance(transform.position, player.position) > 10.0f;
    }

    public void AttackPlayer()
    {
        //GameManager.looseLife();
        // Guardar la velocidad actual del Rigidbody2D
        Vector2 velocidadActual = rbObstaculo.velocity;

        if (!GameManager.invincible)
        {
            auSource.clip = enemyAudio;
            auSource.Play();
            GameManager.looseLife();
            GameManager.TimeInvulnerable();
        }

        // Siempre restablecer la velocidad del Rigidbody2D despu�s de todos los c�lculos
        rbObstaculo.velocity = velocidadActual;
        velocityFix();
    }

    public bool IsTargetInAttackRange()
    {
        if (target == null) return false;
        return Vector2.Distance(transform.position, target.position) <= attackRange;
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Al chocar, calcula la nueva direcci�n reflejada
        Vector2 normal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal).normalized;

        // Actualiza la velocidad del Rigidbody2D en la nueva direcci�n con la velocidad actual
        rbObstaculo.velocity = direction * currentSpeed;
    }


    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // Guardar la velocidad actual del Rigidbody2D
    //    Vector2 velocidadActual = rbObstaculo.velocity;

    //    if (!GameManager.invincible && collision.gameObject.CompareTag("Personaje"))
    //    {
    //        auSource.clip = enemyAudio;
    //        auSource.Play();
    //        GameManager.looseLife();
    //        GameManager.TimeInvulnerable();
    //    }

    //    // Siempre restablecer la velocidad del Rigidbody2D despu�s de todos los c�lculos
    //    rbObstaculo.velocity = velocidadActual;
    //    velocityFix();
    //}

    private void velocityFix()
    {
        float velocity = 3f;
        float minVelocity = 3f;
        float maxVelocity = 3f;  // Velocidad m�xima        

        // Ajuste de la velocidad en el eje X
        if (Mathf.Abs(rbObstaculo.velocity.x) < minVelocity)
        {
            velocity = Random.value < 0.5f ? velocity : -velocity;
            rbObstaculo.velocity += new Vector2(velocity, 0f);
        }

        // Ajuste de la velocidad en el eje Y
        if (Mathf.Abs(rbObstaculo.velocity.y) < minVelocity)
        {
            velocity = Random.value < 0.5f ? velocity : -velocity;
            rbObstaculo.velocity += new Vector2(velocity, 0f);
        }

        // Limitar la velocidad m�xima
        rbObstaculo.velocity = Vector2.ClampMagnitude(rbObstaculo.velocity, maxVelocity);
    }



}





