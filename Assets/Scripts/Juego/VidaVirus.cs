using UnityEngine;
using System.Collections;

public class VidaVirus : MonoBehaviour {
	
	//vidas
    public int Vida = 3;

	//interfaz, texto de vidas
	public TextMesh VidasText;

	//referencia a todos los glubulos enemigos
	private GameObject[] Enemigos;

	//variable del efecto de la aleatoria
	private int random;

	void Start () {

	}

	void Update () {
		VidasText.text = Vida.ToString("f0");
		Enemigos = GameObject.FindGameObjectsWithTag ("Enemigo");
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Enemigo") {
			Vida--;
		}

		if(coll.gameObject.tag == "Onda"){
			Vida--;
		}

		if (coll.gameObject.tag == "Vida") {
			Destroy (coll.gameObject);
			Vida++;
		}

		if (coll.gameObject.tag == "Bomba") {
			Destroy (coll.gameObject);
		}

		if (coll.gameObject.tag == "Aceleradora") {
			Destroy (coll.gameObject);
			StartCoroutine("Aceleradora");
		}

		if (coll.gameObject.tag == "Congeladora") {
			Destroy (coll.gameObject);
		}

		if (coll.gameObject.tag == "Aleatoria") {
			Destroy (coll.gameObject);
			random = Random.Range (0, 100);
			if (random > 50) {
				Vida++;
			} else {
				Vida--;
			}

		}
	}

	 int getVida(){
		return Vida;
	}

	IEnumerator Aceleradora(){
		for (int i = 0; i < Enemigos.Length; i++) {
			Enemigos [i].GetComponent<MoverEnemigos> ().AcelerarVelocidad(true);
		}
		yield return null;
	}
}
