using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrCorazones : MonoBehaviour {

const int VIDES_INICIALS = 5;
[SerializeField] int numVides = VIDES_INICIALS;
Image[] cors;   // array amb els cors que crearem
[SerializeField] Image prefabCor;     // apunta al prefab del cor

void Start()
    {
        cors = new Image[numVides];  // inicialitzem array
        DibuixaCors(VIDES_INICIALS);        // Dibuixem els 5 cors
    }
void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))  // Amb tecla - disminuim vides
        {
            if (numVides > 0) numVides--;
            EstableixCor(numVides, false);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))   // Amb tecla + augmentem vides
        {
            if (numVides < VIDES_INICIALS) numVides++;
            EstableixCor(numVides-1, true);
        }
    }

    // Funció que pinta els nombre de cors inicials
    void DibuixaCors(int num)
    {
        // Per saber l'amplada de cada prefab, i calcular el desplaçament
        float ample = prefabCor.rectTransform.sizeDelta.x;

        for (int i = 0; i < num; i++)
        {
        cors[i] = Instantiate(prefabCor);                   // instanciem
        cors[i].transform.SetParent(this.transform, false); // fem fill del canvas mantenin posició
        cors[i].transform.Translate(ample * i, 0, 0);       // desplacem a la dreta
        }
    }

    //Funció que encén/apaga un cor
    void EstableixCor(int num, bool estat)
    {
        cors[num].gameObject.SetActive(estat);
    }
}
