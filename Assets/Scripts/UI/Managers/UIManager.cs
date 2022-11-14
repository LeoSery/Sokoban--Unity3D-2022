using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("GameObjects :")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI cratesText;
    public GameObject pauseMenuUI;

    [Header("Script Settings : ")]
    public bool gameIsPaused = false;

    private LevelManager levelManager;
    private WinManager winManager;

    public int nbCrates;
    private int maxCrates;

    void Awake()
    {
        levelManager = GetComponent<LevelManager>();
        winManager = GetComponent<WinManager>();
    }

    void Start()
    {
        nbCrates = 0;
        maxCrates = winManager.boxes.Length;
        StartUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void StartUI()
    {
        UpdateUI(levelText, levelManager.currentLevel.ToString());
        pauseMenuUI.SetActive(false);
    }

    public void UpdateCrates()
    {
        string value = nbCrates.ToString() + " / " + maxCrates.ToString();
        UpdateUI(cratesText, value);
    }

    public void UpdateUI(TextMeshProUGUI UI, string value)
    {
        UI.text = value;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
