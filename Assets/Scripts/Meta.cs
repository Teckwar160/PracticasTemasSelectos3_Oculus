using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public canva control;

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.name == "Jugador"){
            control.setGanaste();
        }
    }
}
