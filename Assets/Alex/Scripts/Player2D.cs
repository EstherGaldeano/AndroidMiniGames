using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class Player2D : MonoBehaviour
{

    [SerializeField]
    private FloatingJoystick fj;
    [SerializeField]
    [Range(1, 10)]
    private float velocidad;

    [SerializeField]
    private GameObject explosiones;

    [SerializeField]
    private GameObject misilesPlayer;

    private int valorRR;

    private int i;

    private int valorRRMisil;

    [SerializeField]
    private GameObject[] sonidos;

    [SerializeField]
    private GameObject acumulador;

    private float velocidadDisparo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidadDisparo = 1.0f;
        valorRRMisil = 0;
        valorRR = 0;
        // InvokeRepeating("Disparar", 0.0f, 1.0f);
        StartCoroutine(DispararMisil());
    }


    IEnumerator DispararMisil()
    {
        while (true)
        {

            yield return new WaitForSeconds(velocidadDisparo);
            velocidadDisparo = velocidadDisparo - 0.005f;
            if (velocidadDisparo < 0.3)
            {
                velocidadDisparo = 0.3f;
            }
            Disparar();

        }



    }
    public void Disparar()
    {

        sonidos[1].gameObject.GetComponent<AudioSource>().Play();
        misilesPlayer.gameObject.transform.GetChild(valorRRMisil).gameObject.transform.position = this.gameObject.transform.position;
        misilesPlayer.gameObject.transform.GetChild(valorRRMisil).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 10.0f);
        valorRRMisil++;
        if (valorRRMisil >= misilesPlayer.gameObject.transform.childCount)
        {
            valorRRMisil = 0;
        }

    }
    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("V: "+fj.Vertical);
        Debug.Log("H:"+fj.Horizontal);*/

        this.gameObject.transform.Translate(fj.Horizontal * Time.deltaTime * velocidad, fj.Vertical * Time.deltaTime * velocidad, 0.0f);


    }

    private void OcultarExplosion()
    {
        for (i = 0; i < explosiones.gameObject.transform.childCount; i++)
        {
            explosiones.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("El objeto es: " + other.gameObject.name);
        if (other.gameObject.tag != "MisilPlayer")
        {
            sonidos[0].gameObject.GetComponent<AudioSource>().Play();
            explosiones.gameObject.transform.GetChild(valorRR).gameObject.transform.position = this.gameObject.transform.position;
            explosiones.gameObject.transform.GetChild(valorRR).gameObject.SetActive(true);
            Invoke("OcultarExplosion", 0.3f);
            valorRR++;
            if (valorRR >= explosiones.gameObject.transform.childCount)
            {
                valorRR = 0;
            }
            Destroy(other.gameObject);
            acumulador.gameObject.GetComponent<UIController2>().MostrarPanelDerrota();
            Destroy(this.gameObject);
        }
    }



}
