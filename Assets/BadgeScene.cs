using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BadgeScene : MonoBehaviour {

	public Text[] badgeNames;
	public Text[] badgeDescs;
	public Text[] badgeStatuses;

	// Use this for initialization
	void Start () {
		var badges = GetComponent<Assessment>().GetBadges();

		int i = 0;
		foreach(var badgePair in badges)
		{
			badgeNames[i].text = badgePair.Key;
			badgeDescs[i].text = badgePair.Value.Description;
			badgeStatuses[i].text = (badgePair.Value.Earned) ? "<colour=\"green\">Unlocked</colour>" : "<colour=\"red\">Locked</colour>";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
