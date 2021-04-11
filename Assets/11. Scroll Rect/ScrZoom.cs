using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrZoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image map;
    [SerializeField] Canvas canvas;
    bool visible = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) map.transform.localScale = new Vector3(2, 2, 2);
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) map.transform.localScale = new Vector3(1, 1, 1);
        if (Input.GetKeyDown(KeyCode.M))
        {
            visible = !visible;
            canvas.gameObject.SetActive(visible);
        }
    }
}
