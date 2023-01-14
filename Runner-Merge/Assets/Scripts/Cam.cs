using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float moveSpeed;
    public UI_Control control;
    void Update()
    {
        if (control.gameStart)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }      
    }
}
