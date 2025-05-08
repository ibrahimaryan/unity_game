using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPindah : MonoBehaviour
{
    float speed = 2f;
    public Sprite[] sprites;
    private Vector3 screenPoint;
    private Vector3 offset;
    private float firstY;

    // Tambahkan reference ke kayu
    public GameObject kayu;

    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    void Update()
    {
        float move = (speed * Time.deltaTime * -1f) + transform.position.x;
        transform.position = new Vector3(move, transform.position.y);
    }

    void OnMouseDown()  
    {
        firstY = transform.position.y;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        GameObject[] semuaKayu = GameObject.FindGameObjectsWithTag("Kayu");
        GameObject kayuTerdekat = null;
        float jarakTerdekat = Mathf.Infinity;

        foreach (GameObject kayu in semuaKayu)
        {
            float jarakX = Mathf.Abs(transform.position.x - kayu.transform.position.x);
            if (jarakX < jarakTerdekat)
            {
                jarakTerdekat = jarakX;
                kayuTerdekat = kayu;
            }
        }

        if (kayuTerdekat != null)
        {
            float xKayu = kayuTerdekat.transform.position.x;
            transform.position = new Vector3(xKayu, firstY, transform.position.z);
        }
        else
        {
            // fallback kalau tidak ada kayu
            transform.position = new Vector3(transform.position.x, firstY, transform.position.z);
        }
    }
}