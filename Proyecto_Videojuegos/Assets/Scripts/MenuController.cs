using UnityEngine;

public class MenuController : MonoBehaviour {
    public static string dificultad;

    public void DificultadFacil() {
        dificultad = "facil";
    }

    public void DificultadMedia() {
        dificultad = "media";
    }

    public void DificultadDificil() {
        dificultad = "dificil";
    }

    private bool comprobarDificultad() {
        return dificultad != null && (dificultad == "facil" || dificultad == "media" || dificultad == "dificil");
    }

    public void jugarForeverAlone() {
        if(comprobarDificultad())
            Debug.Log("Cambiar a Scene jugar contra la computadora");
    }

    public void modoCooperativo()
    {
        if(comprobarDificultad())
            Debug.Log("Cambiar a Scene dos jugadores");
    }
}
