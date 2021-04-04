using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrBarraVida : MonoBehaviour
{
    [SerializeField] Image blanka, sakura;
    enum Personatges { Blanka, Sakura };
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) CanviaVida(Personatges.Blanka, 0.1f);
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) CanviaVida(Personatges.Blanka, -0.1f);
        if (Input.GetKeyDown(KeyCode.Alpha1)) CanviaVida(Personatges.Sakura, -0.1f);
        if (Input.GetKeyDown(KeyCode.Alpha2)) CanviaVida(Personatges.Sakura, 0.1f);
    }

    void CanviaVida(Personatges qui, float quant)
    {
        // No s'han de verificar que els valors estiguin entre 0 i 1, se n'encarrega Unity
        if (qui == Personatges.Blanka) blanka.fillAmount += quant;
        else sakura.fillAmount += quant;
    }

}
