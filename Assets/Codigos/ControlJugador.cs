using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour {

	public float velocidad;
	public Text txtCuenta;
	public Text Ganaste;
	public Text Creditos;

	private int cuenta;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		cuenta = 0;
		SumarColesionables ();
		Ganaste.text = "";
		Creditos.text = "";
	}


	void FixedUpdate()
	{
		float moviHorizontal = Input.GetAxis ("Horizontal");
		float moviVertical = Input.GetAxis ("Vertical");

		Vector3 movimiento = new Vector3 (moviHorizontal, 0.0f, moviVertical);


		rb.AddForce (movimiento * velocidad);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Recolectables"))
		{
			other.gameObject.SetActive (false);
			cuenta = cuenta + 1;
			SumarColesionables ();
		}
	}

	void SumarColesionables ()
	{
		txtCuenta.text = "Colecionables: " + cuenta.ToString ();
		if (cuenta >= 9)
		{
			Ganaste.text = "¡GANASTE!";
			Creditos.text = "Juego creado por: Juan Rodriguez.";
		}
	}
}
