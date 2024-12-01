using UnityEngine;

public class BallsControllerAndres : MonoBehaviour
{
    [SerializeField]
    private GameObject leftSpawn;
    [SerializeField] 
    private GameObject rightSpawn;
    [SerializeField] 
    private GameObject spawn;
    [SerializeField]
    private GameObject ballsRespawn;
    [SerializeField]
    private GameObject[] listBalls;

    [SerializeField]
    private BallsLifesAndres ballsLifeAndres;

    private int posBall1;
    private int posBall2;
    private int posBall3;
    public int roundNumber;
    private int roundCounter;

    public Vector3 lastDestroyedPosition;
    private int lastDestroyedLifeRound;

    [SerializeField]
    private float forcePower;
    [SerializeField]
    private int forceDirection;

    public Sprite[] numberSprite;

    [SerializeField]
    private GameObject explosionBalls;
    private int posExplosionBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posExplosionBall = 0;

        posBall1 = 0;
        posBall2 = 0;
        posBall3 = 0;
        roundNumber = 1;
        roundCounter = 0;

        InvokeRepeating("SpawnsBalls1", 0.0f, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnsBalls1()
    {
        if(roundCounter == roundNumber)
        {
            roundNumber++;
            roundCounter = 0;
        }

        GameObject ballGameObject;
        ballGameObject = listBalls[0].gameObject.transform.GetChild(posBall1).gameObject;
        //ballGameObject.GetComponent<Collider2D>().enabled = false;
        //Invoke("ActivateCollider", 0.5f);
        Rigidbody2D rb1 = ballGameObject.GetComponent<Rigidbody2D>();
        rb1.gravityScale = 1f;
        rb1.velocityX = 0;
        rb1.velocityY = 0;
        if (Random.value < 0.5f)
        {
            spawn = leftSpawn;
            forceDirection = 1;
        }
        else
        {
            spawn = rightSpawn;
            forceDirection = -1;
        }

        ballGameObject.GetComponent<BallsLifesAndres>().ballLife = roundNumber;
        ballGameObject.GetComponent<BallsLifesAndres>().ballLifeRound = roundNumber;

        ballGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprite[roundNumber];

        ballGameObject.transform.position = new Vector2(spawn.gameObject.transform.position.x, spawn.gameObject.transform.position.y);

        forcePower = Random.Range(75.0f, 100.0f);

        rb1.AddForce(new Vector2(forceDirection * forcePower, 0));

        roundCounter++;

        posBall1++;
        if (posBall1 >= listBalls[0].gameObject.transform.childCount)
        {
            posBall1 = 0;
        }
    }

    public void SpawnsBalls2()
    {
        GameObject ballGameObject;
        ballGameObject = listBalls[1].gameObject.transform.GetChild(posBall2).gameObject;

        //Spawn Ball2 RIGHT
        Rigidbody2D rb = ballGameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.velocityX = 0;
        rb.velocityY = 0;

        ballGameObject.GetComponent<BallsLifesAndres>().ballLife = lastDestroyedLifeRound;
        ballGameObject.GetComponent<BallsLifesAndres>().ballLifeRound = lastDestroyedLifeRound;
        ballGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprite[lastDestroyedLifeRound];

        ballGameObject.transform.position = new Vector2(lastDestroyedPosition.x, 2.0f);

        forcePower = Random.Range(100.0f, 150.0f);

        rb.AddForce(new Vector2(forcePower, 0));

        posBall2++;
        if (posBall2 >= listBalls[1].gameObject.transform.childCount)
        {
            posBall2 = 0;
        }

        GameObject ballGameObject2;
        ballGameObject2 = listBalls[1].gameObject.transform.GetChild(posBall2).gameObject;

        //Spawn Ball2 LEFT
        Rigidbody2D rb2 = ballGameObject2.GetComponent<Rigidbody2D>();
        rb2.gravityScale = 1f;
        rb2.velocityX = 0;
        rb2.velocityY = 0;

        ballGameObject2.GetComponent<BallsLifesAndres>().ballLife = lastDestroyedLifeRound;
        ballGameObject2.GetComponent<BallsLifesAndres>().ballLifeRound = lastDestroyedLifeRound;
        ballGameObject2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprite[lastDestroyedLifeRound];

        ballGameObject2.transform.position = new Vector2(lastDestroyedPosition.x, 2.0f);

        forcePower = Random.Range(100.0f, 150.0f);

        rb2.AddForce(new Vector2(-forcePower, 0));

        posBall2++;
        if (posBall2 >= listBalls[1].gameObject.transform.childCount)
        {
            posBall2 = 0;
        }
    }

    public void SpawnsBalls3()
    {
        GameObject ballGameObject;
        ballGameObject = listBalls[2].gameObject.transform.GetChild(posBall3).gameObject;

        //Spawn Ball3 RIGHT
        Rigidbody2D rb = ballGameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.velocityX = 0;
        rb.velocityY = 0;

        ballGameObject.GetComponent<BallsLifesAndres>().ballLife = lastDestroyedLifeRound;
        ballGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprite[lastDestroyedLifeRound];

        ballGameObject.transform.position = new Vector2(lastDestroyedPosition.x, 2.0f);

        forcePower = Random.Range(100.0f, 150.0f);

        rb.AddForce(new Vector2(forcePower, 0));

        posBall3++;
        if (posBall3 >= listBalls[2].gameObject.transform.childCount)
        {
            posBall3 = 0;
        }

        GameObject ballGameObject2;
        ballGameObject2 = listBalls[2].gameObject.transform.GetChild(posBall3).gameObject;

        //Spawn Ball3 LEFT
        Rigidbody2D rb2 = ballGameObject2.GetComponent<Rigidbody2D>();
        rb2.gravityScale = 1f;
        rb2.velocityX = 0;
        rb2.velocityY = 0;

        ballGameObject2.GetComponent<BallsLifesAndres>().ballLife = lastDestroyedLifeRound;
        ballGameObject2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprite[lastDestroyedLifeRound];

        ballGameObject2.transform.position = new Vector2(lastDestroyedPosition.x, 2.0f);

        forcePower = Random.Range(100.0f, 150.0f);

        rb2.AddForce(new Vector2(-forcePower, 0));

        posBall3++;
        if (posBall3 >= listBalls[2].gameObject.transform.childCount)
        {
            posBall3 = 0;
        }
    }

    public void ActivateCollider()
    {
        listBalls[0].gameObject.transform.GetChild(posBall1).gameObject.GetComponent<Collider2D>().enabled = true;

        posBall1++;
        if (posBall1 >= listBalls[0].gameObject.transform.childCount)
        {
            posBall1 = 0;
        }
    }

    public void ColissionLaser(GameObject ball)
    {
        ball.gameObject.GetComponent<BallsLifesAndres>().BallDamaged();        
    }

    public void BallDestroyed(GameObject ball)
    {
        this.gameObject.GetComponent<UIAndres>().WinPoints();

        explosionBalls.transform.GetChild(posExplosionBall).transform.position = ball.transform.position;
        explosionBalls.transform.GetChild(posExplosionBall).gameObject.SetActive(true);
        posExplosionBall++;
        if(posExplosionBall >= explosionBalls.gameObject.transform.childCount)
        {
            posExplosionBall = 0;
        }
        if(posExplosionBall >= 5)
        {
            explosionBalls.gameObject.transform.GetChild(posExplosionBall-5).gameObject.SetActive(false);
        }
        if(posExplosionBall < 5)
        {
            explosionBalls.gameObject.transform.GetChild(posExplosionBall + 5).gameObject.SetActive(false);
        }

        ball.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        ball.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

        if(ball.gameObject.tag != "Ball3")
        {
            lastDestroyedPosition = ball.gameObject.transform.position;
            lastDestroyedLifeRound = ball.gameObject.GetComponent<BallsLifesAndres>().ballLifeRound;
        }
        
        ball.gameObject.transform.position = ballsRespawn.gameObject.transform.position;

        this.gameObject.GetComponent<PowerUpsAndres>().CheckSpawnPowerUp();       

        if (ball.gameObject.tag == "Ball1")
        {
            SpawnsBalls2();
        }
        if (ball.gameObject.tag == "Ball2")
        {
            SpawnsBalls3();
        }
    }
}
