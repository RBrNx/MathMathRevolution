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
		StartCoroutine(EngAGe.E.loginStudent(EngAGe.idSG, username, password, failScene, successScene, initialQuestionaireScene));
	}

	public void StartGame(string scene)
	{
		if(LoginButton.loggedIn)
			StartCoroutine(EngAGe.E.startGameplay(EngAGe.idSG, scene));
	}

	public void UpdateGameDesc()
	{
		if (LoginButton.loggedIn)
			StartCoroutine(EngAGe.E.getGameDesc(EngAGe.idSG));
	}

	public void UpdateWonBadges()
	{
		if (LoginButton.loggedIn)
			StartCoroutine(EngAGe.E.getBadgesWon(EngAGe.idSG));
	}

	public void UpdateLeaderboard()
	{
		if (LoginButton.loggedIn)
			StartCoroutine(EngAGe.E.getLeaderboard(EngAGe.idSG));
	}

	public void SetNameAndAge(string name, string age)
	{
		if (LoginButton.loggedIn)
		{
			var parameters = EngAGe.E.getParameters();
			parameters["name"] = name;
			parameters["age"] = age;
		}
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
		if (LoginButton.loggedIn)
		{
			Dictionary<string, int> scores = new Dictionary<string, int>();
			foreach (JSONNode node in EngAGe.E.getScores())
			{
				scores.Add(node["name"], node["value"].AsInt);
			}
			return scores;
		}
		return default(Dictionary<string, int>);
	}

	public string ConvertFeedback(JSONNode data, ref bool win, ref bool lose, ref bool offerHelp)
	{
		string value = "";
		if (LoginButton.loggedIn)
		{
			JSONArray feedbackArray = data["feedback"].AsArray;
			foreach (JSONNode node in feedbackArray)
			{
				string type = node["type"];
				string colour = "black";
				if (string.Equals(type, "POSITIVE"))
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
				value += "<color=\"" + colour + "\">" + node["message"] + "</color>\n";
			}
		}
		return value;
	}

	public List<string> GetFeedback(ref bool win, ref bool lose, ref bool offerHelp)
	{
		if (LoginButton.loggedIn)
		{
			List<string> feedback = new List<string>();

			foreach (JSONNode node in EngAGe.E.getFeedback())
			{
				string type = node["type"];
				string colour = "black";
				if (string.Equals(type, "POSITVE"))
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

				feedback.Add("<color=\"" + colour + "\">" + node["message"] + "</color>");
			}

			return feedback;
		}

		return default(List<string>);
	}

	public Dictionary<string, Badge> GetBadges()
	{
		if (LoginButton.loggedIn)
		{
			JSONNode sg = EngAGe.E.getSG();
			Dictionary<string, Badge> badges = new Dictionary<string, Badge>();
			foreach (JSONNode node in EngAGe.E.getBadges())
			{
				string name = node["name"];
				bool earned = node["earned"].AsBool;
				string desc = "";
				if (sg != null && sg["feedback"] != null && sg["feedback"][name] != null)
				{
					desc = sg["feedback"][name]["message"];
				}
				badges.Add(node["name"], new Badge(name, desc, earned));
			}
			return badges;
		}

		return default(Dictionary<string, Badge>);
	}

	public List<KeyValuePair<float, string>> getLeaderboard(int count = -1)
	{
		if (LoginButton.loggedIn)
		{
			List<KeyValuePair<float, string>> leaderBoard = new List<KeyValuePair<float, string>>();
			foreach (JSONNode node in EngAGe.E.getLeaderboardList()["correctAnswers"].AsArray)
			{
				if (count >= 0 || leaderBoard.Count < count)
				{
					leaderBoard.Add(new KeyValuePair<float, string>(node["score"].AsFloat, node["name"]));
				}
			}
			return leaderBoard;
		}

		return default(List<KeyValuePair<float, string>>);
	}

	public void AnswerQuestion(bool correct, System.Action<JSONNode> action)
	{
		if (LoginButton.loggedIn)
		{
			JSONNode vals = JSON.Parse("{\"thing\" : \"\"}");
			StartCoroutine(EngAGe.E.assess(correct?"answerCorrectly":"answerIncorrectly", vals, action));
		}
	}

	public void EndGame(int score)
	{
		if(LoginButton.loggedIn)
		{
			foreach(JSONNode node in EngAGe.E.getScores())
			{
				if(node["name"] == "score")
				{
					node["name"].AsInt = score;
				}
			}
		}
	}
}
