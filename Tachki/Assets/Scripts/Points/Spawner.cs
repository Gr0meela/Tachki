using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnedCar;
    [SerializeField] private RotationButton button;
    void Start()
    {
        button = FindObjectOfType<RotationButton>();
    }
    private void OnEnable()
    {
        GameObject car = Instantiate(spawnedCar, transform.position, transform.rotation) as GameObject;
        car.name = gameObject.name + "car";
        button.SetNewCar();
    }
}