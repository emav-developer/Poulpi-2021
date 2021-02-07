using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPoulpi : MonoBehaviour
{
    [SerializeField] float velX = -5f;
    Vector2 moviment = new Vector2();
    Rigidbody2D rb;
    [SerializeField]
    int tipusMoviment = 1;
    float desfase;
    GameObject player;
    const int QUANTS_MOVIMENTS = 5;

    [SerializeField] float elast = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        desfase = Random.Range(0, 360);
        player = GameObject.FindGameObjectWithTag("Player");
        if (tipusMoviment == 0) tipusMoviment = Random.Range(1, QUANTS_MOVIMENTS + 1);
    }

    void FixedUpdate()
    {
        CalculaMoviment(tipusMoviment);
        rb.velocity = moviment;
    }

    void CalculaMoviment(int tipus)
    {
        switch (tipus)
        {
            case 1:  // moviment a velocitat X
                moviment.x = velX;
                moviment.y = 0f;
                break;
            case 2:   // la mitad de velocidad que el anterior
                moviment.x = velX / 2;
                moviment.y = 0;
                break;
            case 3:
                moviment.x = velX;
                moviment.y = Random.Range(-2f, 2f);
                break;
            case 4:  // moviment sinusoidal
                float amplitud = 4;
                float freq = 4;
                moviment.x = velX;
                moviment.y = Mathf.Sin(Time.time * freq+desfase) * amplitud;
                break;
            case 5:  // perseguint al player
                if (player) moviment.y = (player.transform.position.y - transform.position.y) / elast;
          
                moviment.x = 0;
                break;


        }
    }
    void Destruccio() // indica com es destrueix l'objecte
    {
        Destroy(gameObject);
    }


}
