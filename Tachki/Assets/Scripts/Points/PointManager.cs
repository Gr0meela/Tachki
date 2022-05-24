using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] private List<Spawner> points = new List<Spawner>();
    private List<int> startPointNumbers = new List<int>();
    private List<int> finishPointNumbers = new List<int>();
    void Start()
    {
        for (int i = 0; i < FindObjectsOfType<Spawner>().Length; i++)
        {
            startPointNumbers.Add(i);
            finishPointNumbers.Add(i);
        }
        SetPoints();
    }

    public void SetPoints()
    {
        //Обнуление всех точек
        points = new List<Spawner>(FindObjectsOfType<Spawner>());
        foreach (Spawner point in points)
        {
            point.gameObject.GetComponent<Spawner>().enabled = false;
            point.gameObject.GetComponent<Finish>().enabled = false;
            point.gameObject.GetComponent<Renderer>().material.color = Color.white;
            point.gameObject.tag = "Untagged";
        }

        int number;
        int subNumber;

        //Задание случайного старта
        //Сначала машина должна по разу появиться на каждой точке
        if (startPointNumbers.Count > 0)
        {
            subNumber = Random.Range(0, startPointNumbers.Count);
            number = startPointNumbers[subNumber];
            startPointNumbers.Remove(number);
        }
        //После этого все дальнейшие точки выбираются абсолютно случайно
        else
        {
            number = Random.Range(0, points.Count);
        }
        points[number].gameObject.tag = "Respawn";
        points[number].gameObject.GetComponent<Spawner>().enabled = true;
        points[number].gameObject.GetComponent<Renderer>().material.color = Color.red;

        //Задание случайного финиша
        //Финиш выбирается из всех оставшихся после определения старта точек
        finishPointNumbers.Remove(number);
        var x = number;

        subNumber = Random.Range(0, finishPointNumbers.Count);
        number = finishPointNumbers[subNumber];
        finishPointNumbers.Add(x);

        points[number].gameObject.GetComponent<Finish>().enabled = true;
        points[number].gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}