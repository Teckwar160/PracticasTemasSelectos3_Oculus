using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform jugador;
    public Animator controlEnemigo;
    public Transform spawn;
    public canva control;
    bool flagPerseguir = false;
    bool flagGolpear = false;
    bool flagMorir = false;
    UnityEngine.AI.NavMeshAgent enemigo;
    float radio = 1.0f;
    float positionZ = 0.0f;
    float timer = 0f;
    float tiempoSpawn = 10f;
    bool cuenta = true;
    
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
            if (collider.CompareTag("Bala")){
                enemigo.isStopped = true;
                flagGolpear = false;
                flagPerseguir = false;
                flagMorir = true;
                cuenta = true;

            } else if (collider.gameObject.name == "Jugador"){
                enemigo.isStopped = true;
                flagGolpear = true;
                flagPerseguir = false;
                control.setPerdiste();
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

        if (cuenta)
        {
            timer += Time.deltaTime;

            if (timer >= tiempoSpawn)
            {
                cuenta = false;
                flagMorir = false;
                switch(gameObject.name){
                    case "Guerrero":
                        positionZ = 0.0f;
                        break;
                    case "Guerrero (1)":
                        positionZ = 10.0f;
                        break;
                    case "Guerrero (2)":
                        positionZ = 5.0f;
                        break;

                }
                gameObject.transform.position = new Vector3(spawn.position.x,spawn.position.y,spawn.position.z+positionZ);
                gameObject.transform.rotation = spawn.rotation;
            }
        }     
    }
}