using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CameraController : MonoBehaviour {

	public Camera MainCamera;
	public VideoPlayer Player;

	private Vector3 lastMousePosition;
	private Vector3 newAngle = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Video Player
		if ((ulong)Player.frame == Player.frameCount) {
			SceneManager.LoadScene("Menu");
		}

		// Mouse
		if (Input.GetMouseButtonDown(0)) {
			newAngle = MainCamera.transform.localEulerAngles;
			lastMousePosition = Input.mousePosition;
		} else if (Input.GetMouseButton(0)) {
			newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
			newAngle.y += (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
			MainCamera.gameObject.transform.localEulerAngles = newAngle;
			lastMousePosition = Input.mousePosition;
		}

		// Keyboard
		if (Input.anyKey) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (Player.isPlaying) {
					Player.Pause();
				} else {
					Player.Play();
				}
			} else if (Input.GetKeyDown(KeyCode.Escape)) {
				SceneManager.LoadScene("Menu");
			}

			newAngle = MainCamera.transform.localEulerAngles;
			if (Input.GetKey(KeyCode.UpArrow)) {
				newAngle.x -= 5;
			} else if (Input.GetKey(KeyCode.DownArrow)) {
				newAngle.x += 5;
			} else if (Input.GetKey(KeyCode.LeftArrow)) {
				newAngle.y -= 10;
			} else if (Input.GetKey(KeyCode.RightArrow)) {
				newAngle.y += 10;
			}
			MainCamera.gameObject.transform.localEulerAngles = newAngle;
		}
	}
}
