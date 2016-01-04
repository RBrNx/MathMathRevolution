using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Question
{
	public string question;
	public List<string> correctAnswers, incorrectAnswers;

	public Question()
	{
		question = "";
		correctAnswers = new List<string>();
		incorrectAnswers = new List<string>();
	}

	static public Dictionary<string, List<Question>> loadQuestions(string fileContents)
	{
		XDocument doc = XDocument.Parse(fileContents);

		var questions = from topic in doc.Descendants("Topic")
										select new
										{
											name = topic.Attribute("name").Value,
											questions = from question in topic.Descendants("Question")
																	select new
																	{
																		question = question.Attribute("value").Value,
																		incorrectAnswers = from incorrectAnswer in question.Descendants("IncorrectAnswer") select new { value = incorrectAnswer.Attribute("value").Value },
																		correctAnswers = from correctAnswer in question.Descendants("CorrectAnswer") select new { value = correctAnswer.Attribute("value").Value },
																	},
										};

		Dictionary<string, List<Question>> questionsDictionary = new Dictionary<string, List<Question>>();
		foreach (var topic in questions)
		{
			List<Question> questionList = new List<Question>();
			foreach (var question in topic.questions)
			{
				Question newQuestion = new Question();
				newQuestion.question = question.question;
				foreach (var incorrectAnswer in question.incorrectAnswers)
				{
					newQuestion.incorrectAnswers.Add(incorrectAnswer.value);
				}
				foreach (var correctAnswer in question.correctAnswers)
				{
					newQuestion.correctAnswers.Add(correctAnswer.value);
				}
				questionList.Add(newQuestion);
			}
			questionsDictionary.Add(topic.name, questionList);
		}
		return questionsDictionary;
	}
}
