using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScroller : MonoBehaviour
{
    [Header("Скорость трека в БПМ")]
    public float notesTempo;
    public bool hasStarted;

    void Start()
    {
        notesTempo = notesTempo / 60f;
    }

    
    void Update()
    {
        if (!hasStarted)
        {
           /* if (Input.anyKey)
            {
                hasStarted = true;
            } */
        } else
        {
            transform.position -= new Vector3(0f, notesTempo * Time.deltaTime, 0f);
        }
    }
}
