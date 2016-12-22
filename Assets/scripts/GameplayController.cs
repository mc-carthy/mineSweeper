using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	public void RestartGame () {
		SceneManager.LoadScene("main", LoadSceneMode.Single);
	}

	public void BackToMenu () {
		SceneManager.LoadScene("menu", LoadSceneMode.Single);
	}
}
