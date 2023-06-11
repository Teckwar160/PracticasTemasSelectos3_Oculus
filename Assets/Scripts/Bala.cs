using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    float timer = 0f;
    float tiempoVida = 5f;
    bool cuenta = true;

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name != "Jugador"){
            Destroy(this.gameObject);
        }
        
    }

    void Update(){
        if (cuenta)
        {
            timer += Time.deltaTime;

            if (timer >= tiempoVida)
            {
                cuenta = false;
                Destroy(this.gameObject);
            }
        }    
    }
}
