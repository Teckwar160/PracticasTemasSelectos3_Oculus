using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform jugador;
    public bool perseguir = false;
    UnityEngine.AI.NavMeshAgent enemigo;
    public Animator controlEnemigo;
    
    void Start() {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    
    void Update(){
        if(perseguir){
            enemigo.destination = jugador.position;
            controlEnemigo.SetBool("Perseguir",perseguir);
        }
        controlEnemigo.SetBool("Perseguir",perseguir);
            
    }
}