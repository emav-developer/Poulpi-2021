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
    Transform [] canons;    // d'on surt el tretSerializeField]

    float cronoPowerUp = 0;

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

        // ************************************** Gestió powerup tripleshot **************************************************
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetTripleShot(true);
            cronoPowerUp = 5;
        }
        if (cronoPowerUp > 0) cronoPowerUp -= Time.deltaTime; else SetTripleShot(false);


    }

    void FixedUpdate()
    {
        rb.velocity = movi;    // Apliquem velocitat. No utilitzar Translate (fisiques!)
    }
    void Dispara()
    {
        crono = 0;
        foreach (Transform c in canons)
            if (c.gameObject.activeSelf) Instantiate(missil, c.position, c.rotation);

    }

    void SetTripleShot(bool estat)
    {
        canons[0].gameObject.SetActive(estat);
        canons[2].gameObject.SetActive(estat);
    }

    void Destruccio() // indica com es destrueix l'objecte
    {
        Destroy(gameObject);
    }


}
