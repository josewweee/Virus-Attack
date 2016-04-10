using UnityEngine;
using System.Collections;

public class MoverEnemigos : MonoBehaviour {
	//variables para mover el objetivo
    public Transform target;//set target from inspector instead of looking in Update

	//variables de velocidad
    public float speed = 3f;
	public float VidaSpeed = 2f;  //no esta en uso

	//variables de referencia de tiempo, y para saber cuando podemos acelerar la velocidad
	private GameObject referenciaJugador;

    void Start()
    {
		referenciaJugador = GameObject.FindGameObjectWithTag ("Jugador");
        target = GameObject.FindWithTag("Jugador").transform;
    }

    void Update()
    {

        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
			if (Vector3.Distance (transform.position, target.position) > 1f) {//move if distance from target is greater than 1
				transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));

			}
		/*if(referenciaJugador.GetComponent<VidaVirus>){

		}*/
    }
	//funcion para acelerar la velocidad de las esporas
	public void AcelerarVelocidad(bool mover){
		if (mover == true) {
			speed = 5f;
		}
	}

	//funcion para congelar las esporas
	public void Congelar(bool congelacion){
		if (congelacion == true) {
			speed = 0;
		} else {
			speed = 3;
		}
	}
}
