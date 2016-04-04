using UnityEngine;
using System.Collections;

public class Congeladora : MonoBehaviour {
	//variable para guardar los globulos en el mapa
	public GameObject[] Enemigos;
	public GameObject[] Bombas;
	public GameObject[] Vidas;
	public GameObject[] Aceleradoras;

	//variable para saber cuando descongelar
	private bool descongelar = false;
	private float TiempoDescongelar = 0f;

	//variable de refencia a este objeto
	private GameObject esteObjeto;

	void Start () {
		esteObjeto = this.gameObject;
	}

	void Update () {
		//guardamos los enemigos en un arreglo
		Enemigos = GameObject.FindGameObjectsWithTag ("Enemigo");
		Bombas = GameObject.FindGameObjectsWithTag ("Bomba");
		Vidas = GameObject.FindGameObjectsWithTag ("Vida");
		Aceleradoras = GameObject.FindGameObjectsWithTag ("Aceleradora");
		// funcion de click
		if(Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)){
				if (hit.collider.gameObject.tag == "Congeladora") {
					OnMouseDown ();
				}
			}
		}
		if (descongelar == true) {
			if (TiempoDescongelar > 4f) {
				StartCoroutine ("Descongelar");
				descongelar = false;
			} else {
				TiempoDescongelar += Time.deltaTime;
			}
		}
	}
	void OnMouseDown(){
		StartCoroutine ("Congelar");
		descongelar = true;
		GetComponent<AudioSource> ().Play();
		esteObjeto.GetComponent<SpriteRenderer> ().enabled = false;
		esteObjeto.GetComponent<MoverEnemigos> ().speed = 0f;
	}
	//corrutina de congelar (es como otro update)
	IEnumerator Congelar(){
		for (int i = 0; i < Enemigos.Length; i++) {
			Enemigos [i].GetComponent<MoverEnemigos> ().Congelar (true);
		}
		for (int i = 0; i < Bombas.Length; i++) {
			Bombas [i].GetComponent<MoverEnemigos> ().Congelar (true);
		}
		for (int i = 0; i < Vidas.Length; i++) {
			Vidas [i].GetComponent<MoverEnemigos> ().Congelar (true);
		}
		for (int i = 0; i < Aceleradoras.Length; i++) {
			Aceleradoras [i].GetComponent<MoverEnemigos> ().Congelar (true);
		}


		yield return null;
	}

	IEnumerator Descongelar(){
		for (int i = 0; i < Enemigos.Length; i++) {
			Enemigos [i].GetComponent<MoverEnemigos> ().Congelar (false);
		}
		for (int i = 0; i < Bombas.Length; i++) {
			Bombas [i].GetComponent<MoverEnemigos> ().Congelar (false);
		}
		for (int i = 0; i < Vidas.Length; i++) {
			Vidas [i].GetComponent<MoverEnemigos> ().Congelar (false);
		}
		for (int i = 0; i < Aceleradoras.Length; i++) {
			Aceleradoras [i].GetComponent<MoverEnemigos> ().Congelar (false);
		}
		Destroy (this.gameObject);
		yield return null;
	}
}
