var PressurePad : GameObject;

function OnTriggerEnter(Collision){
	if(PressurePad.name == "PressurePadRight"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadDown-R");
	}
	if(PressurePad.name == "PressurePadLeft"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadDown-L");
	}
	if(PressurePad.name == "PressurePadFront"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadDown-F");
	}
	if(PressurePad.name == "PressurePadBack"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadDown-B");
	}
}

function OnTriggerExit(Collision){
	if(PressurePad.name == "PressurePadRight"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadUp-R");
	}
	if(PressurePad.name == "PressurePadLeft"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadUp-L");
	}
	if(PressurePad.name == "PressurePadFront"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadUp-F");
	}
	if(PressurePad.name == "PressurePadBack"){
	PressurePad.GetComponent.<Animation>().Play("PressurePadUp-B");
	}
}

/*function onTriggerExit(Other : Collider){
	//if(Other.gameObject.tag == "PressurePad"){
		Animator.GetComponent.<Animation>().Play("PressurePadUp");
		Debug.Log("Up");
	//}
}*/

/*var Animator : GameObject; //Assign this in the editor character with animation
     
    function OnTriggerEnter(){
        Animator.GetComponent.<Animation>().Play("Animination"); // name the animation to be played
    }*/