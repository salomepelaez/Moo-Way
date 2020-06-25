using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public bool inGame;
    public bool dead;
    public bool seen;
    public bool built;
    public bool isCreated;
    public bool canWalk;
    public bool getOut;
    public bool floating;
    public bool bigWinner;
    public bool cowsCollected;
    public bool alienControl;
    public bool abducting;
    public bool gameIsPaused = false;

    public int cowCounter;
    public int fuel;

    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI cowsLeft;

    public AudioSource music;
    public AudioSource loser;
    public AudioSource lose;
    public AudioSource buttons;

    public GameObject pause;
    public GameObject settingsButton;
    public GameObject helpButton;

    public float timer;
    public float lastTimer;

    private int seconds;
    private int minutes;

    private string timerString;

    private Cow cow;
    private EnemyBehaviour enemy;

    public void Awake()
    {
        Instance = this;
        cow = GetComponent<Cow>();
        enemy = GetComponent<EnemyBehaviour>();
        inGame = false;
        dead = false;
        seen = false;
        bigWinner = false;
        cowsCollected = false;
        timer = 420f;        
    }

    void Start()
    {
        music.Play();
    }

    void Update()
    {
        if(inGame == true)
            TimerCount();

        GameOver();
        CowsCounter();
        CheckIfWon();
    }

    public void PauseButton()
    {
        if(gameIsPaused)
        {
            ResumeGame();
        }

        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        buttons.Play();
        pause.SetActive(true);
        settingsButton.SetActive(false);
        helpButton.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        music.pitch = 0.4f;
    }

    public void ResumeGame()
    {
        buttons.Play();
        pause.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        music.pitch = 1f;
    }

    public void Settings()
    {
        buttons.Play();
        settingsButton.SetActive(true);
        pause.SetActive(false);
        helpButton.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        music.pitch = 0.4f;
    }

    public void Help()
    {
        buttons.Play();
        helpButton.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        music.pitch = 0.4f;
    }

    public void GameOver()
    {         
        if(dead == true)
        {
            inGame = false;
            StopTimer(); 
            music.Stop();
            lose.Play();
            StartCoroutine("RestartGame");
        }     
    }

    IEnumerator RestartGame()
    {
        gameOver.text = "You have been caught!"; 
        yield return new WaitForSeconds(3f);
        gameOver.text = "";
        SceneManager.LoadScene("FirstLevel");
    }

    public void TimerCount()
    {
        timer = timer - Time.deltaTime;  
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60) % 60;

        timerString = string.Format("{00:00}:{01:00}", minutes, seconds);
        timerText.text = timerString;

        if(timer < 0)
        {
            gameOver.text = "You ran out of time!";
            inGame = false;
            Analytics.CustomEvent("Death", new Dictionary<string, object>
            {
                { "Death", "by running out of time" },
            });
        }      
    }

    public void StopTimer()
    {
        CancelInvoke("TimerCount");        
    }

    public void CowsCounter()
    {
        cowsLeft.text = "Cows: " + cowCounter + "/3";        
    }

    void CheckIfWon()
    {
        if(bigWinner == true)
        {
            SceneManager.LoadScene("WinnerScene");
        }
    }
}
