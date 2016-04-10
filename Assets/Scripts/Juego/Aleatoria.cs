using UnityEngine;
using System.Collections;

public class Aleatoria : MonoBehaviour {

	//variable que nos inica que puede sacar la aleatoria
	private int OcurrenciaAleatoria;

	//variables en caso de congeladora
	private bool descongelar = false;
	private float TiempoDescongelar = 0f;
	private GameObject[] Enemigos;
	private GameObject[] Bombas;
	private GameObject[] Vidas;
	private GameObject[] Aceleradoras;
	private GameObject[] Congeladoras;

	//variables en caso de bomba
	public GameObject OndaExpansiva;

	void Start () {
	
	}

	void Update () {
		//guardamos los enemigos en un arreglo
		Enemigos = GameObject.FindGameObjectsWithTag ("Enemigo");
		Bombas = GameObject.FindGameObjectsWithTag ("Bomba");
		Vidas = GameObject.FindGameObjectsWithTag ("Vida");
		Aceleradoras = GameObject.FindGameObjectsWithTag ("Aceleradora");
		Congeladoras = GameObject.FindGameObjectsWithTag ("Congeladora");

		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.collider.tag == "Aleatoria") {
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
		OcurrenciaAleatoria = Random.RandomRange (0, 3);
		switch (OcurrenciaAleatoria) {
		case 0:
			StartCoroutine ("Congelar");
			descongelar = true;
			GetComponent<AudioSource> ().Play();
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			this.gameObject.GetComponent<MoverEnemigos> ().speed = 0f;
			break;
		case 1:
			GetComponent<AudioSource> ().Play();
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<MoverEnemigos> ().speed = 0f;
			Instantiate (OndaExpansiva, transform.position, transform.rotation);
			Invoke("destroy", GetComponent<AudioSource> ().clip.length);
			break;
		case 2:
			StartCoroutine ("Aceleradora");
			GetComponent<AudioSource> ().Play ();
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<MoverEnemigos> ().speed = 0f;
			Invoke ("destroy", GetComponent<AudioSource> ().clip.length);
			break;
		default:
			break;
		}
	}


	//corrutinas de congelamiento
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


	//metodos en caso de bomba
	void destroy(){
		Destroy (this.gameObject);
	}

	//corrutina en caso de aceleradora
	IEnumerator Aceleradora(){
		for (int i = 0; i < Enemigos.Length; i++) {
			Enemigos [i].GetComponent<MoverEnemigos> ().AcelerarVelocidad(true);
		}
		yield return null;
	}
}
