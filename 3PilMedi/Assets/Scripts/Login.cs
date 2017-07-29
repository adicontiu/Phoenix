using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

	public GameObject HomePanal;
	public GameObject SignInPanal;
	public GameObject SignUpPanal;

	public InputField fullName;
	public InputField passWord;
	public InputField conformPassword;
	public InputField sex;
	public InputField DOB;
	public InputField email;
	public InputField add;


	private string url = "";	
	WWWForm form;

	void Start()
	{
		

	}

	public void signIn()
	{
		SignInPanal.SetActive (true);
		HomePanal.SetActive (false);
	}

	public void signUp()
	{
		SignUpPanal.SetActive (true);
		HomePanal.SetActive (false);
	}

	public void back()
	{
		HomePanal.SetActive (true);
		SignInPanal.SetActive (false);
		SignUpPanal.SetActive (false);
	}

	public void Sub()
	{
		string fn = fullName.text.ToString ();
		string pa = passWord.text.ToString ();
		string cpa = conformPassword.text.ToString ();
		string s = sex.text.ToString ();
		string D = DOB.text.ToString ();
		string em = email.text.ToString ();
		string ad = add.text.ToString ();

		form = new WWWForm ();
		form.AddField ("fullName", fn);
		form.AddField ("password", pa);
		form.AddField ("conformPassword", cpa);
		form.AddField ("add", ad);
		form.AddField ("sex", s);
		form.AddField ("DOB", D);
		form.AddField ("email", em);

		if (fn != null && pa != null && cpa != null && s != null && D != null && em != null && ad != null) {
			if (pa == cpa) {
				WWW www = new WWW (url, form);
				StartCoroutine (WaitForRequest (www));
			} else {
				passWord.text = null;
				conformPassword.text = null;
				Debug.Log ("Password not match");
			}
		} else
			Debug.Log ("Fill all info.");
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

			// check for errors
			if (www.error == null)
			{
				Debug.Log("WWW Ok!: " + www.data);
			}
			else
			{
				Debug.Log("WWW Error: "+ www.error);
			}    
	}    

}
