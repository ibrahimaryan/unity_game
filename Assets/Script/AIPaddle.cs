using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;
    public Rigidbody2D ballRb;
    public float kecepatan;
    public float batasAtas;
    public float batasBawah;
    public float batasKanan;
    public float batasKiri;

    private Vector2 posisiIdle;

    void Start()
    {
        // Titik tengah area paddle
        posisiIdle = new Vector2(
            (batasKiri + batasKanan) / 2f,
            (batasAtas + batasBawah) / 2f
        );
    }

    void Update()
    {
        if (ball == null || ballRb == null)
            return; // keluar dari Update dulu kalau bola hancur

        Vector2 target;

        // Cek apakah bola bergerak ke kiri (ke arah AI)
        if (ballRb.velocity.x < 0)
        {
            target = ball.position;
        }
        else
        {
            // Bola menjauh -> gerak pelan ke posisi tengah
            target = posisiIdle;
        }

        Vector2 arah = target - (Vector2)transform.position;

        float gerakHorizontal = Mathf.Clamp(arah.x, -1f, 1f) * kecepatan * Time.deltaTime;
        float gerakVertical = Mathf.Clamp(arah.y, -1f, 1f) * kecepatan * Time.deltaTime;

        float nextPosX = transform.position.x + gerakHorizontal;
        float nextPosY = transform.position.y + gerakVertical;

        if (nextPosX > batasKanan || nextPosX < batasKiri)
            gerakHorizontal = 0;
        if (nextPosY > batasAtas || nextPosY < batasBawah)
            gerakVertical = 0;

        transform.Translate(gerakHorizontal, gerakVertical, 0);
    }
}
