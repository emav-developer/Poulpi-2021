using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrRespawn : MonoBehaviour
{
    [SerializeField] float minX = 33, maxX = 83, minY = -7.8f, maxY = 7.8f;

    bool visible;
    Renderer render;
    void Start()
    {
        render = GetComponent<Renderer>();
        if (ScrControlGame.EsVisibleDesde(render, Camera.main)) visible = true;
        else visible = false;  // inicialmente es visible?
    }
    void Update()
    {
        // desapareix per l'esquerra
        if (visible && !ScrControlGame.EsVisibleDesde(render, Camera.main))
        {
            visible = false;  // el marquem com invisible
            MeuOnBecameInvisible();
        }
        // apareix per la dreta
        if (!visible && ScrControlGame.EsVisibleDesde(render, Camera.main))
            visible = true;     // el marquem com a visible
    }
    void MeuOnBecameInvisible()
    {
        float x = Random.Range(minX, maxX); // Quant tirem enrera
        float y = Random.Range(minY, maxY); // A quina alçada el posem
        transform.position = new Vector3(transform.position.x + x, y, transform.position.z);
    }


}
