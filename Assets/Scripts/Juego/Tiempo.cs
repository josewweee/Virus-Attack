using UnityEngine;
using System.Collections;

public class Tiempo : MonoBehaviour {
    //objetos del juego
    public TextMesh Marcador;
	public TextMesh PuntajeMax;

    //variable del puntaje
    public float puntaje = 0f;
	private float puntajeMasAlto;

	void Start () {
		puntajeMasAlto = PlayerPrefs.GetFloat ("Puntaje");
	}
	
	
	void Update () {
        puntaje += Time.deltaTime;
        Marcador.text = puntaje.ToString("f0");  // ASI EL PUNTAJE ESTARA EN ENTEROS
		PuntajeMax.text = puntajeMasAlto.ToString("f0");
        //Marcador.text = puntaje.ToString();	// ASI ES EL PUNTAJE EN FLOTANTE

	}
}
