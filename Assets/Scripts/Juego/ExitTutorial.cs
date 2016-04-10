using UnityEngine;
using System.Collections;

public class ExitTutorial : MonoBehaviour {
	//variable para comenzar el juego cuando se cierren las instrucciones
	private GameObject Creadora;
	void Start () {
		Creadora = GameObject.FindGameObjectWithTag ("Creadora");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
					Creadora.GetComponent<NumeroAleatorio> ().SetComenzarJuego ();
					Destroy (this.gameObject);
			}
		}
	}
		
}
