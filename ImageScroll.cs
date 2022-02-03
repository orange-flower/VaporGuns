using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScroll : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    //update is called once per frame

    void Update()
    {
        transform.Translate(translation: Vector2.left*speed*Time.deltaTime);
       if (transform.position.x < -600f)
        {
         transform.position = StartPosition;
        }
    }
}

