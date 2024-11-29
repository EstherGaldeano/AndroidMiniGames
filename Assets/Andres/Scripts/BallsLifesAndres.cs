using UnityEngine;

public class BallsLifesAndres : MonoBehaviour
{
    public int ballLife;
    public int ballLifeRound;


    [SerializeField]
    private BallsControllerAndres ballsControllerAndresScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallDamaged()
    {
        ballLife--;

        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = ballsControllerAndresScript.numberSprite[ballLife];

        if(ballLife <= 0 ) 
        {
            ballsControllerAndresScript.BallDestroyed(this.gameObject);
        }
    }
}
