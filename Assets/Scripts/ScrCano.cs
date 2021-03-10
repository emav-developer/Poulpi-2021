using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCano : MonoBehaviour
{
    [SerializeField] GameObject apuntar; // objete al que apuntem
    void Update()
    {
        float velocitat = 10; // gira suaument (2 segons) A valors més grans, segueix més ràpid
        if (apuntar)
        {
            // Fuente: https://gamedev.stackexchange.com/questions/111718/make-one-object-rotate-to-face-another-object-in-2d/138819#138819

            Vector3 offset = apuntar.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, offset);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation * Quaternion.Euler(0, 0, 270), velocitat * Time.deltaTime); // (canviar 270 per 90 per disparar en l’altre direcció)
        }
    }

}
