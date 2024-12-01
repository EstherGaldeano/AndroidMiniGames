using UnityEngine;

public class Pinball : MonoBehaviour
{

    [SerializeField]
    private GameObject pinballBall;

    private Rigidbody2D rbPinballBall;

    [SerializeField]
    private float force;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        force = 20.0f;
        rbPinballBall = pinballBall.GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbPinballBall.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                
        }
    }



}
