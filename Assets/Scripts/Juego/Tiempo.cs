using UnityEngine;
using System.Collections;

public class Tiempo : MonoBehaviour {
    //objetos del juego
    public TextMesh Marcador;
	public TextMesh PuntajeMax;

    //variable del puntaje
    public float puntaje = 0f;
	private float puntajeMasAlto;

	//tiempo y referencia para saber cuando comenzar el juego
	private GameObject Creadora;
	private float TiempoComenzar;
	void Start () {
		puntajeMasAlto = PlayerPrefs.GetFloat ("Puntaje");
		Creadora = GameObject.FindGameObjectWithTag ("Creadora");
	}
	
	
	void Update () {
		//if para saber cuando cerraron el menu de instrucciones o pasaron 5 segundos para comenzar el juego
		if (TiempoComenzar > 5f || Creadora.GetComponent<NumeroAleatorio> ().ComenzarJuego == true) {
			puntaje += Time.deltaTime;
			Marcador.text = puntaje.ToString ("f0");  // ASI EL PUNTAJE ESTARA EN ENTEROS
			PuntajeMax.text = puntajeMasAlto.ToString ("f0");
		} else {
			TiempoComenzar += Time.deltaTime;
		}
	}
}
