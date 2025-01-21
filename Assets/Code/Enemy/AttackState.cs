using UnityEngine;

public class AttackSate : IStateBase
{

    public void EnterState(EnemyManager enemy)
    {
        Debug.Log("Entrando en estado de ataque");
    }

    public void ExecuteState(EnemyManager enemy)
    {
        enemy.AttackPlayer();

        // Si el jugador escapa del rango de ataque, volver a persecución
        if (!enemy.IsTargetInAttackRange())
        {
            enemy.SwitchState(enemy.ChaseState);
        }
    }

    public void ExitState(EnemyManager enemy)
    {
        Debug.Log("Saliendo del estado de ataque");
    }
    //public override void EnterState(EnemyManager enemy)
    //{
    //    // Configura la velocidad de ataque o alguna animación
    //}

    //public override void ExecuteState(EnemyManager enemy)
    //{
    //    // Lógica para atacar al jugador
    //    // enemy.AttackPlayer();

    //    //// Si el jugador está lejos, cambia al estado de persecución
    //    if (enemy.IsPlayerFar())
    //    {
    //        enemy.SwitchState(enemy.ChaseState);
    //    }

    //    if (enemy.target != null)
    //    {
    //        // Por ejemplo, infligir daño.
    //        //Debug.Log("Enemy is attacking!");
    //        enemy.AttackPlayer();
    //        // Si el objetivo se aleja del rango de ataque, vuelve al estado de chasing.
    //        if (!enemy.IsTargetInAttackRange())
    //        {
    //            enemy.SwitchState(enemy.ChaseState);
    //        }
    //    }
    //}

    //public override void ExitState(EnemyManager enemy)
    //{
    //    // Configura la velocidad de patrulla o alguna animación

    //}
}

