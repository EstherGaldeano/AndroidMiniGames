using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAndres : MonoBehaviour
{
    private float timeStart = 0f;
    private float timeCount;
    public TMP_Text textTime;
    private bool timeActive = true;

    private int pointsStart = 0;
    private int pointsCount;
    public TMP_Text textPoints;

    [SerializeField]
    private Player2DAndres player2DAndresScript;

    [SerializeField]
    private GameObject[] heartsList;

    void Start()
    {
        timeCount = timeStart;

        pointsCount = pointsStart;
    }

    void Update()
    {
        if (timeActive)
        {
            timeCount += Time.deltaTime;            

            if (textTime != null)
            {
                textTime.text = FormatTime(timeCount);
            }
        }
    }

    string FormatTime(float time)
    {
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", min, sec);
    }

    public void WinPoints()
    {
        pointsCount++;
        textPoints.text = "POINTS: " + pointsCount.ToString();
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
}
