using UnityEngine;
using System.Collections;

public class CrearCongeladoras : MonoBehaviour {

	//referencia de donde cojemos el numero aleatorio
	private GameObject referenciaNumAleatorio;

	//variable aleatoria
	private string aleatorio;

	//objeto a instanciar
	public GameObject Congeladora;

	void Start () {
		referenciaNumAleatorio = GameObject.FindGameObjectWithTag ("Creadora");
	}

	void Update () {
		aleatorio = referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().DondeInstanciarC;
		IncubadoraDeCongeladoras(aleatorio);
	}

	private void IncubadoraDeCongeladoras(string valor){
		switch(valor){
		case "Izquierda":
			if (this.gameObject.tag == "CreadorIzq") {
				Instantiate (Congeladora, new Vector3 (-9.6f, Random.Range (-4.92f, 4.68f), 0f), transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarC ("");
			}
			break;
		case "Derecha":
			if (this.gameObject.tag == "CreadorDer") {
				Instantiate (Congeladora, new Vector3 (9.6f, Random.Range(-4.77f, 4.65f),0f) , transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarC ("");
			}
			break;
		case "Arriba":
			if (this.gameObject.tag == "CreadorArriba") {
				Instantiate (Congeladora, new Vector3(Random.Range(-8.42f, 8.46f), 5.72f, 0f), transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarC ("");
			}
			break;
		case "Abajo":
			if (this.gameObject.tag == "CreadorAbajo") {
				Instantiate (Congeladora, new Vector3(Random.Range(-8.31f, 8.53f), -5.77f, 0f), transform.rotation);
				referenciaNumAleatorio.GetComponent<NumeroAleatorio> ().SetDondeInstanciarC ("");
			}
			break;
		}
	}
}
