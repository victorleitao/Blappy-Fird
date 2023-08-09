using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    void FixedUpdate()
    {
        // Ignore if game is over
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }

        // Move obstacle
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        // Destroy obstacle
        if (transform.position.x <= -GameManager.Instance.obstacleOffsetX)
        {
            Destroy(gameObject, 1);
        }
    }
}
