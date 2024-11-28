using UnityEngine;

public class Player2DAndres : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick joystick;

    [SerializeField]
    private float velocidad = 4;

    [SerializeField]
    private int lifes = 3;

    private bool invulnerable;

    [SerializeField]
    private GameObject lasers;

    private int posLaser;

    [SerializeField]
    private float velLaser;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invulnerable = false;

        velLaser = 10;
        posLaser = 0;

        InvokeRepeating("Fire", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(joystick.Horizontal*Time.deltaTime*velocidad, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invulnerable)
        {
            if (other.gameObject.tag == "Ball1" || other.gameObject.tag == "Ball2" || other.gameObject.tag == "Ball3")
            {
                lifes--;
                Debug.Log(lifes);

                invulnerable = true;
                Invoke("NotInvulnerable", 1.0f);

                if (lifes <= 0)
                {
                    Debug.Log("Has perdido");
                }
            }
        }        
    }

    public void NotInvulnerable()
    {
        invulnerable = false;
    }

    public void Fire()
    {
        lasers.gameObject.transform.GetChild(posLaser).gameObject.transform.position = this.transform.position;
        Rigidbody2D rbLaser = lasers.gameObject.transform.GetChild(posLaser).gameObject.GetComponent<Rigidbody2D>();
        rbLaser.velocityY = velLaser;


        posLaser++;

        if(posLaser >= lasers.gameObject.transform.childCount)
        {
            posLaser = 0;
        }
    }
}
