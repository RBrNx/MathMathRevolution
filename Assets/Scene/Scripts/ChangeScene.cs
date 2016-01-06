using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    static int levelSoundIndex = 0;

    public AudioSource lvl1Music;
    public AudioSource lvl2Music;
    public AudioSource lvl3Music;
    
    void Start()
    {
        if (levelSoundIndex == 1 || levelSoundIndex == 2 || levelSoundIndex == 3)
        {
            lvl1Music.PlayDelayed(1);
        }
        else if (levelSoundIndex == 4 || levelSoundIndex == 5 || levelSoundIndex == 6)
        {
            lvl2Music.PlayDelayed(1);
        }
        else if (levelSoundIndex == 7 || levelSoundIndex == 8 || levelSoundIndex == 9)
        {
            lvl3Music.PlayDelayed(1);
        }

        levelSoundIndex = 0;
    }

	public void changeScene(string scene)
    {
			if(LoginButton.loggedIn)
			{
				GetComponent<Assessment>().StartGame(scene);
			}
			else
			{
				SceneManager.LoadScene(scene);
			}
    }

    public void setLevelSoundIndex(int newLevelSoundIndex)
    {
        levelSoundIndex = newLevelSoundIndex;
        PlayerPrefs.SetInt("levelSoundIndex", levelSoundIndex);
    }



    public void clickExit()
    {
        Application.Quit();
    }

    public void setChosenTopic(string topic)
    {
        PlayerPrefs.SetString("ChosenTopic", topic);
    }

    public void deletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
