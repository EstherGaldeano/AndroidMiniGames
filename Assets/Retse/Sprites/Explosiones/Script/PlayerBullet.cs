using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
 
    [SerializeField]
    private GameObject gameManager;

    [SerializeField]
    private GameObject bulletExplosions;

    [SerializeField]
    private GameObject sound;


    private int roundRobinValue;
    private int destructionPosition;
    private int increase;


    void Start(){
        roundRobinValue = 0;
        destructionPosition = 300;
        increase = 5;
    }

    private void hideExplosion()
    {
        for (int i = 0; i < bulletExplosions.gameObject.transform.childCount; i++){
            bulletExplosions.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other){

        gameManager.gameObject.GetComponent<UIController>().PointsUpdate(5);
        GameObject bulletExplosionsChild = bulletExplosions.gameObject.transform.GetChild(roundRobinValue).gameObject;

        sound.gameObject.GetComponent<AudioSource>().Play();
        bulletExplosionsChild.transform.position = other.gameObject.transform.position;
        bulletExplosionsChild.SetActive(true);

        Invoke("hideExplosion", 1.0f);
        roundRobinValue++;

        if (roundRobinValue >= bulletExplosions.gameObject.transform.childCount){
            roundRobinValue = 0;
        }

        other.gameObject.transform.position = new Vector2(destructionPosition, 300);
        this.gameObject.transform.position = new Vector2(destructionPosition, 400);

        destructionPosition = destructionPosition + increase;
    }
}


