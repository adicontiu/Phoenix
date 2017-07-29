using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukeWaffel.AndroidGallery{

	public class AndroidGallery : Singleton<AndroidGallery>{

		public delegate void OnImageLoadedCallback();
		private OnImageLoadedCallback callback;

		private Sprite loadedSprite;
		private Texture loadedTexture;

		private WWW imageWWW;

		void Start () {

			gameObject.name = "AndroidGallery";

		}
		

		void Update () {


			if (imageWWW != null && imageWWW.isDone)
				
				OnImageLoaded ();
		}


		public void OpenGallery(OnImageLoadedCallback Callback){


			if(Application.platform == RuntimePlatform.Android){


				callback = Callback;


				AndroidJavaClass javaClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
				AndroidJavaObject javaObject = new AndroidJavaObject ("com.lukewaffel.androidgallery.UnityBinder");


				javaObject.CallStatic ("OpenGallery", javaClass.GetStatic<AndroidJavaObject> ("currentActivity"));
			

			}else{
				
				Debug.LogError ("AndroidGallery can only be used in Android. Because of the dependancy of the Android OS it can NOT be tested in the editor.");
			}


		}


		public void ResetOutput(){


			loadedTexture = null;
			loadedSprite = null;

		}


		public Texture GetTexture(){


			return loadedTexture;

		}

	
		public Sprite GetSprite(){


			return loadedSprite;

		}


		public void OnImageLoaded(){


			loadedTexture = imageWWW.texture;


			loadedSprite = Sprite.Create (imageWWW.texture, new Rect (0, 0, imageWWW.texture.width, imageWWW.texture.height), new Vector2 (0, 0));


			imageWWW = null;


			callback ();
			callback = null;

		}


		public void OnImageSelect(string path){


			imageWWW = new WWW ("file://" + path);
			
		}

	}
}
