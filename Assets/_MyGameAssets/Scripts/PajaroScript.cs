using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {

	

	void Update () {
        // Recogemos la pulsacion del dedo
        Touch t = Input.GetTouch(0);
        // Identificador del puntero
        int id = t.fingerId;
        // Posicion del puntero en la pantalla
        Vector2 position = t.position;
	}
}
