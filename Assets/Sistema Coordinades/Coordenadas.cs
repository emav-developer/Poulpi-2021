using UnityEngine;
using System.Collections;

public class Coordenadas : MonoBehaviour {

	public float moveSpeed = 5.0f;	// velocidad a la que se moverá el pulpo
	Vector2 movimiento = new Vector2();	// recoge la dirección de movimiento del joystick
	

	
	void Update () {
		movimiento.x = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		movimiento.y = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;	
		transform.Translate (movimiento.x, movimiento.y, 0);
		if (Input.GetKeyDown (KeyCode.Escape))
						Application.Quit ();
		if (Input.GetMouseButton(0)) 
		{
			Vector3 nuevaPosi = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
			                                transform.position.z-Camera.main.transform.position.z);
			// La formula puesta en la coordenada Z es para mantener la Z original del objeto
			transform.position=Camera.main.ScreenToWorldPoint(nuevaPosi); 
				
		}
	}

	void OnGUI()
	{
		Vector2 raton = Event.current.mousePosition;
		Vector3 screen = Camera.main.WorldToScreenPoint (transform.position);
		Vector2 viewport = Camera.main.WorldToViewportPoint(transform.position);
		GUI.Label (new Rect(10,10,400,30),"Punto de partida: X=100, Y=50  // Resolucion: " + Screen.width + " x " + Screen.height	);
		GUI.Label (new Rect(10,40,300,30),"Transform: X=" + transform.position.x.ToString("0.00") + " Y:" + 
		           transform.position.y.ToString("0.00"));
		GUI.Label (new Rect(10,70,300,30),"WorldToScreenPoint: X=" + screen.x.ToString("0") + " Y:" + 
		           screen.y.ToString("0"));
		GUI.Label (new Rect(10,100,300,30),"WorldToViewportPoint: X=" + viewport.x.ToString("0.00") + " Y:" + 
		           viewport.y.ToString("0.00"));
		GUI.Label (new Rect(10,130,300,30),"GUI: X=" + screen.x.ToString("0.00") + " Y:" + 
		           (Screen.height - screen.y).ToString("0.00"));
		GUI.Label (new Rect(10,170,300,30),"Event.current.mousePosition: X=" + raton.x.ToString("0.") + " Y:" + 
		           raton.y.ToString("0")); // Event.current.mousePosition solo puede ejecutarse en OnGUI

		GUI.Label (new Rect(10,200,300,30),"Input.mouseposition: X=" + Input.mousePosition.x.ToString("0.") + " Y:" + 
		           Input.mousePosition.y.ToString("0"));
		GUI.color = Color.yellow;

		GUI.Label (new Rect (10, 250, 300, 30), "Usa cursores o clicka con el raton. ESC para salir");
		GUI.color = Color.white;

	}
}
