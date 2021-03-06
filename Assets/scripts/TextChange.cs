﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class TextChange : MonoBehaviour
{

	public Text vote1;
	public Text vote2;

	public int voteInt1;
	public int voteInt2;

	public int num;
	private bool filledNum = false;

	public GameObject haddadMsg;
	public GameObject bozoMsg;
	public GameObject segTurnoMsg;
	public GameObject[] personagensBozo;

	public Text haddadTxt;
	public Text bozoTxt;
	public Text segTurnoTxt;

	public GameObject haddadBtn;
	public GameObject bozoBnt;
	public GameObject segTurnoBtn;

	public int vote17;
	public int prsn17;

	public bool votandoNoBozo = false;
	public bool checkingVote = false;

	public GameObject balaoMsg;
	public Text balaoText;
	private int balao17;

	public GameObject partyParticle;
	public GameObject horrorParticle;

	public AudioSource partyAud;
	public AudioSource horrorAud;

	public Animation line1;
	public Animation line2;
	public GameObject line1Obj;
	public GameObject line2Obj;

	void Start () {
		line1 = line1Obj.GetComponent<Animation> ();
		line2 = line2Obj.GetComponent<Animation> ();
	}

	void Update () {
		
		if (string.IsNullOrEmpty (vote1.text)) {
			line1Obj.SetActive (true);
			line1.Play ();

		} else if (string.IsNullOrEmpty (vote2.text)) {
			line2Obj.SetActive (true);
			line2.Play ();
		} else {
			line1Obj.SetActive (false);
			line2Obj.SetActive (false);
			line1.Stop ();
			line2.Stop ();
		}
	}

	public void FinishedVoting ()
	{
		if (string.IsNullOrEmpty (vote1.text)) {
			voteInt1 = -1;
		} else {
			voteInt1 = int.Parse (vote1.text);
		}
		if (string.IsNullOrEmpty (vote2.text)) {
			voteInt2 = -1;
		} else {
			voteInt2 = int.Parse (vote2.text);
		}

		if (voteInt1 == 1 && voteInt2 == 7) {
			votandoNoBozo = true;
			PersonagensQueVotamNoBozo ();
			if (!checkingVote) {
				BaloesDoBozo ();
			}
		} else if (voteInt1 == 1 && voteInt2 == 3) {
			personagensBozo [17].SetActive (true);
		} else {
			
			balaoMsg.SetActive (false);
			for (int i = 0; i < personagensBozo.Length; i++) { 
				personagensBozo [i].SetActive (false);
			}

		}
	}


	public void CheckIfNumIsFilled ()
	{
		num = btnsChoice.btnNum;

		if (!filledNum) {
			filledNum = true;
			vote1.text = num.ToString ();

		
		} else if (filledNum) {
			filledNum = false;
			vote2.text = num.ToString ();
		}
	}

	public void CheckVote ()
	{
		checkingVote = true;

		balaoMsg.SetActive (false);
		balaoText.text = " ";


		if (string.IsNullOrEmpty (vote1.text)) {
			voteInt1 = -1;
		} else {
			voteInt1 = int.Parse (vote1.text);
		}
		if (string.IsNullOrEmpty (vote2.text)) {
			voteInt2 = -1;
		} else {
			voteInt2 = int.Parse (vote2.text);
		}

		if (voteInt1 == 1 && voteInt2 == 3) {
			haddadMsg.SetActive (true);
			haddadBtn.SetActive (true);

			ParticleSystem psParty = partyParticle.GetComponent<ParticleSystem> ();
			psParty.Play ();
			partyAud.Play ();

		} else if (voteInt1 == 1 && voteInt2 == 7) {
			
			ParticleSystem psHorror = horrorParticle.GetComponent<ParticleSystem> ();
			psHorror.Play ();
			horrorAud.Play ();

			VotoBozo ();


		} else {
			segTurnoMsg.SetActive (true);
			segTurnoBtn.SetActive (true);
		}

	}

	public void PlayerPrefsDeleteKeys ()
	{
		PlayerPrefs.DeleteKey ("votoBozo");
		PlayerPrefs.DeleteKey ("prsnBozo");
		PlayerPrefs.DeleteKey ("balaoBozo");
		PlayerPrefs.DeleteKey ("tutorialDone");
	}

	public void VotoEmBranco () {
		
			balaoMsg.SetActive (false);
			balaoText.text = "";

		vote1.text = "";
		vote2.text = "";

		filledNum = false;

		votandoNoBozo = false;

		checkingVote = false;

		for (int i = 0; i < personagensBozo.Length; i++) { 
			personagensBozo [i].SetActive (false);
		}

		ParticleSystem psHorror = horrorParticle.GetComponent<ParticleSystem>();
		psHorror.Stop ();
		ParticleSystem psParty = horrorParticle.GetComponent<ParticleSystem>();
		psParty.Stop ();

		segTurnoMsg.SetActive (true);
		segTurnoBtn.SetActive (true);
		segTurnoTxt.text = "Que revolucionário votar em branco hein? Tente novamente.";
	}

	public void VotoBozo ()
	{
		int randomMsgBozo = Random.Range (0, 6);

		switch (randomMsgBozo) {
		case 0:
			bozoTxt.text = "Nossa... sério?";
			break;
		case 1:
			bozoTxt.text = "Cê não tem vergonha não?";
			break;
		case 2:
			bozoTxt.text = "Depois não pode fingir que não votou em mim hein?";
			break;
		case 3:
			bozoTxt.text = "Nossa, cruzes.";
			break;
		case 4:
			bozoTxt.text = "Jesus tá vendo seu voto e vai cobrar.";
			break;
		default:
			bozoTxt.text = "Repense suas prioridades.";
			break;
		}

		bozoMsg.SetActive (true);
		bozoBnt.SetActive (true);

		vote17++;
		PlayerPrefs.SetInt ("votoBozo", vote17);

	}

	public void PersonagensQueVotamNoBozo ()
	{ 
		prsn17 = PlayerPrefs.GetInt ("prsnBozo", prsn17);

		switch (prsn17) {

		case 0:
			personagensBozo [0].SetActive (true);
			break;
		case 1:
			personagensBozo [1].SetActive (true);
			personagensBozo [0].SetActive (false);
			break;
		case 2:
			personagensBozo [2].SetActive (true);
			personagensBozo [1].SetActive (false);
			break;
		case 3:
			personagensBozo [3].SetActive (true);
			personagensBozo [2].SetActive (false);

			break;
		case 4:
			personagensBozo [4].SetActive (true);
			personagensBozo [3].SetActive (false);

			break;
		case 5:
			personagensBozo [5].SetActive (true);
			personagensBozo [4].SetActive (false);
			break;
		case 6:
			personagensBozo [6].SetActive (true);
			personagensBozo [5].SetActive (false);
			break;
		case 7:
			personagensBozo [7].SetActive (true);
			personagensBozo [6].SetActive (false);
			break;
		case 8:
			personagensBozo [8].SetActive (true);
			personagensBozo [7].SetActive (false);
			break;
		case 9:
			personagensBozo [9].SetActive (true);
			personagensBozo [8].SetActive (false);
			break;
		case 10:
			personagensBozo [10].SetActive (true);
			personagensBozo [9].SetActive (false);
			break;
		case 11:
			personagensBozo [11].SetActive (true);
			personagensBozo [10].SetActive (false);
			break;
		case 12:
			personagensBozo [12].SetActive (true);
			personagensBozo [11].SetActive (false);
			break;
		case 13:
			personagensBozo [13].SetActive (true);
			personagensBozo [12].SetActive (false);
			break;
		case 14:
			personagensBozo [14].SetActive (true);
			personagensBozo [13].SetActive (false);
			break;
		case 15:
			personagensBozo [15].SetActive (true);
			personagensBozo [14].SetActive (false);
			break;
		case 16:
			personagensBozo [16].SetActive (true);
			personagensBozo [15].SetActive (false);
			break;

		default:
			for (int i = 0; i < personagensBozo.Length; i++) {               
				personagensBozo [i].SetActive (false);
			}
			int randomPers = Random.Range (0, (personagensBozo.Length + 1));
			Debug.Log (randomPers);
			if (!checkingVote) {
				personagensBozo [randomPers].SetActive (true);
			}
			break;
		}
	}

	public void BaloesDoBozo ()
	{

		balao17 = PlayerPrefs.GetInt ("balaoBozo", balao17);
		balaoMsg.SetActive (true);

		switch (balao17) {

		case 0:
			balaoText.text = "Muah ha ha ha, eu defendo o aumento do imposto de renda dos pobres...";
			break;
		case 1:
			balaoText.text = "Apresentei três projetos ligados a econômia durante 30 anos de política." +
				"1 a cada 10 anos está bom pra você?";
			break;
		case 2:
			balaoText.text = "Inocente... Eu votei a favor da terceirização e da PEC que congela investimentos.";
			break;
		case 3:
			balaoText.text = "Em entrevista, afirmei que mulheres devem ganhar menos porque engravidam.";
			break;
		case 4:
			balaoText.text = "Ai, quero salvar o Brasil, mas 'Desaparecidos do Araguaia? Quem procura osso é cachorro.'";
			break;
		case 5:
			balaoText.text = "Estatuto da Criança e do Adolescente(ECA)? Joga na latrina!" ;
			break;
		case 6:
			balaoText.text = "Trabalhador rural? Tenho uma nova carteira pra você, hein? A cateira que eu faço o que quiser e você obedece! HAHA. Vai é trabalhar todo dia.";
			break;
		case 7:
			balaoText.text = "Vou colocar só bruxão nos ministério hein? Bruxão do medo.";
			break;
		case 8:
			balaoText.text = "Vou derrubar o nordeste, a amazônia e se encher muito o saco, derrubo a ONU." ;
			break;
		case 9:
			balaoText.text = "Acordo de Paris? HA HA HA HA. Eu quero mesmo é acabar com meu país!";
			break;
		case 10:
			balaoText.text = "39 ministérios? Que piada, vamo juntar tudo, fazer uns 5 só e colocar uns coroneis lá, acho que vai dar certo sim." ;
			break;
		case 11:
			balaoText.text = "Merenda e formação social? Mas pra que se dá pra ensinar tudo a distância? Povo não pensa, sabe.";
			break;
		case 12:
			balaoText.text = "Ficou grávida e trabalha em condições insalubres? Poxa que pena, pra mim nasce ai no chão da fábrica mesmo.";
			break;
		case 13:
			balaoText.text = "O filho começa a ficar assim meio gayzinho, leva um coro, muda o comportamento dele, tá certo?" ;
			break;
		case 14:
			balaoText.text = "Direto trabalhista? HAHA DEVERES trabalhistas né?";
			break;
		case 15:
			balaoText.text = "Po, tenho um cara de confiança mesmo pra Economia, amigão dos grandes e pequenos ricos. Vai tá do lado do povo sempre.";
			break;
		case 16: 
			balaoText.text = "Xiiiu, mas patrimônio público tem que tá é na mao dos especuladores! Ai sim a desigualdade aumenta!";
			break;
		case 17:
			balaoText.text = "Pow pow pow!Já vai se acostumando com os barulho de tiro... ops, acertei uma testa";
			break;
		default:
			balaoText.text = "Brasil vai virar Venezuela";
			break;

		}
	}

	public void RestartVote ()
	{

		if (string.IsNullOrEmpty (vote1.text)) {
			voteInt1 = -1;
		} else {
			voteInt1 = int.Parse (vote1.text);
		}
		if (string.IsNullOrEmpty (vote2.text)) {
			voteInt2 = -1;
		} else {
			voteInt2 = int.Parse (vote2.text);
		}

		if (voteInt1 == 1 && voteInt2 == 7) {

			prsn17++;
			PlayerPrefs.SetInt ("prsnBozo", prsn17);

			balao17++;
			PlayerPrefs.SetInt ("balaoBozo", balao17);
			balaoMsg.SetActive (false);
			balaoText.text = "";
		
		}
		vote1.text = "";
		vote2.text = "";

		filledNum = false;

		votandoNoBozo = false;

		checkingVote = false;

		for (int i = 0; i < personagensBozo.Length; i++) { 
			personagensBozo [i].SetActive (false);
		}

		ParticleSystem psHorror = horrorParticle.GetComponent<ParticleSystem>();
		psHorror.Stop ();
		ParticleSystem psParty = horrorParticle.GetComponent<ParticleSystem>();
		psParty.Stop ();

	}

	public void GoToMainMenu () {
		SceneManager.LoadScene ("MainMenu");
	}
}


