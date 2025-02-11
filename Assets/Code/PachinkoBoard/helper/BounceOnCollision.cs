using UnityEngine;
using DG.Tweening; // Import DOTween

public class BounceOnCollision : MonoBehaviour
{
    [Tooltip("How far the object should bounce back (in Unity units).")]
    public float bounceDistance = 0.5f;

    [Tooltip("How long the bounce animation should take (in seconds).")]
    public float bounceDuration = 0.2f;

    [Tooltip("How long the return to original position should take.")]
    public float returnDuration = 0.3f;

    [Tooltip("The easing function for the bounce.")]
    public Ease bounceEase = Ease.OutQuad; // Good default for a bounce

    [Tooltip("The easing function for the return to original position.")]
    public Ease returnEase = Ease.OutCubic;

    private Transform originalPosition; // Reference to the original position marker

    private void Start()
    {
        // Find the "OriginalPosition" child object
        originalPosition = transform;

        if (originalPosition == null)
        {
            Debug.LogError("OriginalPosition child object not found!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the ball (you might have a tag or a specific component)
        if (collision.gameObject.CompareTag("PachinkoBall")) // Example: using a tag
        {
            // Get the collision normal (direction of the bounce)
            Vector2 collisionNormal = collision.contacts[0].normal;

            // Calculate the bounce target position
            Vector3 bounceTarget = transform.position + (Vector3)collisionNormal * bounceDistance;

            // Stop any existing tweens on this object (important!)
            transform.DOKill();

            // Create the bounce sequence
            Sequence bounceSequence = DOTween.Sequence();

            // 1. Bounce back
            bounceSequence.Append(transform.DOMove(bounceTarget, bounceDuration).SetEase(bounceEase));

            // 2. Return to original position
            bounceSequence.Append(transform.DOMove(originalPosition.position, returnDuration).SetEase(returnEase));
        }
    }
}
