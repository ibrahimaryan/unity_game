using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTrail : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Vector3 _lastPosition;
    void Start() {
    _particleSystem = GetComponentInChildren<ParticleSystem>();
    _lastPosition = transform.position;
}

void Update() {
    Vector3 direction = (transform.position - _lastPosition).normalized;
    if (direction != Vector3.zero) {
        _particleSystem.transform.rotation = Quaternion.LookRotation(-direction);
    }
    _lastPosition = transform.position;
}
}
