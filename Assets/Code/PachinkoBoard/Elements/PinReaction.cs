using UnityEngine;
using System.Collections;

public class PinReaction : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.5f;
    public float shakeSpeed = 20f;
    private bool isShaking = false;
    private Vector3 originalPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Pin collision detected");

        if (collision.gameObject.CompareTag("PachinkoBall") && !isShaking)
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Debug.Log($"Pin collision detected with ball at {contactPoint}");
            Vector3 direction = ((Vector3)contactPoint - transform.position).normalized;
            Debug.Log($"Shake direction calculated: {direction}");
            StartCoroutine(Shake(direction));
        }
    }

    IEnumerator Shake(Vector3 direction)
    {
        isShaking = true;
        originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            // Use sine wave for smooth back-and-forth movement
            float offset = Mathf.Sin(elapsed * shakeSpeed) * shakeMagnitude;
            transform.position = originalPosition + (direction * offset);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isShaking = false;
    }
}