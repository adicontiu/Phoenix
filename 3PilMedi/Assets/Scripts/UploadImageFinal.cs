using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UploadImageFinal : MonoBehaviour {

	public GameObject imageUpload;
	public GameObject FinalImageUpload;
	public InputField fullName;
	public InputField Add;
	public InputField pin;
	public InputField medi;
	public InputField mobile;
	public GameObject menuPanel;
	public Text t9;

	public Text addd;
	public Text pinn;
	public Text medii;
	public Text mobilee;
	public Text namee;

	string url = "localhost/Andrid/medicineupload.php";
	WWWForm form;
		
	// Use this for initialization
	void Start () {
		
	}
	
	public void Next()
	{
		string fn = fullName.text.ToString ();
		string m = mobile.text.ToString ();
		string ad = Add.text.ToString ();
		string pi = pin.text.ToString ();
		string med = medi.text.ToString ();
		addd.text = ad;
		pinn.text = pi;
		medii.text = med;
		mobilee.text = m;
		namee.text = fn;
		FinalImageUpload.SetActive (true);
		imageUpload.SetActive (false);
		menuPanel.SetActive (false);
	}
	public void Back()
	{
		FinalImageUpload.SetActive (false);
		imageUpload.SetActive (true);
		menuPanel.SetActive (false);
	}
	public void BackToMenu()
	{
		menuPanel.SetActive (true);
		FinalImageUpload.SetActive (false);
		imageUpload.SetActive (false);
	}
	public void UploadPriscription()
	{
		menuPanel.SetActive (false);
		FinalImageUpload.SetActive (false);
		imageUpload.SetActive (true);
	}
	void menu12()
	{
		menuPanel.SetActive (true);
		imageUpload.SetActive (false);
		t9.text = "Order Placed!!!";
	}
	public void final_Upload()
	{
		string fn = fullName.text.ToString ();
		string m = mobile.text.ToString ();
		string ad = Add.text.ToString ();
		string pi = pin.text.ToString ();
		string med = medi.text.ToString ();
//		byte[] b = im.sprite.texture.EncodeToJPG ();
		form = new WWWForm ();
		form.AddField ("fullName", fn);
		form.AddField ("add", ad);
		form.AddField ("mobile", m);
		form.AddField ("pin", pi);
		form.AddField ("medi", med);
		WWW www = new WWW (url, form);
		StartCoroutine (WaitForRequest1 (www));
	}

	IEnumerator WaitForRequest1(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
			if (www.data == "1") 
			{
				Debug.Log ("Order Placed");
				menu12 ();
			}
			else {

				Debug.Log (www.data);
				//conso.text = "Error Occured";
			}
//			if (www.data == "1") 
//			{
//				Application.LoadLevel (1);
//			}
//			else {
//				conso.text = "Faild to signIn";
//				t = 0f;
//				Debug.Log ("Faild to signIn");
//			}
		}
		else
		{
			

			Debug.Log("WWW Error: "+ www.error);
		}    
	}    
}


//var screenShotURL= "http://localhost:8888/upload_file.php";
//function Start(){ 
//	//print(Application.srcPath); 
//}
//function OnMouseDown() { 
//	// We should only read the screen after all rendering is complete yield WaitForEndOfFrame();
//	// Create a texture the size of the screen, RGB24 format
//	var width = Screen.width;
//	var height = Screen.height;
//	var tex = new Texture2D( width, height, TextureFormat.RGB24, false );
//	// Read screen contents into the texture
//	tex.ReadPixels( Rect(0, 0, width, height), 0, 0 );
//	tex.Apply();
//	// Encode texture into PNG
//	var bytes = tex.EncodeToPNG();
//	Destroy( tex );
//	// Create a Web Form
//	var form = new WWWForm();
//	form.AddField("frameCount", Time.frameCount.ToString());
//	form.AddBinaryData("file", bytes, "screenShot.png", "image/png");
//	// Upload to a cgi script    
//	var w = WWW(screenShotURL, form);
//	yield w;
//	if (w.error != null){
//		print(w.error);
//		Application.ExternalCall( "debug", w.error);
//		//print(screenShotURL);
//	}  
//	else{
//		print("Finished Uploading Screenshot");
//		//print(screenShotURL);
//		Application.ExternalCall( "debug", "Finished Uploading Screenshot");
//	}
//}