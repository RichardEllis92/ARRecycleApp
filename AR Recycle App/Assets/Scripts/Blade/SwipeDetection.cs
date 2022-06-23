using System.Collections;
using UnityEngine;

/// <summary>
/// Detect swipes and it's direction.
/// Adds a cool trail effect to swipe.
/// </summary>
public class SwipeDetection : MonoBehaviour
{
    [Header("Swipe Settings")]
        [SerializeField, Tooltip("Minimum distance between start and end position for swipe to register.")]
        private float minimumDistance = .2f;
        [SerializeField, Tooltip("Maximum time between start and end touch for swipe to register.")]
        private float maximumTime = 1f;
        [SerializeField, Range(0f, 1f), Tooltip("Threshold for swipe direction dot product. .9 = 90% alike in direction.")]
        private float directionThreshold = .9f;
    [Header("Trail Settings")]
        [SerializeField, Tooltip("GameObject with trail renderer attached.")]
        private GameObject trail;

    #region Private
        private InputManager inputManager;
        private Coroutine coroutine;
        private Vector2 startPosition;
        private float startTime;
        private Vector2 endPosition;
        private float endTime;
    #endregion Private

    private void Awake() {
        inputManager = InputManager.Instance;
    }

    private void OnEnable() {
        // Subscribe to touch events.
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable() {
        // Unsubscribe to touch events.
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    /// <summary>
    /// Called when the player presses down on the screen (touch begins).
    /// </summary>
    /// <param name="position">Current touch position in world coordinates.</param>
    /// <param name="time">Time when touch began.</param>
    private void SwipeStart(Vector2 position, float time) {
        startPosition = position;
        startTime = time;
        // Activate trail effect, you can remove this and have it active at all times if
        // the time parameter on the trail renderer is low.
        trail.SetActive(true);
        trail.transform.position = position;
        coroutine = StartCoroutine(Trail());
    }

    private IEnumerator Trail() {
        while(true) {
            trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }

    /// <summary>
    /// Called when the player lifts finger up on the screen (touch ends).
    /// </summary>
    /// <param name="position">Current touch position in world coordinates.</param>
    /// <param name="time">Time when touch ended.</param>
    private void SwipeEnd(Vector2 position, float time) {
        trail.SetActive(false);
        StopCoroutine(coroutine);
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    /// <summary>
    /// Performs swipe detection. Uses distance and time to determine if it's a swipe.
    /// </summary>
    private void DetectSwipe() {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime) {
                Debug.Log("Swipe Detected");
                Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
                // Determine swipe direction
                Vector3 direction = endPosition - startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
            }
    }

    /// <summary>
    /// Determine what direction the swipe is in.
    /// Currently works for up, down, left, right.
    /// </summary>
    /// <param name="direction">Current swipe direction</param>
    private void SwipeDirection(Vector2 direction) {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold) {
            Debug.Log("Swipe Up");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold) {
            Debug.Log("Swipe Down");
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold) {
            Debug.Log("Swipe Left");
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold) {
            Debug.Log("Swipe Right");
        }
    }

}
