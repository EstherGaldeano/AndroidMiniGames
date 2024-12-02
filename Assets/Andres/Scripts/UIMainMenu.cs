using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject panels;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < panels.gameObject.transform.childCount; i++)
        {
            panels.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("_MainMenu");
        }
    }

    public void GoToPanel(int panelNumber)
    {
        for(int i = 0; i < panels.gameObject.transform.childCount; i++)
        {
            panels.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        panels.gameObject.transform.GetChild(panelNumber).gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToGame(string gameScene)
    {
        SceneManager.LoadScene(gameScene);
    }
}
