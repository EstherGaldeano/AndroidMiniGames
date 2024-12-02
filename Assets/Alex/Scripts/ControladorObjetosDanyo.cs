using System.Collections;
using UnityEngine;

public class ControladorObjetosDanyo : MonoBehaviour
{

    [SerializeField]
    private GameObject limiteI;

    [SerializeField]
    private GameObject limiteD;

    [SerializeField]
    private GameObject[] listadosObjetosDanyo;
    private int[] valorRR;

    private int listadoAleatorio;


    private float posicionXAleatoria;

    private float velocidadPosicionamiento;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidadPosicionamiento = 2.0f;
        valorRR = new int[listadosObjetosDanyo.Length];
        //InvokeRepeating("CambiarPosicion", 0.0f, 2.0f);

        StartCoroutine(CambioDePosicion());

    }

    IEnumerator CambioDePosicion()
    {

        while (true)
        {

            yield return new WaitForSeconds(velocidadPosicionamiento);
            velocidadPosicionamiento = velocidadPosicionamiento - 0.01f;
            if (velocidadPosicionamiento < 0.5)
            {
                velocidadPosicionamiento = 0.5f;
            }
            CambiarPosicion();

        }



    }


    public void CambiarPosicion()
    {

        posicionXAleatoria = Random.Range(limiteI.gameObject.transform.position.x, limiteD.gameObject.transform.position.x);
        listadoAleatorio = Random.Range(0, listadosObjetosDanyo.Length);

        listadosObjetosDanyo[listadoAleatorio].gameObject.transform.GetChild(valorRR[listadoAleatorio]).gameObject.transform.position = new Vector2(posicionXAleatoria, limiteI.gameObject.transform.position.y);
        listadosObjetosDanyo[listadoAleatorio].gameObject.transform.GetChild(valorRR[listadoAleatorio]).gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        listadosObjetosDanyo[listadoAleatorio].gameObject.transform.GetChild(valorRR[listadoAleatorio]).gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;

        valorRR[listadoAleatorio]++;
        if (valorRR[listadoAleatorio] >= listadosObjetosDanyo[listadoAleatorio].gameObject.transform.childCount)
        {
            valorRR[listadoAleatorio] = 0;
        }

    }



    // Update is called once per frame
    void Update()
    {

    }
}
