using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speedProp;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = speedProp / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        //move obj down at specified speed
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }
}
