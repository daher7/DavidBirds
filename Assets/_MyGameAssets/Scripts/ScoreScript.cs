using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    public float timeDestruction = 1.5f;

    private void Start() {
        Destroy(gameObject, timeDestruction);
    }

    void Update() {
        transform.Translate(Vector2.up * Time.deltaTime);
    }
}
