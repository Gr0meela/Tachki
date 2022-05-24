using UnityEngine;
using System.Collections.Generic;

public class PointChecker : MonoBehaviour
{
    public int direction = 0;
    public List<GameObject> checkpoints = new List<GameObject>();
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left" && transform.parent.name == other.name)
        {
            if (enabled)
            {
                direction = -1;
                other.gameObject.SetActive(false);
            }
            checkpoints.Add(other.gameObject);
        }
        if (other.tag == "Right" && transform.parent.name == other.name)
        {
            if (enabled)
            {
                direction = 1;
                other.gameObject.SetActive(false);
            }
            checkpoints.Add(other.gameObject);
        }
        if (other.tag == "Straight" && transform.parent.name == other.name)
        {
            if (enabled)
            {
                direction = 0;
                other.gameObject.SetActive(false);
            }
            checkpoints.Add(other.gameObject);
        }
    }
}
