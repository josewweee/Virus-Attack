using UnityEngine;
using System.Collections;

public class OndaExpansiva : MonoBehaviour {

	//variable de tiempo de vida de la onda
	private float TiempoDeExplocion;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TiempoDeExplocion += Time.deltaTime;
		if (TiempoDeExplocion > 1f) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Vida" || coll.gameObject.tag == "Enemigo" || coll.gameObject.tag == "Aceleradora" || coll.gameObject.tag == "Congeladora" || coll.gameObject.tag == "Aleatoria") {
			Destroy (coll.gameObject);
		}
	}
}
