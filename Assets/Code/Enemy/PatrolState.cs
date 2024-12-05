public class PatrolState : IStateBase
{
    public override void EnterState(EnemyManager enemy)
    {
        // Configura la velocidad de patrulla o alguna animación
    }

    public override void ExecuteState(EnemyManager enemy)
    {
        // Lógica para moverse hacia el siguiente punto de patrulla
        //enemy.Patrol();

        // Si el jugador está cerca, cambia al estado de persecución
        if (enemy.IsPlayerNearby())
        {
            ExitState(enemy);
        }
    }

    public override void ExitState(EnemyManager enemy)
    {
        // Configura la velocidad de patrulla o alguna animación
        enemy.SwitchState(enemy.ChaseState);
    }
}

