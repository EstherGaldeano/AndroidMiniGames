using UnityEngine;

public class Player2DAndres : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick joystick;

    [SerializeField]
    private float velocidad = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(joystick.Horizontal*Time.deltaTime*velocidad, 0.0f, 0.0f);
    }
}
