using UnityEngine;
using System.Collections;

public class NumeroAleatorio : MonoBehaviour {
	//referencia donde tomaremos el tiempo
	private GameObject jugador;

	// variable para saber si se cerro el tutorial para poder comenzar el juego
	public bool ComenzarJuego = false;
	public float TiempoComenzar = 0;

	//variable para la dificultad del juego
	public float frecuencia = 0.8f;

	//variables de tiempo para saber cuando crear objetos
	private float TiempoParaCrearVidas = 23f;
	private float TiempoParaCrearBombas = 4f;
	private float TiempoParaCrearAceleradoras = 3f;
	private float TiempoParaCrearCongeladoras = 11f;
	private float TiempoParaCrearAleatorias = 5f;
	private float TiempoParaCrearEnemigos;
	private float TiempoTranscurrido;

	//variable aleatoria
	private int aleatorio;

	//variables de la dificultad de los globulos blancos
	private float TiempoSubirDificultad = 20f;

	//variable que tomaran de refencia las demas clases de en que lado instanciar enemigos
	public string DondeInstanciar = "";
	public string DondeInstanciarB = "";
	public string DondeInstanciarA = "";
	public string DondeInstanciarE = "";
	public string DondeInstanciarC = "";
	public string DondeInstanciarF = "";

	void Start () {
		jugador = GameObject.FindGameObjectWithTag("Jugador");
		TiempoParaCrearEnemigos = frecuencia;
	}

	void Update () {
		//if para saber cuando cerraron el menu de instrucciones o pasaron 5 segundos para comenzar el juego
		if (TiempoComenzar > 5f || ComenzarJuego == true) {
			//switch para saber donde se van a crear los enemigos
			TiempoTranscurrido = jugador.GetComponent<Tiempo> ().puntaje;
			if (TiempoTranscurrido > TiempoParaCrearEnemigos) {
				aleatorio = Random.RandomRange (0, 4);
				switch (aleatorio) {
				case 0:
					DondeInstanciarE = "Izquierda";
					break;
				case 1:
					DondeInstanciarE = "Derecha";
					break;
				case 2:
					DondeInstanciarE = "Arriba";
					break;
				case 3:
					DondeInstanciarE = "Abajo";
					break;

				default:
					DondeInstanciarE = "izquierda";
					break;
				}
				TiempoParaCrearEnemigos += frecuencia;
			}

			//switch para sabetr donde se van a crear las vidas
			TiempoTranscurrido = jugador.GetComponent<Tiempo> ().puntaje;
			if (TiempoTranscurrido > TiempoParaCrearVidas) {
				aleatorio = Random.RandomRange (0, 4);
				switch (aleatorio) {
				case 0:
					DondeInstanciar = "Izquierda";
					break;
				case 1:
					DondeInstanciar = "Derecha";
					break;
				case 2:
					DondeInstanciar = "Arriba";
					break;
				case 3:
					DondeInstanciar = "Abajo";
					break;

				default:
					DondeInstanciar = "izquierda";
					break;
				}
				TiempoParaCrearVidas += TiempoParaCrearVidas;
			}
			//switch para saber donde se van a crear las bombas
			TiempoTranscurrido = jugador.GetComponent<Tiempo> ().puntaje;
			if (TiempoTranscurrido > TiempoParaCrearBombas) {
				aleatorio = Random.RandomRange (0, 4);
				switch (aleatorio) {
				case 0:
					DondeInstanciarB = "Izquierda";
					break;
				case 1:
					DondeInstanciarB = "Derecha";
					break;
				case 2:
					DondeInstanciarB = "Arriba";
					break;
				case 3:
					DondeInstanciarB = "Abajo";
					break;

				default:
					DondeInstanciarB = "izquierda";
					break;
				}
				TiempoParaCrearBombas += 5f;
			}

			//switch para saber donde se van a crear los aceleradoras
			TiempoTranscurrido = jugador.GetComponent<Tiempo> ().puntaje;
			if (TiempoTranscurrido > TiempoParaCrearAceleradoras) {
				aleatorio = Random.RandomRange (0, 4);
				switch (aleatorio) {
				case 0:
					DondeInstanciarA = "Izquierda";
					break;
				case 1:
					DondeInstanciarA = "Derecha";
					break;
				case 2:
					DondeInstanciarA = "Arriba";
					break;
				case 3:
					DondeInstanciarA = "Abajo";
					break;

				default:
					DondeInstanciarA = "izquierda";
					break;
				}
				TiempoParaCrearAceleradoras += 3f;
			}

			//switch para sabetr donde se van a crear las congeladoras
			TiempoTranscurrido = jugador.GetComponent<Tiempo> ().puntaje;
			if (TiempoTranscurrido > TiempoParaCrearCongeladoras) {
				aleatorio = Random.RandomRange (0, 4);
				switch (aleatorio) {
				case 0:
					DondeInstanciarC = "Izquierda";
					break;
				case 1:
					DondeInstanciarC = "Derecha";
					break;
				case 2:
					DondeInstanciarC = "Arriba";
					break;
				case 3:
					DondeInstanciarC = "Abajo";
					break;

				default:
					DondeInstanciarC = "izquierda";
					break;
				}
				TiempoParaCrearCongeladoras += 15f;
			}


			//switch para sabetr donde se van a crear las aleatorias
			TiempoTranscurrido = jugador.GetComponent<Tiempo> ().puntaje;
			if (TiempoTranscurrido > TiempoParaCrearAleatorias) {
				aleatorio = Random.RandomRange (0, 4);
				switch (aleatorio) {
				case 0:
					DondeInstanciarF = "Izquierda";
					break;
				case 1:
					DondeInstanciarF = "Derecha";
					break;
				case 2:
					DondeInstanciarF = "Arriba";
					break;
				case 3:
					DondeInstanciarF = "Abajo";
					break;

				default:
					DondeInstanciarF = "izquierda";
					break;
				}
				TiempoParaCrearAleatorias += TiempoParaCrearAleatorias;
			}

			//subir la dificultad
			AumentarDificultad ();
		} else {
			TiempoComenzar += Time.deltaTime;
		}
	}
	//reseteamos los valores de instanciar
	public void SetDondeInstanciar(string valor){
		DondeInstanciar = valor;
	}

	public void SetDondeInstanciarB(string valor){
		DondeInstanciarB = valor;
	}

	public void SetDondeInstanciarA(string valor){
		DondeInstanciarA = valor;
	}

	public void SetDondeInstanciarE(string valor){
		DondeInstanciarE = valor;
	}

	public void SetDondeInstanciarC(string valor){
		DondeInstanciarC = valor;
	}

	public void SetDondeInstanciarF(string valor){
		DondeInstanciarF = valor;
	}

	//funcion para aumentar la produccion de esporas 0.1sec cada 20 sec
	void AumentarDificultad()
	{
		if (TiempoTranscurrido > TiempoSubirDificultad && TiempoSubirDificultad < 80f) {
			frecuencia -= 0.1f;
			TiempoSubirDificultad += 20f;
		}
	}

	public void SetComenzarJuego(){
		ComenzarJuego = true;
	}
}
