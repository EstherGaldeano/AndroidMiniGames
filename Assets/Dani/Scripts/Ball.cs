using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rbPinballBall;

    private float hitForce;

    [SerializeField]
    private GameObject FlippLeft;

    [SerializeField]
    private GameObject FlippRight;

    [SerializeField]
    private GameObject scoreUI;

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreUI.GetComponent<TMP_Text>().text = score.ToString();
        hitForce = 100.0f;
        rbPinballBall = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)

    {
        if (other.gameObject.tag == "FlipperRight")
        {
            hitForce = Random.Range(70.0f, 100.0f);
            Vector2 direction = (this.gameObject.transform.position - FlippRight.transform.position).normalized; // Dirección opuesta al flipper
           // rbPinballBall.AddForce(direction * hitForce, ForceMode2D.Impulse);  // Aplicar el impulso
           rbPinballBall.velocity = direction * hitForce;  // Actualizar la velocidad
            // Opcional: imprime información para depuración
            Debug.Log("La bola golpeó el flipper: ");
            score = score + 20;
            scoreUI.GetComponent<TMP_Text>().text = score.ToString();
        }

        if (other.gameObject.tag == "FlipperLeft")
        {
            hitForce = Random.Range(70.0f, 100.0f);
            Vector2 direction = (this.gameObject.transform.position - FlippLeft.transform.position).normalized; // Dirección opuesta al flipper
            rbPinballBall.AddForce(direction * hitForce, ForceMode2D.Impulse);  // Aplicar el impulso
            // Opcional: imprime información para depuración
            Debug.Log("La bola golpeó el flipper: ");
            score = score + 20;
            scoreUI.GetComponent<TMP_Text>().text = score.ToString();
        }

        if (other.gameObject.tag == "Score10")
        {
            score = score + 10;
            scoreUI.GetComponent<TMP_Text>().text = score.ToString();
        }

        if (other.gameObject.tag == "Score20")
        {
            score = score + 20;
            scoreUI.GetComponent<TMP_Text>().text = score.ToString();
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LostDetector")
        {
            //Reiniciamos puntuacion
            score = 0;
            scoreUI.GetComponent<TMP_Text>().text = score.ToString();
        }
    }

}
