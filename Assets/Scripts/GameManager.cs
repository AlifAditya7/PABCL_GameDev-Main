using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject about;
    [SerializeField] private GameObject jumpSfx;
    [SerializeField] private GameObject stepSfx;
    [SerializeField] private GameObject swordSwingSfx;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreText2;

    private float _time = 0f;
    public static GameManager _instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        ShowMainMenuStart();
        _instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        _time += Time.deltaTime;
        scoreText.text = "Score : " + Mathf.Round(_time).ToString();
        scoreText2.text = "Score : " + Mathf.Round(_time).ToString();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f; // Pause
        gameOver.SetActive(true);
    }

    public void ShowMainMenuStart()
    {
        Time.timeScale = 0f;
        mainMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        Time.timeScale = 0f;
        mainMenu.SetActive(true);
        about.SetActive(false);
        gameOver.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void BtnRetry_OnClick()
    {
        Time.timeScale = 1f; // Resume
        gameOver.SetActive(false); // Game Over Di Hide
        SceneManager.LoadScene(0); // Restart Level
    }

    public void BtnPlay_OnClick()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        about.SetActive(false);
    }

    public void BtnAbout_OnClick()
    {
        about.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void jumpSfxOn()
    {
        jumpSfx.SetActive(true);
    }

    public void stepSfxOn()
    {
        stepSfx.SetActive(true);
    }

    public void swordSwingSfxOn()
    {
        swordSwingSfx.SetActive(true);
    }

    public void swordSwingSfxOff()
    {
        swordSwingSfx.SetActive(false);
    }

    public void jumpSfxOff()
    {
        jumpSfx.SetActive(false);
    }

    public void stepSfxOff()
    {
        stepSfx.SetActive(false);
    }
}
