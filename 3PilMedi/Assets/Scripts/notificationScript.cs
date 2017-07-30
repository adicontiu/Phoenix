using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notificationScript : MonoBehaviour {

	public Text addd;
	public Text pinn;
	public Text medii;
	public Text mobilee;
	public Text namee;
	public Button notifi;
	public GameObject menuPanel;
	public GameObject NotificationPanel;

	private string id = "";

	//string url = "localhost/Andrid/medicineupload.php";
	string url1="localhost/Andrid/medicineseller.php";
	WWWForm form;
	WWW www;
	// Use this for initialization
	void Start () {
		form = new WWWForm ();
		WWW www = new WWW (url1, form);
	}
	
	// Update is called once per frame
	void Update () {
		
    	
		StartCoroutine (WaitForRequest1 (www));

	}

	public void noti()
	{
		menuPanel.SetActive (false);
		NotificationPanel.SetActive (true); 
		notifi.image.color = Color.black;
	}

	public void Back()
	{
		NotificationPanel.SetActive (false);
		menuPanel.SetActive (true);
	}

	IEnumerator WaitForRequest1(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
//			if (www.data == "1") 
//			{
//				Debug.Log ("Order Placed");
//			}
//			else {
//
//				Debug.Log (www.data);
//				//conso.text = "Error Occured";
//			}
			//Debug.Log("WWW Ok!: " + www.data);
			//			if (www.data == "1") 
			//			{
			//				Application.LoadLevel (1);
			//			}
			//			else {
			//				conso.text = "Faild to signIn";
			//				t = 0f;
			//				Debug.Log ("Faild to signIn");
			//			}
//			if (www.data != null) 
//			{
				string Da = www.data;
				//string[] Da1 = Da.Split ("/");

				string[] Da1 = Da.Split ('/');
				if (id != Da1 [0]) 
				{
					id = Da1 [0];
							addd.text = Da1 [4];
							pinn.text = Da1 [3];
							medii.text = Da1 [5];
							mobilee.text = Da1 [2];
							namee.text = Da1 [1];
							notifi.image.color = Color.red;
				}
				
			//}
		}
		else
		{


			Debug.Log("WWW Error: "+ www.error);
		}    
	}    
}
