using UnityEngine;

public class StartDoor : MonoBehaviour
{
    /*Script para que se cierre la parte derecha, en la recta donde sale disparada la bola
      para no volver a meterse ahí a mitad de partida. La mecanica es facil. Hay un trigger
      invisible que detectará la bola al salir disparada. Cuando haya colision, una parte
      de esa estructura se moverá para cerrar ese pasillo con una animación.
     */

    [SerializeField]
    private GameObject door;

    [SerializeField]
    private GameObject detectorTrigger;

    [SerializeField]
    private GameObject pinballBall;

    [SerializeField]
    private GameObject lostDetector;

    [SerializeField]
    private Transform creationPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PinballBall")
        {
            door.GetComponent<Animator>().SetBool("Action", true);
        }

    }
}
