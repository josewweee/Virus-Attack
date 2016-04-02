using UnityEngine;
using System.Collections;

public class MoverFondoJuego : MonoBehaviour {

    private float velocidad = 0.8f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * velocidad) % 1, 0);
    }
}
