using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public GameObject restartTimer;
    public Text restartText;
    private float cooldown;

    void FixedUpdate()
    {
        if (restartTimer.activeInHierarchy)
        {
            restartText.text = "Restarting in " + Mathf.Floor(cooldown -= Time.fixedDeltaTime) + "...";
        }
    }

    public void SetTimer()
    {
        restartTimer.SetActive(true);
        cooldown = GameManager.Instance.endGameDelay + 1;
    }
}
