using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public enum Level { Easy, Medium, Hard };
	private Level selectedLevel;
	public Level SelectedLevel {
		get {
			return selectedLevel;
		}
		set {
			selectedLevel = value;
		}
	}

	private int rows;
	public int Rows {
		get {
			return rows;
		}
		set {
			rows = value;
		}
	}
	private int columns;
	public int Columns {
		get {
			return columns;
		}
		set {
			columns = value;
		}
	}

	[SerializeField]
	private GameObject minefield;

	private float cameraX; 
	private float cameraY;

	private int easyLevelMines = 14;
	private int mediumLevelMinesCount = 20;
	private int hardLevelMinesCount = 30;
	private int minesCount;

	private void Awake () {
		MakeSingleton();
	}

	private void Start () {
		cameraX = 4f;
		cameraY = 7f;
		minesCount = 0;
		selectedLevel = Level.Medium;
		rows = 9;
		columns = 11;
	}

	private void OnEnable () {
		SceneManager.sceneLoaded += LevelFinishedLoading;
	}

	private void OnDisable () {
		SceneManager.sceneLoaded -= LevelFinishedLoading;
	}

	private void LevelFinishedLoading (Scene scene, LoadSceneMode mode) {
		if (scene.name == "main") {
			MatrixGrid.minefields = new Minefield[rows, columns];

			for (int x = 0; x < rows; x++) {
				for (int y = 0; y < columns; y++) {
					GameObject mine = Instantiate(minefield, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
					mine.name = x + "-" + y;
					MatrixGrid.minefields[x, y] = mine.GetComponent<Minefield>();
					mine.transform.SetParent(transform);
				}
			}
		} else {
			minesCount = 0;
		}
	}

	private void MakeSingleton () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}
