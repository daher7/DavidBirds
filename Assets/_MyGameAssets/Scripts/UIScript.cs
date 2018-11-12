using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text txtAceleracion;
    float maxX, maxY, maxZ;

    private void Update() {
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        float z = Input.acceleration.z;
        maxX = Mathf.Max(maxX, x);
        maxY = Mathf.Max(maxY, y);
        maxZ = Mathf.Max(maxZ, z);

        txtAceleracion.text = maxX + ":" + maxY + ":" + maxZ;
    }

    public void RecargarPantalla() {
        SceneManager.LoadScene(0);
    }
}
