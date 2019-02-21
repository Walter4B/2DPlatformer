using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunCheck : MonoBehaviour
{
    public float BouncePower = 10.0f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>().ToggleStun(true);

            //koristit gotovu Jum metodu od igraca, kad bi postojala
            other.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * BouncePower, ForceMode2D.Impulse);
        }
    }
}
