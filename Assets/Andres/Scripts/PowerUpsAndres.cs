using UnityEngine;

public class PowerUpsAndres : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUpsList;

    private int posPowerUp = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShuffleArray(powerUpsList);
    }

    public void ShuffleArray(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);

            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void CheckSpawnPowerUp()
    {
        int randomNumber = Random.Range(0, 100);

        if (randomNumber < 20)
        {
            SelectPowerUp();
        }
    }

    public void SelectPowerUp()
    {
        GameObject selectedPowerUp = powerUpsList[posPowerUp];

        selectedPowerUp.gameObject.transform.position = new Vector2(this.gameObject.GetComponent<BallsControllerAndres>().lastDestroyedPosition.x, 2.0f);
        Rigidbody2D rb = selectedPowerUp.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.velocityX = 0;
        rb.velocityY = 0;

        posPowerUp++;
        if (posPowerUp >= powerUpsList.Length)
        {
            posPowerUp = 0;
        }
    }
}
