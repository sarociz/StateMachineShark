
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
        // Iniciar en el estado de patrulla
        currentState = PatrolState;
        currentState.EnterState(this);

        // Obtiene el Rigidbody2D del enemigo
        rbObstaculo = GetComponent<Rigidbody2D>();

        // Establece la velocidad inicial
        currentSpeed = initialSpeed;

        // Inicia con una dirección aleatoria
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        // Asigna la velocidad inicial en esa dirección
        rbObstaculo.velocity = direction * currentSpeed;
    }
    void Update()
    {
        currentState?.ExecuteState(this);
    }

    private void ExecuteStates()
    {
        currentState.ExecuteState(this);
    }

    public void SwitchState(IStateBase newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void PatrolMovement()
    {
        //  movimiento y rebote en los límites de pantalla
    }

    public void ChasePlayer()
    {
        // Implementa el movimiento hacia el jugador
    }

    public void EscapeFromPlayer()
    {
        //  alejarse del jugador
    }

    public bool IsPlayerNearby()
    {
        // Implementa la lógica para verificar si el jugador está cerca
        return Vector3.Distance(transform.position, player.position) < 5.0f;
    }

    public bool IsPlayerFar()
    {
        // Implementa la lógica para verificar si el jugador está lejos
        return Vector3.Distance(transform.position, player.position) > 10.0f;
    }

    public void AttackPlayer()
    {
        GameManager.looseLife();
        // Guardar la velocidad actual del Rigidbody2D
        Vector2 velocidadActual = rbObstaculo.velocity;

        if (!GameManager.invincible)
        {
            auSource.clip = enemyAudio;
            auSource.Play();
            GameManager.looseLife();
            GameManager.TimeInvulnerable();
        }

        // Siempre restablecer la velocidad del Rigidbody2D después de todos los cálculos
        rbObstaculo.velocity = velocidadActual;

    }

    public bool IsTargetInAttackRange()
    {
        if (target == null) return false;
        return Vector2.Distance(transform.position, target.position) <= attackRange;
    }

    private void FixedUpdate()
    {
        // Incrementa la velocidad con el tiempo
        currentSpeed += acceleration * Time.deltaTime;

        // Actualiza la velocidad del Rigidbody2D en la dirección actual
        rbObstaculo.velocity = direction * currentSpeed;
        Debug.Log(currentSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Al chocar, calcula la nueva dirección reflejada
        Vector2 normal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal).normalized;

        // Actualiza la velocidad del Rigidbody2D en la nueva dirección con la velocidad actual
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

    //    // Siempre restablecer la velocidad del Rigidbody2D después de todos los cálculos
    //    rbObstaculo.velocity = velocidadActual;
    //}



    //private void Start()
    //{
    //    // Obtiene el Rigidbody2D del enemigo
    //    rbObstaculo = GetComponent<Rigidbody2D>();

    //    // Establece la velocidad inicial
    //    currentSpeed = initialSpeed;

    //    // Inicia con una dirección aleatoria
    //    float angle = Random.Range(0f, 360f);
    //    direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

    //    // Asigna la velocidad inicial en esa dirección
    //    rbObstaculo.velocity = direction * currentSpeed;
    //}



}
//private void Start()
//{
//    rbObstaculo.velocity = Vector2.zero;
//    velocidad.x = Random.Range(-1f, 1f);
//    velocidad.y = -1;
//    rbObstaculo.AddForce(transform.right * rapidez * velocidad * Time.deltaTime);
//    GameManager = FindAnyObjectByType<GameManager>();

//    //transform.position += transform.right * rapidez * Time.deltaTime;

//}





//Funcion para arreglar la velocidad del rebote del obstáculo.
//private void velocityFix()
//{
//    float velocity = 3f;
//    float minVelocity = 3f;
//    float maxVelocity = 3f;  // Velocidad máxima        

//    // Ajuste de la velocidad en el eje X
//    if (Mathf.Abs(rbObstaculo.velocity.x) < minVelocity)
//    {
//        velocity = Random.value < 0.5f ? velocity : -velocity;
//        rbObstaculo.velocity += new Vector2(velocity, 0f);
//    }

//    // Ajuste de la velocidad en el eje Y
//    if (Mathf.Abs(rbObstaculo.velocity.y) < minVelocity)
//    {
//        velocity = Random.value < 0.5f ? velocity : -velocity;
//        rbObstaculo.velocity += new Vector2(velocity, 0f);
//    }

//    // Limitar la velocidad máxima
//    rbObstaculo.velocity = Vector2.ClampMagnitude(rbObstaculo.velocity, maxVelocity);
//}



