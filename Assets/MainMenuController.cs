using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public Toggle SoundButton;
	private const string mutePPK = "urnaSound";

	public void LoadGame () {
		SceneManager.LoadScene ("urnakk");
			
	}

	public void PlayerPrefsDeleteKeys ()
	{
		PlayerPrefs.DeleteKey ("votoBozo");
		PlayerPrefs.DeleteKey ("prsnBozo");
		PlayerPrefs.DeleteKey ("balaoBozo");
		PlayerPrefs.DeleteKey ("tutorialDone");
	}

	private void Start()
	{
		if ((PlayerPrefs.GetInt (mutePPK, 0) == 1) && !SoundButton.isOn)
			MuteGlobal ();
	}

	private void MuteGlobal()
	{
		AudioListener.volume = 0f;
		PlayerPrefs.SetInt (mutePPK, 1);
	}


	private void UnmuteGlobal()
	{
		AudioListener.volume = 1f;
		PlayerPrefs.SetInt (mutePPK, 0);
	}

	public void AppQuit () {
		Application.Quit ();
		Debug.Log ("app quited");
	}		
}
