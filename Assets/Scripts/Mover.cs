using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform jugador;
    public Animator controlEnemigo;
    bool flagPerseguir = false;
    bool flagGolpear = false;
    bool flagMorir = false;
    UnityEngine.AI.NavMeshAgent enemigo;
    float radio = 1.0f;
    
    void Start() {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.name == "Jugador"){
            enemigo.isStopped = false;
            flagPerseguir = true;
            flagGolpear = false;

        }
    }

    void OnTriggerExit(Collider collider){
        if (collider.gameObject.name == "Jugador"){
            enemigo.isStopped = true;
            flagPerseguir = false;
            flagGolpear = false;

        }
    }
    

    void golpear(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);
        foreach (Collider collider in colliders){
            if (collider.gameObject.name == "Jugador"){
                enemigo.isStopped = true;
                flagGolpear = true;
                flagPerseguir = false;

            } else if (collider.CompareTag("Bala")){
                enemigo.isStopped = true;
                flagGolpear = false;
                flagPerseguir = false;
                flagMorir = true;
            }
        }
    }

    void Update(){
        golpear();

        if(flagPerseguir){
            enemigo.destination = jugador.position;
        }
        controlEnemigo.SetBool("Perseguir",flagPerseguir);
        controlEnemigo.SetBool("Golpear",flagGolpear);
        controlEnemigo.SetBool("Morir",flagMorir);
            
    }
}