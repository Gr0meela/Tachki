using UnityEngine;

public class CarRemover : MonoBehaviour
{
    [SerializeField] private GameObject currentCar;
    private Spawner spawner;
    private int carCounter = 0;
    void Start()
    {
        spawner = GetComponent<Spawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //���������� ����������� ������
        if(other.tag == "Player" && spawner.enabled && carCounter < 1)
        {
            currentCar = other.gameObject;
            carCounter++;
        }
        //���� �� ���� ����� ��� ���������� ������, ����������� ������ ���������, � �� � ����� ����������� �����
        else if (other.tag == "Player" && spawner.enabled && carCounter >= 1)
        {
            Destroy(currentCar.transform.root.gameObject);
            foreach (GameObject obj in currentCar.GetComponent<PointChecker>().checkpoints)
                Destroy(obj);
            currentCar = other.gameObject;
        }
    }
}
