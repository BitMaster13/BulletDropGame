using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class Rune : MonoBehaviour
{
    [SerializeField]
    RuneShape shape;
    private PachinkoGameManager pachinkoGameManager;
    public RuneData runeData;

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

        if (other.gameObject.CompareTag("PachinkoBall"))
        {
            pachinkoGameManager.pachinkoBallHitRune(gameObject);
        }
    }
}
