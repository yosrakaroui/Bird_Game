using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public PipeSpawnScript pipeSpawner;
    public int levelNumber = 1;
    public int scoreToAdvance = 10;
    public string nextLevelScene;
    public Text levelText;
    public Text completionText;
    public AudioSource audioSource;
    public AudioClip scoreSound;
    public AudioClip collisionSound;
    private bool isTransitioning;
    private void Start()
    {
        if (levelText != null)
        {
            showProgress();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        playSound(scoreSound);
        showProgress();
        if (!isTransitioning && playerScore >= scoreToAdvance && !string.IsNullOrEmpty(nextLevelScene))
        {
            isTransitioning = true;
            SceneManager.LoadScene(nextLevelScene);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextLevelScene))
        {
            SceneManager.LoadScene(nextLevelScene);
        }
    }

    public void showProgress()
    {
        if (levelText != null)
        {
            levelText.text = "NIVEAU " + levelNumber + "  |  " + playerScore + "/" + scoreToAdvance;
        }
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        playSound(collisionSound);
        if (levelNumber == 3 && completionText != null)
        {
            completionText.text = "FIN DES 3 NIVEAUX !";
        }
        if (pipeSpawner != null)
        {
            pipeSpawner.enabled = false;
        }
    }

    private void playSound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }



}
