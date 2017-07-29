using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UploadImageFinal : MonoBehaviour {

	public GameObject imageUpload;
	public GameObject FinalImageUpload;
	public Image PriImage;
	public Image FinalPriImg; 

	private Image im; 

	// Use this for initialization
	void Start () {
		im = PriImage.GetComponent<Image> ();
	}
	
	public void Next()
	{
		if (im.sprite == null) {
			Debug.Log ("Image is not uploaded...");
		}
		else
		{
			FinalPriImg.sprite = im.sprite;
		}
		FinalImageUpload.SetActive (true);
		imageUpload.SetActive (false);
	}
	public void Back()
	{
		FinalImageUpload.SetActive (false);
		imageUpload.SetActive (true);
	}
}
