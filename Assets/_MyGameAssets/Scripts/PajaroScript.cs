using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {

    // Recogemos las pulsaciones
    Touch pulsacion;
    Touch[] pulsaciones;
    Vector2 posicionInicial;
    Vector2 posicionFinal;
    public int force = 500;

    private void Update() {
        pulsaciones = Input.touches;
        // Si no hay pulsaciones no seguimos
        if (pulsaciones.Length == 0) {
            return;
        }
        // Recogemos las pulsaciones
        pulsacion = pulsaciones[0];

        // Evaluamos las pulsaciones con un switch-case
        // Es valido para todos los proyectos moviles
        switch (pulsacion.phase) {
            case (TouchPhase.Began):
                ComenzarToque();
                break;
            case (TouchPhase.Moved):
                MoverToque();
                break;
            case (TouchPhase.Ended):
                FinalizarToque();
                break;
            case (TouchPhase.Canceled):
                // CancelarToque();
                break;
            case (TouchPhase.Stationary):
                // PausarToque();
                break;
            default:
                // EjecutarAccionPorDefectoToque();
                break;
        }
    }

    // Metodos
    void ComenzarToque() {
        // Obtenemos el vector de posicion en el mundo del juego
        Vector2 posicionConvertida = getWorldPostion(pulsacion);
        // Asignamos la misma posicion
        transform.position = posicionConvertida;
        posicionInicial = posicionConvertida;
    }

    void MoverToque() {
        // Obtenemos el vector de posicion en el mundo del juego
        Vector2 posicionMovida = getWorldPostion(pulsacion);
        // Asignamos la misma posicion
        transform.position = posicionMovida;
    }

    void FinalizarToque() {
        // Obtenemos el vector de posicion en el mundo del juego
        Vector2 posicionConvertida = getWorldPostion(pulsacion);
        // Asignamos la misma posicion
        transform.position = posicionConvertida;
        posicionFinal = posicionConvertida;
        // Calculamos la direccion
        Vector2 direccion = (posicionInicial - posicionFinal).normalized;
        // Ponemos el rigidbody2d en modo cinematico
        GetComponent<Rigidbody2D>().isKinematic = false;
        // Le damos el empujon
        GetComponent<Rigidbody2D>().AddRelativeForce(direccion * force);
    }

    private Vector2 getWorldPostion(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector2(_t.position.x, _t.position.y));
    }
}
