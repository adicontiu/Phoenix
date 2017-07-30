using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Che : MonoBehaviour {

	public GameObject HomePanal;
	public GameObject SignInPanal;
	public GameObject SignUpPanal;
	public GameObject SignUpPanalChemiste;
	public GameObject mediocor;

	public InputField fullName;
	public InputField passWord;
	public InputField conformPassword;
	public InputField sex;
	public InputField DOB;
	public InputField email;
	public InputField add;

//	public InputField UserName;
//	public InputField _password;
	public Text conso;

	private string boo = "0";
	private string url = "localhost/Andrid/signin.php";	
//	private string url1 = "localhost/Andrid/incert.php";	
	WWWForm form;
	float t = 4f;

	void Update()
	{
		t = +Time.deltaTime;
		//Debug.Log (t.ToString ());
		if (t == 3f)
		{
			conso.text = null;
			t = 4f;
		}

	}

	public void signIn()
	{
		SignInPanal.SetActive (true);
		HomePanal.SetActive (false);
		SignUpPanalChemiste.SetActive (false);
	}

//	public void signUp()
//	{
//		mediocor.SetActive (true);
//
//		HomePanal.SetActive (false);
//	}

	public void signInChemiste()
	{
//		SignUpPanalChemiste.SetActive (true);
//		mediocor.SetActive (false);
		boo = "1";
	}

	public void signInCustomer()
	{
//		SignUpPanal.SetActive (true);
//		mediocor.SetActive (false);
		boo = "0";
	}

	public void back()
	{
		HomePanal.SetActive (true);
		SignInPanal.SetActive (false);
		SignUpPanal.SetActive (false);
		SignUpPanalChemiste.SetActive (false);
	}
//	public void SignInSub()
//	{
//		string un = UserName.text.ToString ();
//		string _p = _password.text.ToString ();
//		form = new WWWForm ();
//		form.AddField ("UserName", un);
//		form.AddField ("_password", _p);
//		if (un != null && _p != null)
//		{
//			WWW www = new WWW (url1, form);
//			StartCoroutine (WaitForRequest1 (www));
//		}
//	}


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
		form.AddField ("Bool", boo);

		if (fn != null && pa != null && cpa != null && s != null && D != null && em != null && ad != null) {
			if (pa == cpa) {
				WWW www = new WWW (url, form);
				StartCoroutine (WaitForRequest (www));
			} else {
				passWord.text = null;
				conformPassword.text = null;
				conso.text = "Password not match";
				t = 0f;
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
			//Debug.Log("WWW Ok!: " + www.data);
			if (www.data == "1") {
				conso.text = "Sucess";
				t = 0f;
				Debug.Log ("Sucess");
				signIn ();
			}
			else if (www.data == "3") 
			{
				conso.text = "Email exist";
				t = 0f;
				Debug.Log ("Email exist");
			} 
			else if (www.data == "5")
			{
				conso.text = "Fill all the atributs";
				t = 0f;
				Debug.Log ("Fill all the atributs");
			}
			else {
				conso.text = "SignUp failed";
				t = 0f;
				Debug.Log ("SignUp failed");
			}
		}
		else
		{
			conso.text = "WWW Error: " + www.error;
			t = 0f;
			Debug.Log("WWW Error: "+ www.error);
		}    
	}    
//	IEnumerator WaitForRequest1(WWW www)
//	{
//		yield return www;
//
//		// check for errors
//		if (www.error == null)
//		{
//			//Debug.Log("WWW Ok!: " + www.data);
//			if (www.data == "1") 
//			{
//				Application.LoadLevel (1);
//			}
//			else {
//				conso.text = "Faild to signIn";
//				t = 0f;
//				Debug.Log ("Faild to signIn");
//			}
//		}
//		else
//		{
//			conso.text = "WWW Error: " + www.error;
//			t = 0f;
//			Debug.Log("WWW Error: "+ www.error);
//		}    
//	}    
}
