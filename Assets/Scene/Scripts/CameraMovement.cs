using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    float timeTaken = 1;
    bool isLerping = false;
    Vector3 startPos;
    Vector3 endPos;
    Quaternion startPosQ;
    Quaternion endPosQ;
    float timeStarted;

	// Use this for initialization
	void Start () {
        GameObject.Find("Canvas").SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        if (isLerping)
        {
            float timeSinceStart = Time.time - timeStarted;
            float percentageComplete = timeSinceStart / timeTaken;

            transform.position = Vector3.Lerp(startPos, endPos, percentageComplete);
            transform.rotation = Quaternion.Lerp(startPosQ, endPosQ, percentageComplete);

            if (percentageComplete >= 1)
            {
                isLerping = false;
                GameObject.Find("Canvas").SetActive(false);
                GameObject.Find("_Manager").GetComponent<ChangeScene>().changeScene(1);
            }
        }
    }

    public void startLerp()
    {
        isLerping = true;
        timeStarted = Time.time;

        startPos = transform.position;
        endPos.Set(-0.1f, 4.024f, 5.055f);

        startPosQ = transform.rotation;
        endPosQ.Set(0, 0, 0, 1);
    }
}
