using UnityEngine;
using System.Collections;

using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;


public class FinDelJuego : MonoBehaviour {

	//VARIABLES DE REFERENCIA
	public GameObject Jugador;

	//VARIABLES NORMALES
	private int VidasRestantes;
	private float Puntaje;
	private float PuntajeMaximo;

	//VARIABLES DE PLUBLICIDAD DE GOOGLE
	private InterstitialAd interstitial;
	private static string outputMessage = "";
	public static string OutputMessage
	{
		set { outputMessage = value; }
	}
	//PIDO EL INTERSITIAL DE PUBLICIDAD AL INICIAL EL JUEGO
	void Awake(){
		RequestInterstitial ();
	}

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
			ShowInterstitial(); //MUESTRO PUBLICIDAD
		}
	}

/*---------------------------------GOOGLE ADMOB API----------------------------------------------------*/
	private void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4767223538922579/6049188649";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
		}

		// Returns an ad request with custom ad targeting.
		private AdRequest createAdRequest()
		{
		return new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)
		.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword("game")
		.SetGender(Gender.Male)
		.SetBirthday(new DateTime(1985, 1, 1))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();
		}

		private void ShowInterstitial()
		{
		if (interstitial.IsLoaded())
		{
		interstitial.Show();
		}
		else
		{
		print("Interstitial is not ready yet.");
		}
		}

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		print("HandleInterstitialLoaded event received.");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		print("HandleInterstitialOpened event received");
		}

		void HandleInterstitialClosing(object sender, EventArgs args)
		{
		print("HandleInterstitialClosing event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		print("HandleInterstitialLeftApplication event received");
		}

		#endregion
}



