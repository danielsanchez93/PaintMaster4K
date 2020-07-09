using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private int matchTime;
    private int count;
    /// <summary>
    /// Toma la cantidad de veces que he dibujado y la convierte en 1 2 o 3 estrellas
    /// </summary>
    private int score;

    public TMPro.TextMeshProUGUI timerText;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        StartCoroutine(Timer());
    }

    public void GetParticleCount(int points)
    {
        score += points;
    }

    private int CalculateScore()
    {
        if(score < 200) { score = 1; }
        else if(score >= 200 && score < 500) { score = 2; }
        else score = 3;

        return score;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        count++;
        timerText.text = "Time left: " + (matchTime - count).ToString();
        StartCoroutine(Timer());
        if(count >= matchTime)
        {
            StopAllCoroutines();
            FindObjectOfType<CanvasControl>().AbrirPanelEnd(CalculateScore());
        }
    }
}
