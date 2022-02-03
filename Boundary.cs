using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    //make sure boundaries destroy all stray game objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "EnemyBullet") || (other.tag == "PlayerBullet") || (other.tag == "Shield") || (other.tag == "Bomb"))
        {
            Destroy(other.gameObject);
        }
    }
}
