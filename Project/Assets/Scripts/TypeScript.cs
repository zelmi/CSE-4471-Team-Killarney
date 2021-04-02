using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class TypeScript : MonoBehaviour 
{

	Text txt;
	string story;

	void Start () 
	{
		txt = GetComponent<Text> ();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine ("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
			txt.text += c;
			yield return new WaitForSeconds (0.075f);
		}
	}

}

