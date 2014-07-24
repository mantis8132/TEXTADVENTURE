using UnityEngine;
using System.Collections;

public class TextAdventure : MonoBehaviour {

	void Start () {
	
	}

	string currentRoom = "Lobby";
	bool hasKey = false;
	bool hasKnife = false;
	bool gateOpened = false;
	void Update () {
			
		string textBuffer = "You are currently in: " + currentRoom + "\n";

		if ( currentRoom == "Lobby" ) {

			textBuffer += "\nYou see the security guard.\n";

			textBuffer += "\npress [W] to go to elevators";
			textBuffer += "\npress [S] to go outside";

			if ( hasKnife == true ) {
				textBuffer+= "\n\n [K]ill security guard";
			} 

			if (Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Elevators";
			} else if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Outside";
			} else if ( Input.GetKeyDown (KeyCode.K) && (hasKnife == true) ) {
				currentRoom = "......";
			}
		} else if ( currentRoom == "......" ) {
			textBuffer += "\nThe security guard lies on the ground\nhelpless....hopeless...";
			textBuffer += "\n[S]tab yourself";
			textBuffer += "\npress [W] to go to elevators";
			textBuffer += "\npress [S] to go outside";
			
			if (Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "You Win";
			} else if (Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Elevators";
			} else if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Outside";
			}

		} else if ( currentRoom == "You Win" ) {

			textBuffer += "\nYou accepted death and chose it willingly...\nYOU WIN YOU WIN YOU WIN";

		} else if ( currentRoom == "Elevators" ) {

			textBuffer += "\nYou close the Elevator Door.\nBlood drips from the buttons...";

			textBuffer += "\npress [3] to press the 3rd Flr button...";
			textBuffer += "\npress [S] to return to the Lobby";
			
			if (Input.GetKeyDown (KeyCode.Alpha3) ) {
				currentRoom = "...";
			} else if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Lobby";
			}
		
		} else if ( currentRoom == "Outside" ) {

			textBuffer += "\nYou creak the front door closed\nThe Moon lights the way";
			
			textBuffer += "\npress [W] to return to the Lobby";
			textBuffer += "\npress [S] to head to the Gate";
			textBuffer += "\npress [A] to enter the Garden";
			textBuffer += "\npress [D] to sit by the Fountain";
			
			if (Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Lobby";
			} else if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Gate";
			} else if ( Input.GetKeyDown (KeyCode.A) ) {
				currentRoom = "Garden";
			} else if ( Input.GetKeyDown (KeyCode.D) ) {
				currentRoom = "Fountain";
			}
			
		} else if ( currentRoom == "..." ) {

			textBuffer += "\nYou contract Hepatitis C...\n....you die\n\nGAME OVER";


		} else if ( currentRoom == "Gate") {
			
			textBuffer += "\nThe Gate rises high above your head..\n";
			textBuffer += "\n[S]cale the Gate";
			textBuffer += "\npress [W] to return to the Lobby";
			textBuffer += "\npress [A] to enter the Garden";
			textBuffer += "\npress [D] to sit by the Fountain";
			
			if (gateOpened == false) {
				textBuffer += "\n[U]nlock gate with key";
			} else if (gateOpened == true ) {
				textBuffer += "\n[L]eave the estate";
			} 

			if ( Input.GetKeyDown (KeyCode.U) && (gateOpened == false) && (hasKey == false) ) {
				textBuffer += "\nYou need a key";
			}
			if (Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Lobby";
			} else if ( Input.GetKeyDown (KeyCode.A) ) {
				currentRoom = "Garden";
			} else if ( Input.GetKeyDown (KeyCode.D) ) {
				currentRoom = "Fountain";
			} else if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "....";
			} else if ( Input.GetKeyDown (KeyCode.U) && (gateOpened == false) && (hasKey == true) ) {
				currentRoom = "Road to Memphis";
				gateOpened = true;
			} else if ( (gateOpened == true) && (Input.GetKeyDown (KeyCode.L))){
				currentRoom = "Road to Memphis";
			}

		} else if ( currentRoom == "Fountain" ) {
			
			textBuffer += "\nThe fountain shimmers in the Moonlight\n";
				textBuffer += "\npress [W] to return to the Lobby";
				textBuffer += "\npress [S] to head to the Gate";
				textBuffer += "\npress [A] to enter the Garden";

			if (hasKey == false) {
				textBuffer += "\n[P]lay with the water";
			} 

			if ( (Input.GetKeyDown (KeyCode.P)) && (hasKey = false)) {
				textBuffer += "\nYou discover a key in the water and pick it up.";
				hasKey = true;
			} else if (Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Lobby";
			} else if ( Input.GetKeyDown (KeyCode.A) ) {
				currentRoom = "Garden";
			} else if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Gate";
			}

		} else if ( currentRoom == "Garden" ) {

			textBuffer += "\nThe lovely roses surround you\n A statue stands before you trying to stab the moon";
			textBuffer += "\nPress [W] to return to the Lobby";
			textBuffer += "\nPress [S] to head to the Gate";
				
			if (hasKnife == false) {
				textBuffer += "\n[R]est against the statue";

			} else {
				textBuffer+= "\nA knife drops from the statue, you pick it up";
			}

			if (Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Lobby";
			} else if (Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Gate";
			} else if (Input.GetKeyDown (KeyCode.R) && (hasKnife == false) ){
				hasKnife = true;

			}

		} else if ( currentRoom == "....") {
			           
			textBuffer += "\nYou slice open a vein and bleed to death....\n....you die\n\nGAME OVER";		

			

		} else if ( currentRoom == "Road to Memphis") {
			
			textBuffer += "\n[T]raverse the dark cold night?";
			textBuffer += "\n[R]eturn to the Mansion";
			        
			if (Input.GetKeyDown (KeyCode.T) ) {
				currentRoom = ".....";
			} else if ( Input.GetKeyDown (KeyCode.R) ) {
						currentRoom = "Outside";
			}

		} else if ( currentRoom == "....." ) {
			
			textBuffer += "\nThe cold night envelopes you.\nThere is no one to be found....\n....you die\n\n GAME OVER";


		}

		GetComponent<TextMesh>().text = textBuffer;
	}
}