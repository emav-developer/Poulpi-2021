using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrSlider : MonoBehaviour {
	[SerializeField] AudioSource sonido;  // sonido al que queremos controlar volumen
	[SerializeField] Image vumeter;  // imagen que queremos clipear

	void Start ()
	{
		sonido.volume = 0.6f; // inicialmente ponemos potencia al 50%. Recordar hacer lo mismo con slider e imagen en inspector
	}

	// vol toma valores float entre 0 y 20, que es son los límites que hemos dado al slider (porque tiene 20 leds)
	public void PonVolumen(float vol) 
	{
		sonido.volume = vol / 20f;	// Como "volume" toma valores entre 0 y 1, tenemos que dividir entre 20
		vumeter.fillAmount = (int)vol/20f; // convertimos a entero para no iluminar leds parcialmente
	}
}
