public class AttackSate : IStateBase
{
    public override void EnterState(EnemyManager enemy)
    {
        // Configura la velocidad de ataque o alguna animación
    }

    public override void ExecuteState(EnemyManager enemy)
    {
        // Lógica para atacar al jugador
        // enemy.AttackPlayer();

        //// Si el jugador está lejos, cambia al estado de persecución
        if (enemy.IsPlayerFar())
        {
            enemy.SwitchState(enemy.ChaseState);
        }

        if (enemy.target != null)
        {
            // Por ejemplo, infligir daño.
            //Debug.Log("Enemy is attacking!");
            enemy.AttackPlayer();
            // Si el objetivo se aleja del rango de ataque, vuelve al estado de chasing.
            if (!enemy.IsTargetInAttackRange())
            {
                enemy.SwitchState(enemy.ChaseState);
            }
        }
    }

    public override void ExitState(EnemyManager enemy)
    {
        // Configura la velocidad de patrulla o alguna animación

    }
}

