using UnityEngine;

public class Player2DAndres : MonoBehaviour
{
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

    [SerializeField]
    private GameObject explosion;

    public GameObject[] sounds;

    public bool explosionSoundPlayed = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invulnerable = false;

        velLaser = 15;
        posLaser = 0;

        InvokeRepeating("Fire", 0.5f, 0.3f);

        powerUp1On = false;
        powerUp2On = false;

        float halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invulnerable)
        {
            if (other.gameObject.tag == "Ball1" || other.gameObject.tag == "Ball2" || other.gameObject.tag == "Ball3")
            {
                lifes--;

                sounds[4].gameObject.GetComponent<AudioSource>().Play();

                uIAndresScript.PlayerLifesUI();

                Invulnerable(1.0f);

                if (lifes <= 0)
                {
                    uIAndresScript.timeActive = false;

                    CancelInvoke("Fire");

                    this.gameObject.GetComponent<Collider2D>().enabled = false;
                    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    explosion.gameObject.transform.position = this.gameObject.transform.position;
                    explosion.gameObject.SetActive(true);

                    if (!explosionSoundPlayed)
                    {
                        explosionSoundPlayed = true;
                        sounds[3].gameObject.GetComponent<AudioSource>().Play();
                    }

                    Invoke("GameOver", 2.0f);
                }
            }
        }

        if (other.gameObject.tag == "PowerUp")
        {
            sounds[1].gameObject.GetComponent<AudioSource>().Play();

            if (other.gameObject.name == "PowerUp1")
            {
                if (powerUp1On)
                {
                    CancelInvoke("FirePowerUpStop");
                    FirePowerUpStop();
                }
                FirePowerUpOn();
                powerUp1On = true;

            }
            if (other.gameObject.name == "PowerUp2")
            {
                CancelInvoke("NotInvulnerable");

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

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        uIAndresScript.TimeRecord();
    }

    public void Invulnerable(float time)
    {
        invulnerable = true;

        Debug.Log("Invulnerable");

        Invoke("NotInvulnerable", time);

        Color newColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        newColor.a = 0.5f;
        this.gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }

    public void NotInvulnerable()
    {
        invulnerable = false;

        Debug.Log("Not invulnerable");

        powerUp2On = false;

        Color newColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        newColor.a = 1.0f;
        this.gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }

    public void Fire()
    {
        lasers.gameObject.transform.GetChild(posLaser).gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.4f, this.transform.position.z);
        Rigidbody2D rbLaser = lasers.gameObject.transform.GetChild(posLaser).gameObject.GetComponent<Rigidbody2D>();
        rbLaser.velocityY = velLaser;

        sounds[0].gameObject.GetComponent<AudioSource>().Play();

        posLaser++;

        if(posLaser >= lasers.gameObject.transform.childCount)
        {
            posLaser = 0;
        }
    }
}
