using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBoss : MonoBehaviour
{
    [SerializeField] GameObject explosio;
    [SerializeField] Renderer r; // associar render del cos
    [SerializeField] float velocitat;
    bool moviment = true;
    Collider2D col;

    bool detectaPlayer = false;
    [SerializeField] LayerMask filtreCapes;

    void FixedUpdate()
    {
        float radiDeteccio = 20;
        detectaPlayer = Physics2D.OverlapCircle(transform.position, radiDeteccio, filtreCapes);
        if (detectaPlayer) moviment = false;
    }
    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    private void Update()
    {
        if (ScrControlGame.EsVisibleDesde(r, Camera.main)) col.enabled = true;
        if (moviment) transform.Translate(velocitat * Time.deltaTime, 0, 0);
    }

    void Destruccio() // indica com es destrueix l'objecte
    {
        // Comentem la següent línea fins que cree;m l’explosió
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
        
    }

}
