using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	public void RestartGame () {
		if (GameManager.Instance != null) {
			GameManager.Instance.MinesCount = 0;
		}

		SceneManager.LoadScene("main", LoadSceneMode.Single);
	}

	public void BackToMenu () {
		SceneManager.LoadScene("menu", LoadSceneMode.Single);
	}
}
