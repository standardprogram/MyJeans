using UnityEngine;
using System.Collections;

public class RightMenu {
	private Rect menuRect2 = new Rect(Screen.width - 10- 145, 10, 125, 320);
	private Rect menuRect3 = new Rect(Screen.width - 10- 145, 10, 125, 450);

	public const int MODEL_LONG = 1;
	public const int MODEL_SHORT = 2;

	public const int COLOR_BLUE = 0;
	public const int COLOR_GREEN = 1;
	public const int COLOR_BLACK = 2;

	public const int BAG_1 = 0;
	public const int BAG_2 = 3;

	public int model = 1;
	public int color = 0;
	public int bag = 0;

	public RightMenu() {
		Debug.Log ("RightMenu Created");
	}
	
	public void initModel(int winId) {
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("长裤", "STYLE_BTN_LONG")) {
			model = MODEL_LONG;
		}
		GUILayout.Space (45);
		if (GUILayout.Button ("短裤", "STYLE_BTN_SHORT")) {
			model = MODEL_SHORT;		
		}
		GUILayout.Space (45);

		GUILayout.EndVertical ();
	}

	public void initColor(int winId) {
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("蓝色", "STYLE_BTN_BLUE")) {
			color = COLOR_BLUE;
		}
		GUILayout.Space (45);

		if (GUILayout.Button ("绿色", "STYLE_BTN_GREEN")) {
			color = COLOR_GREEN;
		}
		GUILayout.Space (45);

		if (GUILayout.Button ("黑色", "STYLE_BTN_BLACK")) {
			color = COLOR_BLACK;		
		}

		GUILayout.EndVertical ();
	}

	public void initDetail(int winId) {
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("尖袋", "STYLE_BTN_BAG1")) {
			bag = BAG_1;
		}
		GUILayout.Space (45);

		if (GUILayout.Button ("方袋", "STYLE_BTN_BAG2")) {
			bag = BAG_2;	
		}
		GUILayout.Space (45);
		
		GUILayout.EndVertical ();
	}

	public Rect getRect(int type) {
		switch (type) {
		case LeftMenu.TYPE_MODEL:
		case LeftMenu.TYPE_DETAIL:
			return menuRect2;
		case LeftMenu.TYPE_COLOR:
			return menuRect3;
		}
		return menuRect3;
	}
}
