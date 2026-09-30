using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWonPanel;

    [SerializeField] private SpawnPipesScript spawnPipesScript;
    [SerializeField] private Player player;
    [SerializeField] private GameObject bossObject;
    [SerializeField] private Text subtitleText;
    [SerializeField] private Text warningText;
    [SerializeField] private Animator bossAnimator;
    

    private bool isBossPhaseStarted;

    public void IncreamentScore(int increament) {
        score += increament;
        scoreText.text = score.ToString();

        if (score >= 98 && !isBossPhaseStarted) {
            StartBossPhase();
        }
    }
 
    public void RetryFunction() {
        // get the name of current scene
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOverFunction() {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void StartBossPhase() {
        isBossPhaseStarted = true;

        spawnPipesScript.StopSpawning();
        Invoke(nameof(ShowWarning), 6f);
    }

    public void ShowWarning() {
        warningText.gameObject.SetActive(true);
        Invoke(nameof(HideWarning), 4f);
    }
    
    public void HideWarning() {
        warningText.gameObject.SetActive(false);
        bossObject.SetActive(true);
        bossAnimator.Play("bossEntrance");   
    }

    public void GameWon() {
        Time.timeScale = 0f;
        gameWonPanel.SetActive(true);
    }
}
