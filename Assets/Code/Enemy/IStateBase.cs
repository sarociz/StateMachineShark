//public abstract class IStateBase
//{
//    public abstract void EnterState(EnemyManager enemy);
//    public abstract void ExecuteState(EnemyManager enemy);
//    public abstract void ExitState(EnemyManager enemy);
//}
public interface IStateBase
{
    void EnterState(EnemyManager enemy);
    void ExecuteState(EnemyManager enemy);
    void ExitState(EnemyManager enemy);
}
