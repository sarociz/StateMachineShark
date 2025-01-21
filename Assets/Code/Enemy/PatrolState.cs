using UnityEngine;

public class PatrolState : IStateBase
{

    public void EnterState(EnemyManager enemy)
    {
        Debug.Log("Entrando en estado de patrulla");
    }

    public void ExecuteState(EnemyManager enemy)
    {
        enemy.PatrolMovement();

        // Cambiar al estado de persecuci�n si el jugador est� cerca
        if (enemy.IsPlayerNearby())
        {
            enemy.SwitchState(enemy.ChaseState);
        }
    }

    public void ExitState(EnemyManager enemy)
    {
        Debug.Log("Saliendo del estado de patrulla");
    }
    //public override void EnterState(EnemyManager enemy)
    //{
    //    // Configura la velocidad de patrulla o alguna animaci�n
    //}

    //public override void ExecuteState(EnemyManager enemy)
    //{
    //    // L�gica para moverse hacia el siguiente punto de patrulla
    //    //enemy.Patrol();

    //    // Si el jugador est� cerca, cambia al estado de persecuci�n
    //    if (enemy.IsPlayerNearby())
    //    {
    //        ExitState(enemy);
    //    }
    //}

    //public override void ExitState(EnemyManager enemy)
    //{
    //    // Configura la velocidad de patrulla o alguna animaci�n
    //    enemy.SwitchState(enemy.ChaseState);
    //}
}

