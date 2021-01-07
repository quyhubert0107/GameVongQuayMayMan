using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_question : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public string question;
		public double id;
		public double level;
		public string casea;
		public string caseb;
		public string casec;
		public string cased;
		public double truecase;
	}
}

