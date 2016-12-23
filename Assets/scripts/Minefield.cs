using UnityEngine;

public class Minefield : MonoBehaviour {

	private bool isMine;
	public bool IsMine {
		get {
			return isMine;
		}
	}

	[SerializeField]
	private Sprite[] images;
	[SerializeField]
	private Sprite mineImage;

	private SpriteRenderer sprRen;

	private void Awake () {
		sprRen = GetComponent<SpriteRenderer>();
	}

	private void Start () {
		isMine = Random.value < 0.15f;

		if (isMine) {
			if (GameManager.Instance.CanBeMine()) {
				GameManager.Instance.IncrementMinesInGame();
			} else {
				isMine = false;
			}
		}
	}

	private void OnMouseDown () {
		if (isMine) {
			MatrixGrid.ShowAllMines();
		} else {
			string[] index = gameObject.name.Split('-');
			int x = int.Parse(index[0]);
			int y = int.Parse(index[1]);

			ShowNearMinesCount(MatrixGrid.NearMines(x, y));

			MatrixGrid.InvestigateMines(x, y, new bool[GameManager.Instance.Rows, GameManager.Instance.Columns]);

			if (MatrixGrid.IsGameFinished()) {
				Debug.Log("You won");
			}
		}
	}

	public void ShowMine () {
		if (isMine) {
			sprRen.sprite = mineImage;
		}
	}

	public void ShowNearMinesCount (int nearMines) {
		sprRen.sprite = images[nearMines];
	}

	public bool IsClicked () {
		return sprRen.sprite.texture.name == "Hidden Element";
	}
}
