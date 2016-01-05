using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class Badge
{
	public string Name { get; set; }
	public string Description { get; set; }
	public bool Earned { get; set; }

	public Badge(string name, string desc, bool earned)
	{
		Name = name;
		Description = desc;
		Earned = earned;
	}
}

	public class Assessment : MonoBehaviour {

	void Start()
	{
	}
	
	public void LoginGuest(string failScene, string successScene)
	{
			StartCoroutine(EngAGe.E.guestLogin(EngAGe.idSG, failScene, successScene));
	}

	public void LoginStudent(string username, string password, string failScene, string initialQuestionaireScene, string successScene)
	{
		StartCoroutine(EngAGe.E.loginStudent(EngAGe.idSG, username, password, failScene, initialQuestionaireScene, successScene));
	}

	public void StartGame(string scene)
	{
		StartCoroutine(EngAGe.E.startGameplay(EngAGe.idSG, scene));
	}

	public void UpdateGameDesc()
	{
		StartCoroutine(EngAGe.E.getGameDesc(EngAGe.idSG));
	}

	public void UpdateWonBadges()
	{
		StartCoroutine(EngAGe.E.getBadgesWon(EngAGe.idSG));
	}

	public void UpdateLeaderboard()
	{
		StartCoroutine(EngAGe.E.getLeaderboard(EngAGe.idSG));
	}

	public void SetNameAndAge(string name, string age)
	{
		var parameters = EngAGe.E.getParameters();
		parameters["name"] = name;
		parameters["age"] = age;
	}

	public string GetGameTitle()
	{
		return EngAGe.E.getSG()["mathmathrevolution"]["name"];
	}

	public string GetGameDesc()
	{
		return EngAGe.E.getSG()["mathmathrevolution"]["description"];
	}

	public Dictionary<string, int> GetScores()
	{
		Dictionary<string, int> scores = new Dictionary<string, int>();
		foreach(JSONNode node in EngAGe.E.getScores())
		{
			scores.Add(node["name"], node["value"].AsInt);
		}
		return scores;
	}

	public List<string> GetFeedback(ref bool win, ref bool lose, ref bool offerHelp)
	{
		List<string> feedback = new List<string>();

		foreach(JSONNode node in EngAGe.E.getFeedback())
		{
			string type = node["type"];
			string colour = "black";
			if(string.Equals(type, "POSITVE"))
			{
				colour = "green";
			}
			else if (string.Equals(type, "NEGATIVE"))
			{
				colour = "red";
			}
			else if (string.Equals(type, "win"))
			{
				win = true;
			}
			else if (string.Equals(type, "lose"))
			{
				lose = true;
			}
			else if (string.Equals(type, "ADAPTATION"))
			{
				offerHelp = true;
			}

			feedback.Add("<color=\"" + colour + "\">" + node["message"] + "</colour>");
		}

		return feedback;
	}

	public Dictionary<string, Badge> GetBadges()
	{
		JSONNode sg = EngAGe.E.getSG();
		Dictionary<string, Badge> badges = new Dictionary<string, Badge>();
		foreach(JSONNode node in EngAGe.E.getBadges())
		{
			string name = node["name"];
			bool earned = node["earned"].AsBool;
			string desc = "";
			if(sg != null && sg["feedback"] != null && sg["feedback"][name] != null)
			{
				desc = sg["feedback"][name]["message"];
			}
			badges.Add(node["name"], new Badge(name, desc, earned));
		}
		return badges;
	}

	public List<KeyValuePair<float, string>> getLeaderboard(int count = -1)
	{
		List<KeyValuePair<float, string>> leaderBoard = new List<KeyValuePair<float, string>>();
		foreach(JSONNode node in EngAGe.E.getLeaderboardList()["correctAnswers"].AsArray)
		{
			if(count >= 0 || leaderBoard.Count < count)
			{
				leaderBoard.Add(new KeyValuePair<float, string>(node["score"].AsFloat, node["name"]));
			}
		}
		return leaderBoard;
	}
}
