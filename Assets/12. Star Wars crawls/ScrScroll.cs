using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrScroll : MonoBehaviour {


	public ScrollRect scroll;
	public float scrollSpeed=0.025f;

	void Update () {
		scroll.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;
	}
}
