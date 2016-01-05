using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject PauseUI;
    GameObject gObj;
    ChangeScene csScript;

    private bool paused = false;
    private bool setPause;
    int levelSoundIndex;


	// Use this for initialization
	void Start () {
        levelSoundIndex = PlayerPrefs.GetInt("levelSoundIndex");
        PauseUI.SetActive(false);
        gObj = GameObject.Find("_Manager");
        csScript = gObj.GetComponent<ChangeScene>();
    }
	
	// Update is called once per frame
	void Update () {
	
        if(setPause == true)
        {
            paused = !paused;
            setPause = false;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;

            if(levelSoundIndex == 1 || levelSoundIndex == 2 || levelSoundIndex == 3)
            {
                csScript.lvl1Music.Pause();
            }
            else if (levelSoundIndex == 4 || levelSoundIndex == 5 || levelSoundIndex == 6)
            {
                csScript.lvl1Music.Pause();
            }
            else if (levelSoundIndex == 7 || levelSoundIndex == 8 || levelSoundIndex == 9)
            {
                csScript.lvl1Music.Pause();
            }
        }
        else
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;

            if (levelSoundIndex == 1 || levelSoundIndex == 2 || levelSoundIndex == 3)
            {
                csScript.lvl1Music.UnPause();
            }
            else if (levelSoundIndex == 4 || levelSoundIndex == 5 || levelSoundIndex == 6)
            {
                csScript.lvl1Music.UnPause();
            }
            else if (levelSoundIndex == 7 || levelSoundIndex == 8 || levelSoundIndex == 9)
            {
                csScript.lvl1Music.UnPause();
            }
        }        
	}

    public void setGamePause(bool setGamePause)
    {
        setPause = setGamePause;
    }
}
