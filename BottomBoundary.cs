using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
    //make sure bottom boundaries destroy the stray game objects (resource management)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "EnemyBullet") || (other.tag == "PlayerBullet") || (other.tag == "Shield") || (other.tag == "Bomb") || (other.tag == "Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
