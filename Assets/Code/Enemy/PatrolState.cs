public class PatrolState : IStateBase
{
    public override void EnterState(EnemyManager enemy)
    {
        // Configura la velocidad de patrulla o alguna animaci�n
    }

    public override void ExecuteState(EnemyManager enemy)
    {
        // L�gica para moverse hacia el siguiente punto de patrulla
        //enemy.Patrol();

        // Si el jugador est� cerca, cambia al estado de persecuci�n
        if (enemy.IsPlayerNearby())
        {
            ExitState(enemy);
        }
    }

    public override void ExitState(EnemyManager enemy)
    {
        // Configura la velocidad de patrulla o alguna animaci�n
        enemy.SwitchState(enemy.ChaseState);
    }
}

