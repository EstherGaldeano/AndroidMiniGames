using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{

    void Start()
    {
        Invoke("ChangeScene", 3.0f);
    }

    
    public void ChangeScene()
    {
        SceneManager.LoadScene("Retse_Game");
    }
}
