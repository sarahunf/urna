using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnsChoice : MonoBehaviour {

	public GameObject btnsClicked;
	public GameObject TextController;
	public static int btnNum;



	public void CheckClick () {


		if (btnsClicked.tag == "bt1") {
				btnNum = 1;
			Debug.Log (btnNum);
		} else if (btnsClicked.tag == "bt2") {
				btnNum = 2;
			}
		else if (btnsClicked.tag == "bt3") {
				btnNum = 3;
			}
		else if (btnsClicked.tag == "bt4") {
				btnNum = 4;
			}
		else if (btnsClicked.tag == "bt5") {
				btnNum = 5;
			}
		else if (btnsClicked.tag == "bt6") {
				btnNum = 6;
			}
		else if (btnsClicked.tag == "bt7") {
				btnNum = 7;
			}
		else if (btnsClicked.tag == "bt8") {
				btnNum = 8;
			}
		else if (btnsClicked.tag == "bt9") {
				btnNum = 9;
			}
		else if (btnsClicked.tag == "bt0") {
				btnNum = 0;
		}

		TextController.GetComponent<TextChange>().CheckIfNumIsFilled ();
	}
	
}
