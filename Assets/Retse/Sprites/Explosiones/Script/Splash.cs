using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{

    public void ChangeScene()
    {
        SceneManager.LoadScene("Retse_Game");
    }
    void Start()
    {
        Invoke("ChangeScene", 3.0f);
    }
}
