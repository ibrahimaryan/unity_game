using UnityEngine;

public class DynamicTrailPosition : MonoBehaviour {
    private Rigidbody2D _meteorRigidbody; // Ganti tipe ke Rigidbody2D
    public float trailOffset = 0.5f;

    void Start() {
        // Akses Rigidbody2D dari parent
        _meteorRigidbody = GetComponentInParent<Rigidbody2D>();
        
        if (_meteorRigidbody == null) {
            Debug.LogError("Rigidbody2D tidak ditemukan di parent meteor!");
        }
    }

    void Update() {
        if (_meteorRigidbody != null && _meteorRigidbody.velocity != Vector2.zero) {
            // Posisikan partikel di belakang meteor (2D)
            transform.localPosition = -_meteorRigidbody.velocity.normalized * trailOffset;
            
            // Rotasi partikel menghadap belakang (opsional)
            transform.right = _meteorRigidbody.velocity.normalized;
        }
    }
}