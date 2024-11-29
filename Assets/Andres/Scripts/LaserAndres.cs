using UnityEngine;
using UnityEngine.UIElements;

public class LaserAndres : MonoBehaviour
{
    [SerializeField]
    private BallsControllerAndres ballsControllerAndresScript;

    [SerializeField]
    private GameObject lasersParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball1" || other.gameObject.tag == "Ball2" || other.gameObject.tag == "Ball3")
        {
            ballsControllerAndresScript.ColissionLaser(other.gameObject);
            this.gameObject.transform.position = lasersParent.gameObject.transform.position;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }
}