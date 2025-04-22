using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUkuran : MonoBehaviour
{
     public Transform elemenUI; // Drag elemen UI di sini di Inspector
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (elemenUI != null) {
            RectTransform rectTransform = elemenUI.GetComponent<RectTransform>();

            if (rectTransform != null) {
                Debug.Log("Lebar: " + rectTransform.rect.width);
                Debug.Log("Tinggi: " + rectTransform.rect.height);
                Debug.Log("Size Delta: " + rectTransform.sizeDelta);
            } else {
                Debug.LogError("RectTransform tidak ditemukan pada elemen UI.");
            }
        } else {
            Debug.Log("Elemen UI belum diatur.");
        }
    }
}
