using UnityEngine;
using System.Collections;

public class CrearBombas : MonoBehaviour {

	//referencia de donde cojemos el numero aleatorio
	private GameObject referenciaNumAleatorio;

	//variable aleatoria
	private string aleatorio;

	//objeto a instanciar
	public GameObject Bomba;

	void Start () {
		referenciaNumAleatorio = GameObject.FindGameObjectWithTag ("Creadora");
	}

	void Update () {
		aleatorio = referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().DondeInstanciarB;
		IncubadoraDeBombas (aleatorio);
	}

	private void IncubadoraDeBombas(string valor){
		switch(valor){
		case "Izquierda":
			if (this.gameObject.tag == "CreadorIzq") {
				Instantiate (Bomba, new Vector3 (-9.6f, Random.Range (-4.92f, 4.68f), 0f), transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarB ("");
			}
			break;
		case "Derecha":
			if (this.gameObject.tag == "CreadorDer") {
				Instantiate (Bomba, new Vector3 (9.6f, Random.Range(-4.77f, 4.65f),0f) , transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarB ("");
			}
			break;
		case "Arriba":
			if (this.gameObject.tag == "CreadorArriba") {
				Instantiate (Bomba, new Vector3(Random.Range(-8.42f, 8.46f), 5.72f, 0f), transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarB ("");
			}
			break;
		case "Abajo":
			if (this.gameObject.tag == "CreadorAbajo") {
				Instantiate (Bomba, new Vector3(Random.Range(-8.31f, 8.53f), -5.77f, 0f), transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarB ("");
			}
			break;
		}
	}
}
