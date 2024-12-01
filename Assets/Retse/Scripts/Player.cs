using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick floatingJoystick;
    [SerializeField]
    [Range (1,10)]
    private float speed;

     [SerializeField]
    private GameObject gameManager;

    [SerializeField]
    private GameObject explosions;

    [SerializeField]
    private GameObject playerBullets;

    [SerializeField]
    private GameObject[] sounds;

    private int roundRobinValue;
    private int bulletRoundRobinValue;
     private float shootVelocity;
  


    void Start()
    {
        shootVelocity = 1.0f;
        roundRobinValue = 0;
        bulletRoundRobinValue = 0;
        //InvokeRepeating("shoot",0.0f,1.0f);
        StartCoroutine(ShootBullet());
    }


    IEnumerator ShootBullet(){
        while(true){
            yield return new WaitForSeconds(shootVelocity);
            shootVelocity = shootVelocity -0.005f;
                if (shootVelocity < 0.3){
                    shootVelocity = 0.3f;
            }
            shoot();
        }
    }

 


    void Update()
    {
        this.gameObject.transform.Translate(floatingJoystick.Horizontal * Time.deltaTime * speed, floatingJoystick.Vertical * Time.deltaTime * speed, 0.0f);
    }

    public void shoot(){

        sounds[1].gameObject.GetComponent<AudioSource>().Play();
        GameObject playerBulletChild = playerBullets.gameObject.transform.GetChild(bulletRoundRobinValue).gameObject;
        playerBulletChild.transform.position = this.gameObject.transform.position;
        playerBulletChild.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f , 10.0f); 

        bulletRoundRobinValue++;  

        if(bulletRoundRobinValue >= playerBullets.gameObject.transform.childCount){
            bulletRoundRobinValue = 0;
        }

    }

    private void hideExplosion(){

        for (int i =0 ; i<explosions.gameObject.transform.childCount; i++){
             explosions.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag != "PlayerBullets"){      
            GameObject explosionChilds = explosions.gameObject.transform.GetChild(roundRobinValue).gameObject;

            //sounds[0].gameObject.GetComponent<AudioSource>().Play(); // sonido cuando golpea al player, usar solo si necesario
            explosionChilds.transform.position = this.gameObject.transform.position;
            explosionChilds.SetActive(true);
            Invoke("hideExplosion" , 0.3f);
            roundRobinValue++;

            if(roundRobinValue>=explosions.gameObject.transform.childCount){
                roundRobinValue = 0;
            }
            
            Destroy(other.gameObject);
            gameManager.gameObject.GetComponent<UIController>().ShowGameOverPanel();
            Destroy(this.gameObject);

        }
      
    }
}
