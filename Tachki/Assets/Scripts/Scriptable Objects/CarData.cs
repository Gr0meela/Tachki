using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData")]
public class CarData : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
    public GameObject model;
}
