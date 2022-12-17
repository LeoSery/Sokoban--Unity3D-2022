using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Script Settings :")]
    public int currentLevel = 0;

    [Header("GameObjects :")]
    public GameObject nextLevelButton;

    private readonly int levelCount = 2;

    private UIManager uiManager;

    void Awake()
    {
        uiManager = GetComponent<UIManager>();
        currentLevel = GetCurrentLevel();

        if (currentLevel < levelCount)
        {
            nextLevelButton.GetComponent<Button>().interactable = true;
            nextLevelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            nextLevelButton.GetComponent<Button>().interactable = false;
            nextLevelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(144, 135, 135, 158);
        }
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
        currentLevel = GetCurrentLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        uiManager.UpdateUI(uiManager.levelText, currentLevel.ToString());
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        uiManager.UpdateUI(uiManager.levelText, currentLevel.ToString());
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadOptions()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options");
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
