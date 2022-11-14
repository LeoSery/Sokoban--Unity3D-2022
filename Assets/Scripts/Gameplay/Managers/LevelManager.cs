using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Script Settings :")]
    public int currentLevel = 0;

    private UIManager uiManager;

    void Awake()
    {
        uiManager = GetComponent<UIManager>();
        currentLevel = GetCurrentLevel();
    }

    int GetCurrentLevel()
    {
        return currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene($"Level_{Level}");
        currentLevel = Level;
        uiManager.UpdateUI(uiManager.levelText, Level.ToString());
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        uiManager.UpdateUI(uiManager.levelText, currentLevel.ToString());
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        uiManager.UpdateUI(uiManager.levelText, currentLevel.ToString());
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            Debug.LogWarning("Closing the game...");
        #endif
        Time.timeScale = 1f;
        Application.Quit();
    }
}
