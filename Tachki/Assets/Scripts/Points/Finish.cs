using UnityEngine;

public class Finish : MonoBehaviour
{
    private PointManager pointManager;
    private void Start()
    {
        pointManager = GameObject.FindObjectOfType<PointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            // Все машины перемещаются на свои стартовые позиции
            AllCarsToStart();
            other.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Drop Checkpoint").tag = "Untagged";
            // Отключаются компоненты управления машиной игроком и включаются компоненты ИИ
            other.GetComponentInParent<RotateCar>().enabled = false;
            other.GetComponentInParent<CarAI>().enabled = true;
            other.GetComponent<PointChecker>().enabled = true;

            // Задается новая точка старта, на которой создается новая машина
            pointManager.SetPoints();

            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Left"))
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Right"))
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Straight"))
            {
                obj.SetActive(true);
            }

            // Увеличение счёта
        }
    }

    void AllCarsToStart()
    {
        foreach (GameObject sphere in GameObject.FindGameObjectsWithTag("Motor Sphere"))
        {
            sphere.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetStartPoint point = sphere.GetComponentInChildren<GetStartPoint>();
            sphere.transform.position = point.startPoint.position;
            point.car.rotation = point.startPoint.rotation;
        }
    }
}