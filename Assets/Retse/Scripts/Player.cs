using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick dynamicJoystick;
    [SerializeField]
    [Range (1,10)]
    private float speed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(dynamicJoystick.Horizontal * Time.deltaTime * speed, dynamicJoystick.Vertical * Time.deltaTime * speed, 0.0f);
    }
}
