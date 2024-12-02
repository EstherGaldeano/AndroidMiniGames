using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{


    private int points;
    private int record;

    [SerializeField]
    private GameObject pointsUI;

    [SerializeField]
    private GameObject recordUI;

    [SerializeField]
    private GameObject gameOverPanel;

    
    [SerializeField]
    private GameObject[] songs;


    public void PointsUpdate(int increase){
        points = points + increase;
        PointsUpdateUI(points);

        record = PlayerPrefs.GetInt("RECORD");

        if (points > record){
            PlayerPrefs.SetInt("RECORD", points);
            record = PlayerPrefs.GetInt("RECORD");
            UpdateUIRecord(record);
        }
    }

    public void PointsUpdateUI(int points){
        pointsUI.gameObject.GetComponent<TMP_Text>().text= "Points" + points.ToString();
    }

    public void UpdateUIRecord(int recordPoints){
        recordUI.gameObject.GetComponent<TMP_Text>().text = "Record" + recordPoints.ToString();
    }

    void Start()
    {
        songs[0].gameObject.GetComponent<AudioSource>().Play();
        Time.timeScale = 1.0f;
        points = 0;
        record = 0;
        PointsUpdateUI(points);
        UpdateUIRecord(record);

       if (PlayerPrefs.HasKey("RECORD")){
            record = PlayerPrefs.GetInt("RECORD");
            UpdateUIRecord(record);

        }else{
            PlayerPrefs.SetInt("RECORD", 0);
            record = PlayerPrefs.GetInt("RECORD");
            UpdateUIRecord(record);
        }

        PlayerPrefs.SetInt("RECORD", 25);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("_MainMenu");
        }
    }

    public void ShowGameOverPanel(){

        gameOverPanel.gameObject.SetActive(true);
        songs[0].gameObject.GetComponent<AudioSource>().Stop();
        songs[1].gameObject.GetComponent<AudioSource>().Play();
        Invoke("StopGame", 1.0f);
        
    }

    public void StopGame(){
        Time.timeScale = 0.0f;
    }


    public void Restart(){
        SceneManager.LoadScene("Retse_Game");
    }

    public void MainMenu(){
        SceneManager.LoadScene("_MainMenu");
    }
}


