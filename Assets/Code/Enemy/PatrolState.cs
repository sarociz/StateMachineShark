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

        // Cambiar al estado de persecución si el jugador está cerca
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
    //    // Configura la velocidad de patrulla o alguna animación
    //}

    //public override void ExecuteState(EnemyManager enemy)
    //{
    //    // Lógica para moverse hacia el siguiente punto de patrulla
    //    //enemy.Patrol();

    //    // Si el jugador está cerca, cambia al estado de persecución
    //    if (enemy.IsPlayerNearby())
    //    {
    //        ExitState(enemy);
    //    }
    //}

    //public override void ExitState(EnemyManager enemy)
    //{
    //    // Configura la velocidad de patrulla o alguna animación
    //    enemy.SwitchState(enemy.ChaseState);
    //}
}

