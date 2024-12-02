using UnityEngine;

public class Tierra : MonoBehaviour
{
    [SerializeField]
    private GameObject acumulador;

    [SerializeField]
    private GameObject explosiones;

    private int valorRR;

    private int i;
    [SerializeField]
    private GameObject sonidoExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valorRR = 0;
    }

    // Update is called once per frame
    void Update()
    {

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
        sonidoExplosion.gameObject.GetComponent<AudioSource>().Play();
        explosiones.gameObject.transform.GetChild(valorRR).gameObject.transform.position = other.gameObject.transform.position;
        explosiones.gameObject.transform.GetChild(valorRR).gameObject.SetActive(true);
        Invoke("OcultarExplosion", 0.3f);
        valorRR++;
        if (valorRR >= explosiones.gameObject.transform.childCount)
        {
            valorRR = 0;
        }
        Destroy(other.gameObject);
        acumulador.gameObject.GetComponent<UIController2>().MostrarPanelDerrota();
        //Destroy(this.gameObject);
    }
}


