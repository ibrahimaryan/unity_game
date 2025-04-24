using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [Header("Data Permainan")]
    public static GameSystem instance;
    public int Target;

    [Header("Komponen UI")]
    public Text teks_skor;
    public Text teks_waktu;
    public RectTransform Ui_darah;
    public bool SistemAcak;

    [System.Serializable]
    public class DataGame
    {
        public Sprite Gambar;
        public string Nama;
        public AudioClip Suara;
    }

    [Header("Settingan Standar")]
    public DataGame[] DataPermainan;
    public Obj_TempatDrop[] Drop_Tempat;
    public Obj_Drag[] Drag_Obj;

    [Header("Audio")]
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AcakSoal();
    }

    [HideInInspector] public List<int> _AcakSoal = new List<int>();
    [HideInInspector] public List<int> _AcakPos = new List<int>();

    public void AcakSoal()
    {
        _AcakSoal.Clear();
        _AcakPos.Clear();

        _AcakSoal = new List<int>(new int[Drag_Obj.Length]);
        for (int i = 0; i < _AcakSoal.Count; i++)
        {
            int rand = Random.Range(1, DataPermainan.Length);
            while (_AcakSoal.Contains(rand))
                rand = Random.Range(1, DataPermainan.Length);

            _AcakSoal[i] = rand;
            Drag_Obj[i].ID = rand - 1;
            Drag_Obj[i].Teks.text = DataPermainan[rand - 1].Nama;
        }

        _AcakPos = new List<int>(new int[Drop_Tempat.Length]);
        for (int i = 0; i < _AcakPos.Count; i++)
        {
            int rand2 = Random.Range(1, _AcakPos.Count + 1);
            while (_AcakPos.Contains(rand2))
                rand2 = Random.Range(1, _AcakPos.Count + 1);

            _AcakPos[i] = rand2;

            int dataIndex = _AcakSoal[rand2 - 1] - 1;

            Drop_Tempat[i].Drop.ID = dataIndex;
            Drop_Tempat[i].Gambar.sprite = DataPermainan[dataIndex].Gambar;
            Drop_Tempat[i].AudioClip = DataPermainan[dataIndex].Suara;
        }
    }

    void Update()
    {
        // Tes pemutaran audio angklung dengan tombol A
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     if (DataPermainan.Length > 0 && DataPermainan[0] != null)
        //     {
        //         if (DataPermainan[0].Suara != null)
        //         {
        //             Debug.Log("Mainkan audio: " + DataPermainan[0].Suara.name);
        //             PlayAudioOnce(DataPermainan[0].Suara);
        //         }
        //         else
        //         {
        //             Debug.LogWarning("Suara belum diisi untuk DataPermainan[0]!");
        //         }
        //     }
        //     else
        //     {
        //         Debug.LogWarning("DataPermainan[0] kosong atau array belum diisi.");
        //     }
        // }

        // // Acak soal dengan tombol Spasi
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     AcakSoal();
        // }
    }

    public AudioClip GetAudioFromSprite(Sprite gambar)
    {
        foreach (var item in DataPermainan)
        {
            if (item.Gambar == gambar)
                return item.Suara;
        }
        return null;
    }

    public void PlayAudioOnce(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public AudioClip GetAudioByID(int id)
    {
        if (id >= 0 && id < DataPermainan.Length)
        {
            return DataPermainan[id].Suara;
        }
        return null;
    }
}
