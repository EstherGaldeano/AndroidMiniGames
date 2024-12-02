using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIController2 : MonoBehaviour
    
{


   private int puntuacion;
   private int record;

   [SerializeField]
   private GameObject puntuacionUI;

   [SerializeField]
   private GameObject recordUI;

   [SerializeField]
   private GameObject panelDerrota;
    
   public void ActualizarPuntuacion(int incremento)
   {
       puntuacion = puntuacion + incremento;
       ActualizarPuntuacionUI(puntuacion);

       //Actualizar la puntuacion del record
       record = PlayerPrefs.GetInt("RECORD");

       if (puntuacion > record)
       {
           PlayerPrefs.SetInt("RECORD", puntuacion);
           record = PlayerPrefs.GetInt("RECORD");
           ActualizarRecordUI(record);
       }


   }
   public void Reiniciar()
   {
       SceneManager.LoadScene("Juego");
   }
   public void ActualizarPuntuacionUI(int puntos)
   {
       puntuacionUI.gameObject.GetComponent<TMP_Text>().text = puntos.ToString();
   }
   public void ActualizarRecordUI(int puntosRecord)
   {
       recordUI.gameObject.GetComponent<TMP_Text>().text = puntosRecord.ToString();
   }

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
       Time.timeScale = 1.0f;
       puntuacion = 0;
       record = 0;
       ActualizarPuntuacionUI(puntuacion);
       ActualizarRecordUI(record);


       // PlayerPrefs.DeleteAll();
       //PlayerPrefs.DeleteKey("RECORD");

       if (PlayerPrefs.HasKey("RECORD"))
       {
           //Existe
           record = PlayerPrefs.GetInt("RECORD");
           ActualizarRecordUI(record);
       }
       else
       {
           PlayerPrefs.SetInt("RECORD", 0);
           record = PlayerPrefs.GetInt("RECORD");
           ActualizarRecordUI(record);
       }

       PlayerPrefs.SetInt("RECORD", 75);


   }

   public void MostrarPanelDerrota()
   {
       panelDerrota.gameObject.SetActive(true);
       Invoke("DetenerJuego", 2.0f);

   }

   public void DetenerJuego()
   {
       Time.timeScale = 0.0f;
   }

   // Update is called once per frame
   void Update()
   {

   }
}
