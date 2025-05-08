using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPindahKayu : MonoBehaviour
{

    float speed = 2f;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
     float move = (speed * Time.deltaTime * -1f) + transform.position.x;
    transform.position = new Vector3(move, transform.position.y);
    }
}
