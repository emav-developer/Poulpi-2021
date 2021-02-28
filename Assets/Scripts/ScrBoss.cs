using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBoss : MonoBehaviour
{
    [SerializeField] GameObject explosio;
    void Destruccio() // indica com es destrueix l'objecte
    {
        // Comentem la següent línea fins que creem l’explosió
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
