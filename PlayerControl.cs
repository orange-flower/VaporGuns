using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D player1RB;
    [SerializeField] private Rigidbody2D player2RB;

    // Start is called before the first frame update
    void Start()
    {
        //player1Emitter.SetActive(false);
        //player2Emitter.SetActive(false);
        speed = 17f;
        StartCoroutine(DelayMovement());
    }

    // Update is called once per frame
    void Update()
    {
        //constantly call function to move player
        if (player1RB != null)
        {
            PlayerMovement("Horizontal1", "Vertical1", player1RB);
        }
        if (player2RB != null)
        {
            PlayerMovement("Horizontal2", "Vertical2", player2RB);
        }
    }

    //this function checks the horizontal and vertical axis and moves the player according to the specified speed
    private void PlayerMovement(string hor, string ver, Rigidbody2D rb)
    {
        float h = Input.GetAxis(hor);
        float v = Input.GetAxis(ver);

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        //rb.MovePosition(rb.transform.position + tempVect);
        rb.velocity = tempVect * speed;
    }

    //prevent the player from moving for 0.5 seconds in the beginning 
    // this prevents the player from moving before everything is loaded in 
    IEnumerator DelayMovement()
    {
        player1RB.gameObject.SetActive(false);
        if (!Tracker.track.isSingleMode)
        {
            player2RB.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(0.5f);

        player1RB.gameObject.SetActive(true);
        if (!Tracker.track.isSingleMode)
        {
            player2RB.gameObject.SetActive(true);
        }
    }

}
