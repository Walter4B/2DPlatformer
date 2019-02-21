using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class Ladder : MonoBehaviour {

    private float Speed = 3;
    private float Stand = 0.2f;

    private void OnTriggerStay2D(Collider2D other)
        
    {
        //if(other.tag == "Player" && Input.GetKey(KeyCode.W))
        if (other.tag == "Player" && CrossPlatformInputManager.GetAxisRaw("Vertical") > 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
        }

        else if (other.tag == "Player" && CrossPlatformInputManager.GetAxisRaw("Vertical") < 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Speed);
        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Stand);
        }
    }
}
