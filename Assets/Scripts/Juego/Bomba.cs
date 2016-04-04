using UnityEngine;
using System.Collections;

public class Bomba : MonoBehaviour {
	//objeto onda expansiva
	public GameObject OndaExpansiva;

	void Start () {
		
	}

	void Update () {
		
		//metodo para tomar el tacto de un objeto en android
		if(Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)){
				if(hit.collider.tag == "Bomba"){
					OnMouseDown ();
				}
			}
		}
	}

	void OnMouseDown(){
		GetComponent<AudioSource> ().Play();
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<MoverEnemigos> ().speed = 0f;
		Instantiate (OndaExpansiva, transform.position, transform.rotation);
		Invoke("destroy", GetComponent<AudioSource> ().clip.length);
	}

	void destroy(){
		Destroy (this.gameObject);
	}
}
