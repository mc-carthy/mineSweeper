using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	public void SelectLevel () {
		string level = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		switch (level) {
			case "easy":
				break;
			case "medium":
				break;
			case "hard":
				break;			
		}
	}

	public void GoToMenu () {
		SceneManager.LoadScene("menu", LoadSceneMode.Single);
	}
}
