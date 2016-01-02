using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Question
{
	public List<string> components, operators, correctAnswers, incorrectAnswers;
	public List<bool> hidden;

	public Question()
	{
		components = new List<string>();
		operators = new List<string>();
		correctAnswers = new List<string>();
		incorrectAnswers = new List<string>();
		hidden = new List<bool>();
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
																		components = from factor in question.Descendants("Factor") select new { value = factor.Attribute("value").Value },
																		operators = from _operator in question.Descendants("Operator") select new { value = _operator.Attribute("value").Value },
																		incorrectAnswers = from incorrectAnswer in question.Descendants("IncorrectAnswer") select new { value = incorrectAnswer.Attribute("value").Value },
																		correctAnswers = from correctAnswer in question.Descendants("CorrectAnswer") select new { value = correctAnswer.Attribute("value").Value },
																	},
										};

		Dictionary<string, List<Question>> questionsDictionary = new Dictionary<string, List<Question>>();
		foreach(var topic in questions)
		{
			List<Question> questionList = new List<Question>();
			foreach(var question in topic.questions)
			{
				Question newQuestion = new Question();
				foreach(var component in question.components)
				{
					newQuestion.components.Add(component.value);
				}
				foreach (var _operator in question.operators)
				{
					newQuestion.operators.Add(_operator.value);
				}
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
