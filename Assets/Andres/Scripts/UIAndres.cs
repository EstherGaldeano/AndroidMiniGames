using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIAndres : MonoBehaviour
{
    private float timeStart = 0f;
    private float timeCount;
    public TMP_Text textTime;
    public bool timeActive = true;

    private int pointsStart = 0;
    private int pointsCount;
    public TMP_Text textPoints;

    private int pointsRecord;
    private float timeRecord;

    public TMP_Text textPointsRecord;
    public TMP_Text textTimeRecord;

    [SerializeField]
    private Player2DAndres player2DAndresScript;

    [SerializeField]
    private GameObject[] heartsList;

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject startPanel;

    public GameObject lasers;

    void Start()
    {
        if (PlayerPrefs.HasKey("Restarted"))
        {            
        }
        else
        {
            PlayerPrefs.SetInt("Restarted", 0);
        }

        if (PlayerPrefs.GetInt("Restarted") == 0)
        {
            Time.timeScale = 0.0f;

            startPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;

            startPanel.SetActive(false);

            PlayerPrefs.SetInt("Restarted", 0);
        }

        lasers.SetActive(true);

        timeCount = timeStart;
        pointsCount = pointsStart;

        pointsRecord = 0;
        timeRecord = 0;

        gameOverPanel.SetActive(false);

        if (PlayerPrefs.HasKey("Record"))
        {
            pointsRecord = PlayerPrefs.GetInt("Record");
            WinPointsRecord();
        }
        else
        {
            PlayerPrefs.SetInt("Record", 0);
            pointsRecord = PlayerPrefs.GetInt("Record");
            WinPointsRecord();
        }

        if (PlayerPrefs.HasKey("Time"))
        {
            timeRecord = PlayerPrefs.GetFloat("Time");
        }
        else
        {
            PlayerPrefs.SetFloat("Time", 0.0f);
            timeRecord = PlayerPrefs.GetFloat("Time");
        }        
    }

    void Update()
    {
        if (timeActive)
        {
            timeCount += Time.deltaTime;            

            if (textTime != null)
            {
                textTime.text = FormatTime(timeCount);
                textTimeRecord.text = FormatTime(timeRecord);
            }
        }
        if(timeRecord < timeCount)
        {
            timeRecord = timeCount;
        }
    }

    string FormatTime(float time)
    {
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", min, sec);
    }

    public void TimeRecord()
    {
        PlayerPrefs.SetFloat("Time", timeRecord);
        gameOverPanel.SetActive(true);
    }

    public void WinPoints()
    {
        pointsCount++;
        textPoints.text = "POINTS: " + pointsCount.ToString();

        pointsRecord = PlayerPrefs.GetInt("Record");

        if(pointsCount > pointsRecord)
        {
            PlayerPrefs.SetInt("Record", pointsCount);
            pointsRecord = pointsCount;
            WinPointsRecord();
        }
    }

    public void WinPointsRecord()
    {
        textPointsRecord.text = pointsRecord.ToString();
    }

    public void PlayerLifesUI()
    {
        for(int i = 0; i < heartsList.Length; i++)
        {
            heartsList[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < player2DAndresScript.lifes; i++)
        {
            heartsList[i].gameObject.SetActive(true);
        }
    }

    public void TryAgain()
    {
        PlayerPrefs.SetInt("Restarted", 1);

        SceneManager.LoadScene("Andres_Game");
    }

    public void Play()
    {
        Time.timeScale = 1.0f;

        startPanel.SetActive(false);
    }
}
