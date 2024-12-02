using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Pinball : MonoBehaviour
{

    [SerializeField]
    private GameObject pinballBall;

    private Rigidbody2D rbPinballBall;

    [SerializeField]
    private float force;

    [SerializeField]
    private GameObject buttonLeft;

    [SerializeField]
    private GameObject buttonRight;

    [SerializeField]
    private GameObject flippLeft;

    [SerializeField]
    private GameObject flippRight;

    [SerializeField]
    private GameObject lostDetector;

    [SerializeField]
    private GameObject door;

    [SerializeField]
    private GameObject gameStart;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private Transform creationPoint;

    [SerializeField]
    private GameObject sounds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        force = 20.0f;
        rbPinballBall = pinballBall.GetComponent<Rigidbody2D>();
        gameStart.gameObject.SetActive(true);
  

        // Reposiciona la bola en el punto de inicio antes de lanzarla
        pinballBall.transform.position = creationPoint.position;


        
    }

    // Update is called once per frame
    void Update()
    {     

        


    }

    public void OnTriggerEnter2D (Collider2D other)
    {
         if (other.CompareTag("PinballBall"))
         {
             Debug.Log("Game Over");
            // Reposiciona la bola en el punto de inicio antes de lanzarla
            pinballBall.transform.position = creationPoint.position;
            door.GetComponent<Animator>().SetBool("Action", false);
            buttonLeft.gameObject.SetActive(false);
             buttonRight.gameObject.SetActive(false);
             gameOver.gameObject.SetActive(true);
         }

    }

    

    public void FlipperLeft()
    {
        flippLeft.GetComponent<Animator>().SetTrigger("Push");
        sounds.gameObject.transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
    }

    public void FlipperRight()
    {
        flippRight.GetComponent<Animator>().SetTrigger("Push");
        sounds.gameObject.transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
    }




     public void StartGame()
     {
         buttonLeft.gameObject.SetActive(true);
         buttonRight.gameObject.SetActive(true);
         gameOver.gameObject.SetActive(false);
         gameStart.gameObject.SetActive(false);

         // Reposiciona la bola en el punto de inicio antes de lanzarla
         pinballBall.transform.position = creationPoint.position;


         //Configuración para se aplique una fuerza al RigidBody de la bola para que salga impulsada hacia arriba al inicio de la partida
         rbPinballBall.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        sounds.gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
    }


    

}
