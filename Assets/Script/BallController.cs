using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject panelSelesai;
    Text txtPemenang;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall() {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
        force = 200;
    }

    void TampilkanScore() {
        Debug.Log("Score P1: " + scoreP1 + "Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.name == "goalKiri") {
            scoreP2 += 1;
            TampilkanScore();
            if(scoreP2 == 5) {
                panelSelesai.SetActive(true);
                txtPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txtPemenang.text = "Player Merah Menang!!!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if(coll.gameObject.name == "goalKanan") {
            scoreP1 += 1;
            TampilkanScore();
            if(scoreP1 == 5) {
                panelSelesai.SetActive(true);
                txtPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txtPemenang.text = "Player Biru Menang!!!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if(coll.gameObject.name == "paddle_biru" || coll.gameObject.name == "paddle_merah") {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;

            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = Vector2.zero;

            // Tambah kecepatan setiap kena paddle
            force += 20; // kamu bisa sesuaikan nilai percepatannya
            force = Mathf.Min(force, 700); // batasi maksimal force

            rigid.AddForce(arah * force * 2);
        }

    }
}
