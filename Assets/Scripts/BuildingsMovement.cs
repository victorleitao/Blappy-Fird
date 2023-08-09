using UnityEngine;

public class BuildingsMovement : MonoBehaviour
{
    void FixedUpdate()
    {
        // Ignore if game is over
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }

        // Move broken line
        float x = GameManager.Instance.buildingsSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2);
    }
}
