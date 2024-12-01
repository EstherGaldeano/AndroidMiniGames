using UnityEngine;

public class HorizontalTouchControl : MonoBehaviour
{
    // Altura fija del jugador
    [SerializeField] private float fixedY = -2.36f;

    // Velocidad opcional para hacer el movimiento más suave
    [SerializeField] private float moveSpeed = 20f;

    void Update()
    {
        // Verificar si hay algún toque en la pantalla
        if (Input.touchCount > 0)
        {
            // Capturar el primer toque
            Touch touch = Input.GetTouch(0);

            // Convertir la posición del toque en coordenadas del mundo
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));

            // Asegurar que el jugador se mantenga en su altura fija
            Vector3 targetPosition = new Vector3(touchPosition.x, fixedY, transform.position.z);

            // Mover al jugador suavemente hacia la posición del toque
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
