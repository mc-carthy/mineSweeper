using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid {

	public static Minefield[,] minefields;

	public static void ShowAllMines () {
		foreach (Minefield mf in minefields) {
			mf.ShowMine();
		}
	}

	public static bool MineAtCoord (int x, int y) {
		if (x >= 0 && x < GameManager.Instance.Rows && y >= 0 && y < GameManager.Instance.Columns) {
			return minefields[x, y].IsMine;
		}
		return false;
	}

	public static int NearMines (int x, int y) {
		int count = 0;

		for (int i = x - 1; i < x + 2; i++) {
			for (int j = y - 1; j < y + 2; j++) {
				if (i != 0 && j != 0) {
					if (MineAtCoord(i, j)) {
						count++;
					}
				}
			}
		}

		// if (MineAtCoord(x - 1, y + 1)) {
		// 	count++;
		// }
		// if (MineAtCoord(x, y + 1)) {
		// 	count++;
		// }
		// if (MineAtCoord(x + 1, y + 1)) {
		// 	count++;
		// }
		// if (MineAtCoord(x - 1, y)) {
		// 	count++;
		// }
		// if (MineAtCoord(x + 1, y)) {
		// 	count++;
		// }
		// if (MineAtCoord(x - 1, y - 1)) {
		// 	count++;
		// }
		// if (MineAtCoord(x, y - 1)) {
		// 	count++;
		// }
		// if (MineAtCoord(x + 1, y - 1)) {
		// 	count++;
		// }

		return count;
	}

	public static void InvestigateMines (int x, int y, bool[,] visited) {

		if (x >= 0 && x < GameManager.Instance.Rows && y >= 0 && y < GameManager.Instance.Columns) {
			if (visited[x, y]) {
				return;
			}

			minefields[x, y].ShowMine();
			minefields[x, y].ShowNearMinesCount(NearMines(x, y));

			if (NearMines(x, y) > 0) {
				return;
			}

			visited[x, y] = true;

			// for (int i = x - 1; i < x + 2; i++) {
			// 	for (int j = y - 1; j < y + 2; j++) {
			// 		if (i != 0 && j != 0) {
			// 			if (MineAtCoord(i, j)) {
			// 				InvestigateMines(x, y, visited);
			// 			}
			// 		}
			// 	}
			// }

			InvestigateMines(x - 1, y - 1, visited);
			InvestigateMines(x - 1, y, visited);
			InvestigateMines(x - 1, y + 1, visited);
			InvestigateMines(x, y - 1, visited);
			InvestigateMines(x, y + 1, visited);
			InvestigateMines(x + 1, y - 1, visited);
			InvestigateMines(x + 1, y, visited);
			InvestigateMines(x + 1, y + 1, visited);
		}
	}

	public static bool IsGameFinished () {
		foreach (Minefield mf in minefields) {
			if (mf.IsClicked() && !mf.IsMine) {
				return false;
			}
		}
		return true;
	}

}
