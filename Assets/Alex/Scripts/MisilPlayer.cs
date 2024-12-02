using UnityEngine;

public class MisilPlayer : MonoBehaviour
{


    [SerializeField]
    private GameObject acumulador;

    [SerializeField]
    private GameObject explosionesMisiles;

    [SerializeField]
    private GameObject[] sonidos;


    private int valorRR;

    private int i;

    private int posDestruccion;
    private int incremento;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valorRR = 0;
        posDestruccion = 300;
        incremento = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OcultarExplosion()
    {
        for (i = 0; i < explosionesMisiles.gameObject.transform.childCount; i++)
        {
            explosionesMisiles.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        acumulador.gameObject.GetComponent<UIController2>().ActualizarPuntuacion(5);
        sonidos[0].gameObject.GetComponent<AudioSource>().Play();
        explosionesMisiles.gameObject.transform.GetChild(valorRR).gameObject.transform.position = other.gameObject.transform.position;
        explosionesMisiles.gameObject.transform.GetChild(valorRR).gameObject.SetActive(true);
        Invoke("OcultarExplosion", 1.0f);
        valorRR++;
        if (valorRR >= explosionesMisiles.gameObject.transform.childCount)
        {
            valorRR = 0;
        }

        other.gameObject.transform.position = new Vector2(posDestruccion, 300);
        this.gameObject.transform.position = new Vector2(posDestruccion, 400);

        posDestruccion = posDestruccion + incremento;
    }
}
