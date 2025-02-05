using UnityEngine;

public class StartZone : MonoBehaviour
{
    public GameObject pachinkoBallPrefab;
    private Collider2D clickAreaCollider;


    private void Start()
    {
        clickAreaCollider = GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SpawnPachinkoBall(mousePosition);
    }

    void SpawnPachinkoBall(Vector3 position)
    {
        if (pachinkoBallPrefab != null)
        {
            // Instantiate the Pachinko ball prefab at the clicked position
            GameObject ball = Instantiate(pachinkoBallPrefab, position, Quaternion.identity);
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 1f); // Make it larger and set z-scale to 1
            ball.transform.position = new Vector3(position.x, position.y, 0f); // Ensure z-position is 0
        }
        else
        {
            Debug.LogError("Pachinko Ball Prefab not assigned in Dropzone!");
        }
    }
}
