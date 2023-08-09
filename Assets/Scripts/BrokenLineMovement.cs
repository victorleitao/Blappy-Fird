using UnityEngine;

public class BrokenLineMovement : MonoBehaviour
{
    void FixedUpdate()
    {
        // Ignore if game is over
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }

        // Move broken line
        float x = GameManager.Instance.brokenLineSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, GameManager.Instance.endGameDelay + 1);
    }
}
