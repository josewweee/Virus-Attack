using UnityEngine;
using System.Collections;

public class FinDelJuego : MonoBehaviour {

	//VARIABLES DE REFERENCIA
	public GameObject Jugador;

	//VARIABLES NORMALES
	private int VidasRestantes;
	private float Puntaje;
	private float PuntajeMaximo;
	void Start () {
		PuntajeMaximo = PlayerPrefs.GetFloat ("Puntaje");
	}

	// Update is called once per frame
	void Update () {
		VidasRestantes = Jugador.GetComponent<VidaVirus> ().Vida;
		PerderJuego ();
	}

	void PerderJuego(){
		if (VidasRestantes <= 0) {
			//GUARDO EL PUNTAJE
			Puntaje = Jugador.GetComponent<Tiempo> ().puntaje;
			if (Puntaje > PuntajeMaximo) {
				PlayerPrefs.SetFloat ("Puntaje", Puntaje);
			}
			//VOY AL MENU
			Application.LoadLevel ("Menu");
		}
	}
}
