using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillTracker : MonoBehaviour
{
    public Text resultText; 
    public GameObject gameOverScreen; 

    private List<string> killLogs = new List<string>(); 
    private List<string> logs = new List<string>();
    public bool gameEnded = false; 

    void Start()
    {
        gameEnded = false;
        if (gameOverScreen != null) gameOverScreen.SetActive(false); 
    }

    void Update()
    {
        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                RestartGame();
                
            }
            return;
        }
    }   

    public void LogKill(string victim)
    {
        if (gameEnded) return;

        float gameTime = GetGameTime();
        string logEntry = $"{victim} killed at {gameTime} s";
        killLogs.Add(logEntry);
        logs.Add(logEntry);
        string pointsEntry = $"Updated number of points: {NPCController.POINTS}";
        logs.Add(pointsEntry);
    }

    public void LogAppearance(string victim){
        if (gameEnded) return;

        float gameTime = GetGameTime();
        string logEntry = $"{victim} appears at {gameTime} s";
        logs.Add(logEntry);
    }

    public void LogDissapearance(string victim){
        if (gameEnded) return;

        float gameTime = GetGameTime();
        string logEntry = $"{victim} disappear at {gameTime} s";
        logs.Add(logEntry);
    }

    public void EndGame()
    {
        if(!gameEnded){
            gameEnded = true;
            logs.Add("Time is up!");
            logs.Add($"Game over! Points: {NPCController.POINTS}");
            WriteLogsToTXT();
            ShowResultsOnScreen();
        }
    }

    private void WriteLogsToTXT()
    {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/kill_logs.txt";

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("Game started");
            writer.WriteLine("Number of points: 0");
            foreach (string log in logs)
            {
                writer.WriteLine(log);
            }
        }
        Debug.Log("Log saved to " + path);
    }

    

    private void ShowResultsOnScreen()
    {
        if (resultText != null)
        {
            resultText.text = "Game Over! Kills:\n";

            foreach (string log in killLogs)
            {
                resultText.text += log + "\n";
            }
        }

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void ResetState()
    {
        gameEnded = false;
        killLogs.Clear();
        logs.Clear();
        if (gameOverScreen != null) gameOverScreen.SetActive(false);
        if (resultText != null) resultText.text = "";
        Time.timeScale = 1;
    }

    void RestartGame()
    {
        ResetState();
        foreach (var bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(bullet);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private float GetGameTime()
    {
        TimeRemaining timer = GameObject.FindObjectOfType<TimeRemaining>();
        if (timer != null)
        {
            return timer.timeLimit - timer.timeRemaining; 
        }
        return 0f; 
    }
}
