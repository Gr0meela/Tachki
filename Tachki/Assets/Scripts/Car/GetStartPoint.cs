using UnityEngine;

public class GetStartPoint : MonoBehaviour
{
    public Transform startPoint;
    public Transform car;
    private bool firstTime = true;
    private void Update()
    {
        //����������� ���������� ���� ��� �������� ������
        if (car == null)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //��������� ��������� ��������� ������� ��� ���������
        if (other.tag == "Respawn" && firstTime)
        {
            startPoint = other.transform;
            firstTime = false;
        }
    }
}