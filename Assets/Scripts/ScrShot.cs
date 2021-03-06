﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrShot : MonoBehaviour
{
    [SerializeField]
    float vel = 20f;

    void Start()
    {
        Destroy(gameObject, 5); // per si no col·lisiona amb res
    }
    void Update()
    {
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }
    void Destruccio() // indica com es destrueix l'objecte
    {
        Destroy(gameObject);
    }

}
