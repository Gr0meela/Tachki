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
            // ��� ������ ������������ �� ���� ��������� �������
            AllCarsToStart();
            other.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Drop Checkpoint").tag = "Untagged";
            // ����������� ���������� ���������� ������� ������� � ���������� ���������� ��
            other.GetComponentInParent<RotateCar>().enabled = false;
            other.GetComponentInParent<CarAI>().enabled = true;
            other.GetComponent<PointChecker>().enabled = true;

            // �������� ����� ����� ������, �� ������� ��������� ����� ������
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

            // ���������� �����
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