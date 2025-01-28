using UnityEngine;

public class BattleBox : MonoBehaviour
{
    public BattleBoxData battleBoxData;
    private PachinkoGameManager pachinkoGameManager;

    private void Start()
    {
        pachinkoGameManager = FindFirstObjectByType<PachinkoGameManager>();
        if (pachinkoGameManager == null)
        {
            Debug.LogError("PachinkoGameManager not found in the scene", this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("Pachinko Ball OnTriggerEnter2D");

        if (other.gameObject.CompareTag("PachinkoBall"))
        {
            pachinkoGameManager.enteredBattleBox(this, other.gameObject);
        }
    }
}
