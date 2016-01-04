using UnityEngine;
using System.Collections;

public class PressurePadScript : MonoBehaviour {

    public GameObject PressurePad;
    AskQuestion aqScript;
    GameObject gObj;


	// Use this for initialization
	void Start () {
        gObj = GameObject.Find("Projector Screen");
        aqScript = gObj.GetComponent<AskQuestion>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (PressurePad.name == "PressurePadRight")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadDown-R");
            aqScript.setPressurePad(3);
        }
        if (PressurePad.name == "PressurePadLeft")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadDown-L");
            aqScript.setPressurePad(1);
        }
        if (PressurePad.name == "PressurePadFront")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadDown-F");
            aqScript.setPressurePad(2);
        }
        if (PressurePad.name == "PressurePadBack")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadDown-B");
            aqScript.setPressurePad(4);
        }

        aqScript.setPressurePadReleased(false);
    }

    void OnTriggerExit(Collider other)
    {
        if (PressurePad.name == "PressurePadRight")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadUp-R");
        }
        if (PressurePad.name == "PressurePadLeft")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadUp-L");
        }
        if (PressurePad.name == "PressurePadFront")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadUp-F");
        }
        if (PressurePad.name == "PressurePadBack")
        {
            PressurePad.GetComponent<Animation>().Play("PressurePadUp-B");
        }

        aqScript.setPressurePadReleased(true);
    }
}
