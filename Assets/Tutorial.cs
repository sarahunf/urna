using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

	public int tutorialDone;
	[SerializeField]
	private int whichMsg;
	[SerializeField]
	private int maxMsg = 4;
	public GameObject balaoMsg;
	public Text balaoTxt;
	public GameObject[] tutObjs;

	void Start () {
		if (PlayerPrefs.HasKey("tutorialDone")) {
			for (int i = 0; i < tutObjs.Length; i++) {
				tutObjs [i].SetActive (false);
			}
		} else {
			TutorialMessage ();
		}
	
	}

	void TutorialMessage ()
	{		
		if (tutorialDone == 0) {
			switch (whichMsg) {
			case 0:
				balaoTxt.text = "Olá, eu sou a urninha!";
				break;
			case 1:
				balaoTxt.text = "E eu tenho uma missão, rs.";
				break;
			case 2:
				balaoTxt.text = "Você já deve imaginar qual, mas vamos lá, finja surpresa.";
				break;
			case 3:
				balaoTxt.text = "Digite o número do seu candidato e aperte confirma.";
				break;
			default:
				balaoTxt.text = "Digite o número do seu candidato e aperte confirma.";
				break; 
			}
			balaoMsg.SetActive (true);
		} 

	}


	public void NxtMessage ()
	{
		balaoMsg.SetActive (false);
		whichMsg++;
		if (whichMsg >= maxMsg) {
			tutorialDone = 1;
			PlayerPrefs.SetInt ("tutorialDone", tutorialDone);
			for (int i = 0; i < tutObjs.Length; i++) {
				tutObjs [i].SetActive (false);
			}
		} else {
			TutorialMessage ();
		}
	}
		
}
