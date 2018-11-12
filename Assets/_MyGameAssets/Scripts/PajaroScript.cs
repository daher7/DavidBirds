using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {

    // Recogemos las pulsaciones
    Touch pulsacion;
    Touch[] pulsaciones;
    Vector2 posicionInicial;
    Vector2 posicionFinal;
    public int maxForce = 1000;
    bool pajaroPulsado = false;

    private void Update() {
        pulsaciones = Input.touches;
        // Si no hay pulsaciones no seguimos
        if (pulsaciones.Length != 1) {
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
        if (!ComprobarPulsacionObjetoByName(pulsacion, "Pajarraco")) {
            return;
        }
        pajaroPulsado = true;
        // Obtenemos el vector de posicion en el mundo del juego
        Vector2 posicionConvertida = getWorldPosition(pulsacion);
        // Asignamos la misma posicion
        transform.position = posicionConvertida;
        posicionInicial = posicionConvertida;
    }

    void MoverToque() {
        if (pajaroPulsado) {
            // Obtenemos el vector de posicion en el mundo del juego
            Vector2 posicionMovida = getWorldPosition(pulsacion);
            // Asignamos la misma posicion
            transform.position = posicionMovida;
        }
    }

    void FinalizarToque() {
       
        if (pajaroPulsado) {
            pajaroPulsado = false;
            // Obtenemos el vector de posicion en el mundo del juego
            Vector2 posicionConvertida = getWorldPosition(pulsacion);
            // Asignamos la misma posicion
            transform.position = posicionConvertida;
            posicionFinal = posicionConvertida;
            // Calculamos la direccion
            Vector2 vectorDistancia = (posicionInicial - posicionFinal);
            Vector2 vectorDireccion = vectorDistancia.normalized;
            float distanca = vectorDistancia.magnitude;
            
            // Ponemos el rigidbody2d en modo cinematico
            GetComponent<Rigidbody2D>().isKinematic = false;
            // Le damos el empujon
            GetComponent<Rigidbody2D>().AddRelativeForce(vectorDireccion * distanca * maxForce);
        }
    }

    private Vector2 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector2(_t.position.x, _t.position.y));
    }

    private bool ComprobarPulsacionObjetoByName(Touch _t, string _name) {
        bool estaPulsado = false;
        //Posición del touch en función de la del mundo
        Vector3 touchWorldPosition = getWorldPosition(_t);
        //Obtención del objeto pulsado
        RaycastHit2D rch2d = Physics2D.Raycast(Camera.main.transform.position, touchWorldPosition);
        //Comprobación
        if (rch2d.transform != null && rch2d.transform.gameObject.name == _name) {
            estaPulsado = true;
        }
        return estaPulsado;
    }
}
