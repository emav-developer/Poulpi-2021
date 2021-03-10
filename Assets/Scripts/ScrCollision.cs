using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCollision : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script associat a Player i NPCs. Detecta col·lisions amb objectes 
    ///         enemics, mira el mal que fan, disminueixen la vida restant, i si 
    ///         arriba a 0, es destrueixen. També s'encarrega d'eliminar els trets
    /// AUTOR:  Jordi Aguilera
    /// DATA:   19/01/2020
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: primera versió
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField]
    float vitality = 2f;

    [SerializeField] AudioClip tocat, enfonsat; // Inicialitzem en cada prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool impacte = false;
  
        // print(transform.name + " vs " + collision.name); // per testejar col·lisions detectades
        ScrDamage scrD = collision.GetComponent<ScrDamage>(); // intentem llegir script ScrDamage    

        if (scrD)   // si en té, és un objecte que treu vida. Calculem
        {

            //NOTA: NO INTENTAR SIMPLIFICAR LA SEGÜENT CONDICIÓ, PERQUÈ MÉS ENDAVANT ENS FARÀ FALTA AIXÍ

            if (tag == "Player" && scrD.damagePlayer > 0)   // soc el player i l'objecte em treu vida
            {
                vitality -= scrD.damagePlayer;
                impacte = true;
            }
            else if (tag != "Player" && scrD.damageNPC > 0)
            {
                vitality -= scrD.damageNPC; // soc un NPC i l'objecte em treu vida
                impacte = true;

            }


            // si la col·lisió és amb una projectil, el destruim (busca funció Destruccio en els script associats)
            if (collision.tag == "shot" && impacte) collision.SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);

            // si no em queda vida, m'autodestrueixo 
            if (vitality <= 0) SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);
            if (impacte)
            {
                if (vitality <= 0 && enfonsat) AudioSource.PlayClipAtPoint(enfonsat, Camera.main.transform.position);
                if (vitality >0 && tocat) AudioSource.PlayClipAtPoint(tocat, Camera.main.transform.position);
            }
            
        }
    }
}

