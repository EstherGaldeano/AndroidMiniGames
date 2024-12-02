using UnityEngine;

public class HorizontalTouchControl : MonoBehaviour
{
    [SerializeField] 
    private float fixedY = -2.36f;

    [SerializeField] 
    private float moveSpeed = 20f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));

            Vector3 targetPosition = new Vector3(touchPosition.x, fixedY, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
