using UnityEngine;

public class RotationButton : MonoBehaviour
{
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject straight;
    [SerializeField] private Transform currentTransform;
    public int direction = 0;

    private void Start()
    {
        SetNewCar();
    }

    //При нажатии и отжатии кнопки машина оставляет пометку. Когда машина управляется ИИ, при заезде на пометку она будет выполнять соответствующий поворот
    public void OnLeftButtonDown()
    {
        direction = -1;
        GameObject point = Instantiate(left, currentTransform.position, currentTransform.rotation) as GameObject;
        point.name = currentTransform.parent.name;
    }
    public void OnRightButtonDown()
    {
        direction = 1;
        GameObject point = Instantiate(right, currentTransform.position, currentTransform.rotation) as GameObject;
        point.name = currentTransform.parent.name;
    }
    public void OnButtonUp()
    {
        direction = 0;
        GameObject point = Instantiate(straight, currentTransform.position, currentTransform.rotation) as GameObject;
        point.name = currentTransform.parent.name;
    }
    public void SetNewCar()
    {
        currentTransform = GameObject.FindGameObjectWithTag("Drop Checkpoint").GetComponent<Transform>();
    }
}
