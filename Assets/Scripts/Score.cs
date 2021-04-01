using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public HighScores Highscore;
    public static Score instance;
    private int currentScore = 0;
    public TMP_Text score;
    public TMP_Text End;
    public TMP_Text Start;
    public TMP_Text time;
    public TMP_Text speed;
    public TMP_Text EndTimeFinish;
    private float StartTime = 5;
    private float currentTime = 0;
    private bool TimerActive = true;
    private bool EndTime;
    public bool countdown = true;
    private BoatMovement BoatMovement;
    private bool written = false;
    private string localName;


    private void Awake ()
    {
        try
        {
            localName = GameObject.Find("Settings").GetComponent<Settings>().PlayerName;
        }
        catch
        {
            Application.Quit();
        }
        written = false;
        Highscore = gameObject.GetComponent<HighScores>();
        time.text = "0.00";
        StartTime = 5;
        End.gameObject.SetActive(false);
        BoatMovement = GameObject.Find("Boat").GetComponent<BoatMovement>();
    }
    public void UpdateScore(int amount)
    {
        currentScore += amount;
        if(currentScore < 3)
            score.text = $"Score: {currentScore}/3";
        else
        {
            if(!written)
            {
                written = true;
                TimerActive = false;
                End.gameObject.SetActive(true);
                EndTime = true;
                EndTimeFinish.text = $"Well Done! You got {System.Math.Round(currentTime,2)}s";
                Highscore.WriteData(localName,System.Math.Round(currentTime,2));
            
            }
        }

    }

    private void Update ()
    {
        if(countdown)
        {            
          
            if(StartTime <= 0)
            {
                Start.text = "GO";
                countdown = false;
                Start.gameObject.SetActive(false);                
            }
            StartTime -= Time.deltaTime;
            Start.text = System.Math.Round(StartTime,0).ToString();
           
        }
        if(EndTime && Input.GetKeyDown(KeyCode.R)) 
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        if(EndTime && Input.GetKeyDown(KeyCode.B))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
        if(TimerActive && !countdown)
        {
            currentTime += Time.deltaTime;
            time.text = System.Math.Round(currentTime,2).ToString();
        }
    }
    private void FixedUpdate ()
    {
        speed.text = $"Speed: {System.Math.Round(BoatMovement.Boat.velocity.magnitude,2)}";
    }
}
