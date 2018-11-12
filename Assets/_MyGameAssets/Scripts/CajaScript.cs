using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaScript : MonoBehaviour {

    [SerializeField] GameObject pfPuntuacion;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            MostrarPuntuacion();
            //Destroy(this.gameObject);
        }
    }

    private void MostrarPuntuacion() {

        GameObject puntuacion = Instantiate(pfPuntuacion, transform.position, transform.rotation);
    }
}
