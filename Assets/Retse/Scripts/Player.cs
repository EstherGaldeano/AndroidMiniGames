using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick dynamicJoystick;
    [SerializeField]
    [Range (1,10)]
    private float speed;

    [SerializeField]
    private GameObject explosions;

    [SerializeField]
    private GameObject playerBullets;

    private int roundRobinValue;
    private int bulletRoundRobinValue;


    void Start()
    {
        roundRobinValue = 0;
        bulletRoundRobinValue = 0;
        InvokeRepeating("Shoot",0.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(dynamicJoystick.Horizontal * Time.deltaTime * speed, dynamicJoystick.Vertical * Time.deltaTime * speed, 0.0f);
    }

    public void shoot(){

        playerBullets.gameObject.transform.GetChild(bulletRoundRobinValue).gameObject.transform.position = this.gameObject.transform.position;

        bulletRoundRobinValue++;  

        // if(bulletRoundRobinValue >= playerBullets.gameObject.transform.childCount){

        //     bulletRoundRobinValue = 0;
        // }

    }

    private void hideExplosion(){

        for (int i =0 ; i<explosions.gameObject.transform.childCount; i++){
             explosions.gameObject.transform.GetChild(roundRobinValue).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag != "playerBullets"){

            explosions.gameObject.transform.GetChild(roundRobinValue).gameObject.transform.position = this.gameObject.transform.position;
            explosions.gameObject.transform.GetChild(roundRobinValue).gameObject.SetActive(true);
            Invoke("hideExplosion" , 0.3f);
            roundRobinValue++;

            if(roundRobinValue>=explosions.gameObject.transform.childCount){
                roundRobinValue = 0;
            }
            
            Destroy(other.gameObject);
            // Destroy(this.gameObject);

        }
      
    }
}
