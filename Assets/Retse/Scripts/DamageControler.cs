using System.Diagnostics;
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
    private int[] roundRobinValue;

    private int bulletPosition;
    private float randomPositionX;
    private int randomList;

    void Start()
    {
        roundRobinValue = new int[damageList.Length];
        InvokeRepeating("ChangePosition", 0.0f, 2.0f);
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition(){
        randomPositionX = Random.Range(leftLimit.gameObject.transform.position.x, rightLimit.gameObject.transform.position.x);
        randomList = Random.Range (0,damageList.Length);
        GameObject damageItem = damageList[randomList];
        GameObject damageChild = damageItem.gameObject.transform.GetChild(roundRobinValue[randomList]).gameObject;
        damageChild.transform.position = new UnityEngine.Vector2(randomPositionX, leftLimit.gameObject.transform.position.y);
        damageChild.GetComponent<Rigidbody2D>().gravityScale = 0.2F;

        roundRobinValue[randomList]++;

        if(roundRobinValue[randomList] >= damageItem.gameObject.transform.childCount){
                roundRobinValue[randomList] = 0;
        }
        
    }

}