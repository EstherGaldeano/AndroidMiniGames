using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class DamageControler : MonoBehaviour
{
    [SerializeField]
    private GameObject leftLimit;
    
    [SerializeField]
    private GameObject rightLimit;

    [SerializeField]
    private GameObject[] damageList;

    private int bulletPosition;
    private float randomPositionX;


    void Start()
    {
        bulletPosition = 0;
        InvokeRepeating("ChangeBulletsPosition", 0.0f, 2.0f);
       
    }

    // public void ChangeBulletsPosition(){
    //     randomPositionX = Random.Range(leftLimit.gameObject.transform.position.x, rightLimit.gameObject.transform.position.x);

    //     bullets.gameObject.transform.GetChild(bulletPosition).gameObject.transform.position = new UnityEngine.Vector2(randomPositionX, rightLimit.gameObject.transform.position.y);
    //     bullets.gameObject.transform.GetChild(bulletPosition).gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
    //     bulletPosition++;

    //     if (bulletPosition >= bullets.gameObject.transform.childCount){
    //         bulletPosition = 0;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
