using UnityEngine;

public class BattleBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("Pachinko Ball OnTriggerEnter2D");

        if (other.gameObject.CompareTag("PachinkoBall"))
        {
            DestroyPachinkoBall(other.gameObject);
        }
    }

    public void DestroyPachinkoBall(GameObject ball)
    {
        Destroy(ball);
    }
}
