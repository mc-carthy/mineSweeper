using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	public void SelectLevel () {
		string level = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		switch (level) {
			case "easy":
				if (GameManager.Instance != null) {
					GameManager.Instance.Rows = 8;
					GameManager.Instance.Columns = 9;
					GameManager.Instance.SelectedLevel = GameManager.Level.Easy;
				}
				break;
			case "medium":
				if (GameManager.Instance != null) {
					GameManager.Instance.Rows = 9;
					GameManager.Instance.Columns = 11;
					GameManager.Instance.SelectedLevel = GameManager.Level.Medium;
				}
				break;
			case "hard":
				if (GameManager.Instance != null) {
					GameManager.Instance.Rows = 10;
					GameManager.Instance.Columns = 13;
					GameManager.Instance.SelectedLevel = GameManager.Level.Hard;
				}
				break;			
		}
	}

	public void GoToMenu () {
		SceneManager.LoadScene("menu", LoadSceneMode.Single);
	}
}
