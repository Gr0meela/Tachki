using UnityEngine;

public class GetStartPoint : MonoBehaviour
{
    public Transform startPoint;
    public Transform car;
    private bool firstTime = true;
    private void Update()
    {
        //Уничтожение двигающего шара при удалении машины
        if (car == null)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Получение координат стартовой позиции при появлении
        if (other.tag == "Respawn" && firstTime)
        {
            startPoint = other.transform;
            firstTime = false;
        }
    }
}