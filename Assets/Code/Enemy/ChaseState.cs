using UnityEngine;

public class ChaseState : IStateBase
{
    public override void EnterState(EnemyManager enemy)
    {
        // Configura la velocidad de persecución o alguna animación
    }

    public override void ExecuteState(EnemyManager enemy)
    {

        //choca? ---> attack

        // Si el jugador está lejos, cambia al estado de escapar
        if (enemy.IsPlayerFar())
        {
            enemy.SwitchState(enemy.PatrolState);
        }


        // Lógica para moverse hacia el objetivo.
        if (enemy.target != null)
        {
            enemy.transform.position = Vector2.MoveTowards(
                enemy.transform.position,
                enemy.target.position,
                Time.deltaTime * enemy.initialSpeed // Asegúrate de tener una velocidad definida.
            );
            // Lógica para moverse hacia el jugador
            //enemy.ChasePlayer();
            // Comprueba si el objetivo está en rango de ataque.
            if (enemy.IsTargetInAttackRange())
            {
                // Cambia al estado de atacar.
                enemy.SwitchState(enemy.AttackState);
            }
        }

    }

    public override void ExitState(EnemyManager enemy)
    {
        // Configura la velocidad de patrulla o alguna animación
        enemy.SwitchState(enemy.AttackState);
    }
}
