using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour {

	public Text msg;

	void Start () {
		StartCoroutine (Messages());
	}
	
	IEnumerator Messages() {
		msg.text = "Esse jogo não tem nenhum fim político.";
		yield return new WaitForSeconds (3);
		msg.CrossFadeAlpha (0.0f, 0.5f, false);
		msg.text = "Nem está ligado a alguma coligação.";
		msg.CrossFadeAlpha (1.0f, 0.5f, false);
		yield return new WaitForSeconds (3);
		msg.CrossFadeAlpha (0.0f, 0.5f, false);
		msg.text = "Nem grava nenhuma informação do usúario.";
		msg.CrossFadeAlpha (1.0f, 0.5f, false);
		yield return new WaitForSeconds (3);
		msg.CrossFadeAlpha (0.0f, 0.5f, false);
		msg.text = "#PAZ.";
		msg.CrossFadeAlpha (1.0f, 0.5f, false);
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("MainMenu");

	}
}
