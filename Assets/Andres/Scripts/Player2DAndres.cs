using UnityEngine;

public class Player2DAndres : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick joystick;

    [SerializeField]
    private float velocidad = 4;

    public int lifes = 3;

    private bool invulnerable;

    [SerializeField]
    private GameObject lasers;

    private int posLaser;

    [SerializeField]
    private float velLaser;

    [SerializeField]
    private UIAndres uIAndresScript;
    [SerializeField]
    private PowerUpsAndres powerUpsAndresScript;

    public bool powerUp1On;
    public bool powerUp2On;

    [SerializeField]
    private GameObject powerUpsRespawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invulnerable = false;

        velLaser = 15;
        posLaser = 0;

        InvokeRepeating("Fire", 0.0f, 0.3f);

        powerUp1On = false;
        powerUp2On = false;
    }

    public void FirePowerUpOn()
    {
        CancelInvoke("Fire");
        InvokeRepeating("Fire", 0.0f, 0.15f);

        Invoke("FirePowerUpStop", 5.0f);
    }

    public void FirePowerUpStop()
    {
        CancelInvoke("Fire");
        InvokeRepeating("Fire", 0.0f, 0.3f);
        powerUp1On = false;
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
                uIAndresScript.PlayerLifesUI();

                Invulnerable(1.0f);

                if (lifes <= 0)
                {
                    Debug.Log("Has perdido");
                }
            }
        }

        if (other.gameObject.tag == "PowerUp")
        {
            if (other.gameObject.name == "PowerUp1")
            {
                if (powerUp1On)
                {
                    FirePowerUpStop();
                }
                FirePowerUpOn();
                powerUp1On = true;

            }
            if (other.gameObject.name == "PowerUp2")
            {
                if (powerUp2On)
                {
                    NotInvulnerable();
                }
                Invulnerable(5.0f);
                powerUp2On = true;
            }
            if (other.gameObject.name == "PowerUp3")
            {
                if(lifes < 5)
                {
                    lifes++;

                    uIAndresScript.PlayerLifesUI();
                }                
            }

            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            other.gameObject.transform.position = powerUpsRespawn.gameObject.transform.position;
        }
    }

    public void Invulnerable(float time)
    {
        invulnerable = true;

        Invoke("NotInvulnerable", time);

        Color newColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        newColor.a = 0.5f;
        this.gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }

    public void NotInvulnerable()
    {
        invulnerable = false;

        powerUp2On = false;

        Color newColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        newColor.a = 1.0f;
        this.gameObject.GetComponent<SpriteRenderer>().color = newColor;
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
