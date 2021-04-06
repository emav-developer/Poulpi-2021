using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrToggleGroup : MonoBehaviour {

[SerializeField] Sprite[] imagenes; // Les diferents imatges dels personatges
[SerializeField] Image personaje;   // La imatge del Canvas
	public void SetOrcBoss(bool estat)
{
	if (estat) personaje.sprite = imagenes [0];
}
public void SetOrc(bool estat)
{
	if (estat) personaje.sprite = imagenes [1];
}
public void SetWolf(bool estat)
{
	if (estat) personaje.sprite = imagenes [2];
}
public void SetZombie(bool estat)
{
	if (estat) personaje.sprite = imagenes [3];
}
}
