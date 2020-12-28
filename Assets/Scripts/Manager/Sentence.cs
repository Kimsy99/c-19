using System;
using UnityEngine;

[Serializable]
public class Sentence
{
	public Sprite image;
	[TextArea]
	public string text;
	public bool isInstruction;
}
