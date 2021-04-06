using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrCorazones : MonoBehaviour {

public int numVidas = 5;
public Image[] corazones;   // array con los corazones que crearemos
public Image prCorazon;

void Start()
    {
        corazones = new Image[numVidas];
        DibujaCorazones(numVidas);
        // CambiaCorazon(1, false);
    }
void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (numVidas > 0) numVidas--;
            CambiaCorazon(numVidas, false);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (numVidas < 5) numVidas++;
            CambiaCorazon(numVidas-1, true);
        }
    }


    void DibujaCorazones(int num)
    {
        // Para averiguar el ancho accedemos a sizeDelta.x
        float ancho = prCorazon.rectTransform.sizeDelta.x;

        for (int i = 0; i < num; i++)
        {
        corazones[i] = Instantiate(prCorazon);
        corazones[i].transform.SetParent(this.transform, false); // this hace referencia al Canvas
        corazones[i].transform.Translate(ancho * i, 0, 0);
        }
    }

void CambiaCorazon(int num, bool estat)
    {
        corazones[num].gameObject.SetActive(estat);
    }
}
