using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public AudioSource SE;
	public AudioClip SE_OK;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		} else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			onButton_Opening();
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			onButton_MavicPro();
		}
	}

	public void onButton_Opening() {
		SE.PlayOneShot(SE_OK);
		StartCoroutine(Checking(()=>{
			SceneManager.LoadScene("Main_Opening4K");
		}));
	}

	public void onButton_MavicPro() {
		SE.PlayOneShot(SE_OK);
		StartCoroutine(Checking(()=>{
			SceneManager.LoadScene("Main_MavicPro");
		}));
	}

	public void onButton_Quit() {
		Application.Quit();
	}

	public delegate void FunctionType();
	private IEnumerator Checking(FunctionType callback){
		while(true) {
			yield return new WaitForFixedUpdate ();
			if (!SE.isPlaying) {
				callback();
				break;
			}
		}
	}
}
