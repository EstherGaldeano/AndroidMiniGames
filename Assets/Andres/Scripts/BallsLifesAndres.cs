using UnityEngine;

public class BallsLifesAndres : MonoBehaviour
{
    public int ballLife;
    public int ballLifeRound;

    [SerializeField]
    private BallsControllerAndres ballsControllerAndresScript;  

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
