using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using LukeWaffel.AndroidGallery;

public class DemoScript : MonoBehaviour {

	[Header ("Refrences")]
	public Image frame;



	void Start () {
		
	}
	

	void Update () {
		
	}


	public void OpenGalleryButton(){


		AndroidGallery.Instance.OpenGallery (ImageLoaded);

	}


	public void ImageLoaded(){



		Debug.Log("The image has succesfully loaded!");
		frame.sprite = AndroidGallery.Instance.GetSprite();

	}


	public void Exit(){
		Application.Quit ();
	}
}
