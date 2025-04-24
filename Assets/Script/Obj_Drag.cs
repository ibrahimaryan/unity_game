using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Obj_Drag : MonoBehaviour
{
    [Header("Data Drag")]
    public int ID;
    public Text Teks;
    public UnityEvent OnDragBenar;

    private Vector2 posisiAwal;
    private Vector3 skalaAwal;
    private bool terkunci = false;
    private bool beradaDiDrop = false;
    private Tempat_Drop tempatSaatIni;

    void Start()
    {
        posisiAwal = transform.position;
        skalaAwal = transform.localScale;
    }

    private void OnMouseDown()
    {
        if (terkunci) return;
        beradaDiDrop = false;
    }

    private void OnMouseDrag()
    {
        if (terkunci) return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }

    private void OnMouseUp()
    {
        if (terkunci) return;

        if (beradaDiDrop && tempatSaatIni != null && !tempatSaatIni.isTerisi)
        {
            if (ID == tempatSaatIni.ID)
            {
                // Benar
                transform.position = tempatSaatIni.transform.position;
                transform.localScale = skalaAwal;
                tempatSaatIni.GetComponent<SpriteRenderer>().enabled = false;
                tempatSaatIni.isTerisi = true;
                terkunci = true;
                OnDragBenar.Invoke();

                // Mainkan audio
                AudioClip suara = GameSystem.instance.GetAudioByID(ID);
                if (suara != null)
                {
                    GameSystem.instance.PlayAudioOnce(suara);
                }
            }
            else
            {
                // Salah
                KembaliKePosisiAwal();
            }
        }
        else
        {
            KembaliKePosisiAwal();
        }
    }

    private void KembaliKePosisiAwal()
    {
        transform.position = posisiAwal;
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.CompareTag("Drop"))
        {
            Tempat_Drop tempat = trig.GetComponent<Tempat_Drop>();
            if (!tempat.isTerisi)
            {
                beradaDiDrop = true;
                tempatSaatIni = tempat;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.CompareTag("Drop"))
        {
            beradaDiDrop = false;
            tempatSaatIni = null;
        }
    }
}
