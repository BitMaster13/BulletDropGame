[System.Serializable]
public class DamageRuneAction : IRuneAction
{
    public int damageAmount = 1;
    public void ExecuteAction(PachinkoGameManager pachinkoGameManager)
    {
        pachinkoGameManager.MakeDamage(damageAmount);
    }
}