using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Pinball : MonoBehaviour
{

    [SerializeField]
    private GameObject pinballBall;

    private Rigidbody2D rbPinballBall;

    [SerializeField]
    private float force;

    [SerializeField]
    private GameObject ButtonLeft;

    [SerializeField]
    private GameObject ButtonRight;

    [SerializeField]
    private GameObject FlippLeft;

    [SerializeField]
    private GameObject FlippRight;

    [SerializeField]
    private GameObject LostDetector;

    [SerializeField]
    private GameObject GameStart;

    [SerializeField]
    private GameObject GameOver;

    [SerializeField]
    private Transform CreationPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        force = 20.0f;
        rbPinballBall = pinballBall.GetComponent<Rigidbody2D>();
        GameStart.gameObject.SetActive(true);
  

        // Reposiciona la bola en el punto de inicio antes de lanzarla
        pinballBall.transform.position = CreationPoint.position;


        
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
            pinballBall.transform.position = CreationPoint.position;

            ButtonLeft.gameObject.SetActive(false);
             ButtonRight.gameObject.SetActive(false);
             GameOver.gameObject.SetActive(true);
        }

    }

    

    public void FlipperLeft()
    {
        FlippLeft.GetComponent<Animator>().SetTrigger("Push");
    }

    public void FlipperRight()
    {
        FlippRight.GetComponent<Animator>().SetTrigger("Push");
    }




     public void StartGame()
     {
         ButtonLeft.gameObject.SetActive(true);
         ButtonRight.gameObject.SetActive(true);
         GameOver.gameObject.SetActive(false);
         GameStart.gameObject.SetActive(false);

         // Reposiciona la bola en el punto de inicio antes de lanzarla
         pinballBall.transform.position = CreationPoint.position;


         //Configuración para se aplique una fuerza al RigidBody de la bola para que salga impulsada hacia arriba al inicio de la partida
         rbPinballBall.AddForce(Vector2.up * force, ForceMode2D.Impulse);

    }


    

}
