using UnityEngine;
using TMPro;

public class TimerCounter : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timeElapsed = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        timeElapsed += Time.deltaTime;
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // Call this when game ends
    public void StopTimer()
    {
        isRunning = false;
    }

    // Call this when restarting
    public void ResetTimer()
    {
        timeElapsed = 0f;
        isRunning = true;
    }
}