using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfekSuara : MonoBehaviour
{
    public AudioSource hitSound; // untuk DUK
    public AudioSource explosionSound; // untuk DUAR
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
    Debug.Log("Meteor collided with: " + collision.gameObject.name);
    if (collision.gameObject.tag == "paddle_biru" || collision.gameObject.tag == "paddle_merah")
    {
         if (hitSound != null)
            hitSound.Play();
    }
    else if (collision.gameObject.tag == "goalKiri" || collision.gameObject.tag == "goalKanan")
    {
        if (explosionSound != null)
            explosionSound.Play();
    }
    }
}
