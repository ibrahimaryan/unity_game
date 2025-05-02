using UnityEngine;

public class BatasAkhir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek jika yang masuk adalah sampah (bisa pakai tag atau komponen tertentu)
        if (other.gameObject.CompareTag("Organik") || other.gameObject.CompareTag("NonOrganik"))
        {
            Destroy(other.gameObject);
        }
    }
}