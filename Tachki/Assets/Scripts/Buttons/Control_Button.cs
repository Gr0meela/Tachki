using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Button : MonoBehaviour
{
    protected Controller player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }
    public void ButtonUp()
    {
        player.input = 0f;
    }
}
