using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayer : MonoBehaviour
{
    [SerializeField]
    float velocitat = 10f;   	       // velocitat de la nau
    Vector2 movi = new Vector2();   // per calcular moviment
    Rigidbody2D rb;                 // per accedir al component RigidBody
    [SerializeField] float cadencia = 0.5f; // dispararà cada 5 dècimes de segon
    float crono = 0f;	  // per comptar el temps de cadència

    [SerializeField]
    GameObject missil; // element a instanciar. Arrosseguem prefab!
    [SerializeField]
    Transform cano;    // d'on surt el tretSerializeField]


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Damos valor a rb
    }

    void Update()
    {
        movi.x = ETCInput.GetAxis("Horizontal") * velocitat;
        movi.y = ETCInput.GetAxis("Vertical") * velocitat;

        if (ETCInput.GetButton("Shoot") && crono > cadencia) // Shoot: nom del control
            Dispara();
        crono += Time.deltaTime;
        // la següent línea permet disparar ràpid amb múltiples clicks
        if (ETCInput.GetButtonUp("Shoot")) crono = cadencia;

    }

    void FixedUpdate()
    {
        rb.velocity = movi;    // Apliquem velocitat. No utilitzar Translate (fisiques!)
    }
    void Dispara()
    {
        crono = 0;
        Instantiate(missil, cano.position, cano.rotation);
    }

}
