using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canva : MonoBehaviour
{
    public TMP_Text tiempoTexto;
    public TMP_Text mensaje;
    public Transform g1;
    public Transform g2;
    public Transform g3;
    public Transform spawn;
    public Transform jugador;
    public Vector3 posicionJugador;
    float tiempo;
    bool ganaste = false;
    bool perdiste = false;
    string mensajeTexto = "";

    public void setGanaste(){
        ganaste = true;
    }

    public void setPerdiste(){
        perdiste = true;
    }

    public void reinicio(){
        g1.position = new Vector3(spawn.position.x,spawn.position.y,spawn.position.z);
        g1.rotation = spawn.rotation;
        g2.position = new Vector3(spawn.position.x,spawn.position.y,spawn.position.z+ 10.0f);
        g2.rotation = spawn.rotation;
        g3.position = new Vector3(spawn.position.x,spawn.position.y,spawn.position.z+ 5.0f);
        g3.rotation = spawn.rotation;
        jugador.position = posicionJugador;
        jugador.rotation = Quaternion.identity;
        tiempo = 0.0f;
        ganaste = false;
        perdiste = false;
        mensajeTexto = "";
    }

    public void salirApp(){
        Application.Quit();
    }

    void Update(){
        tiempo += Time.deltaTime;

        if(ganaste){
            mensajeTexto = "Ganaste";
        }

        if(perdiste){
            mensajeTexto = "Perdiste";
        }

        tiempoTexto.text = "Tiempo: " + tiempo.ToString() + " [s]";

        mensaje.text = mensajeTexto;
    }
}
