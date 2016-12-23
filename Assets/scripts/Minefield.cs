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
