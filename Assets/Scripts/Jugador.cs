using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Transform posArma;
    public GameObject bala;
    public float fuerza;

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.M)){
            var balas = Instantiate(bala, posArma.position, Quaternion.identity);
            var rb = balas.GetComponent<Rigidbody>();
            rb.AddForce(posArma.transform.forward * fuerza, ForceMode.Impulse);
        }
    }
}
