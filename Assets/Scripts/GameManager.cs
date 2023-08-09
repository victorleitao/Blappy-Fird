using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Prefabs Settings")]
    [Tooltip("List of prefabs to be spawned.")]
    public List<GameObject> obstaclePrefabs;

    [Header("Obstacle Settings")]
    [Tooltip("Time between obstacles.")]
    public float obstacleInterval = 1;

    [Tooltip("Speed of the obstacles towards player.")]
    public float obstacleSpeed = 5;

    [Tooltip("Distance of the spawning obstacle on the X axis.")]
    public float obstacleOffsetX = 13;

    [Tooltip("Max and minimum spawning values in the Y axis.")]
    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    [Header("Background Settings")]
    [Tooltip("Speed of the buildings towards player.")]
    public float buildingsSpeed = 3;
    [Tooltip("Speed of the broken lines towards player.")]
    public float brokenLineSpeed = 5;

    [HideInInspector]
    public int playerScore = 0;

    [Header("Game Over")]
    [Tooltip("Time until game reload.")]
    public float endGameDelay = 2f;
    public GameOverManager gameOverManager;
    public TimerManager timerManager;
    private bool isGameOver = false;

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void EndGame()
    {
        // Set flag
        isGameOver = true;

        // Reload scene
        StartCoroutine(ReloadScene(endGameDelay));
    }

    private IEnumerator ReloadScene(float delay)
    {
        // Show message
        gameOverManager.SetGameOver();
        timerManager.SetTimer();

        // Delay
        yield return new WaitForSeconds(delay);

        // Reload Scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
