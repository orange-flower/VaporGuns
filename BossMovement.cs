using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Transform targetPos;
    public float speedProp;
    private float speed;

    void Start()
    {
        //setup
        speed = speedProp / 60f;
        targetPos = GameObject.Find("Boss Position").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //move boss to target position and stop there
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
    }
}
