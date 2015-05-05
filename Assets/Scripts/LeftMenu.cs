using UnityEngine;
using System.Collections;

public class LeftMenu{

	private Rect menuRect = new Rect(10, 10, 125, 450);
	public int rightMenuType = 0;

	public const int TYPE_MODEL = 1;
	public const int TYPE_COLOR = 2;
	public const int TYPE_DETAIL = 3;

	public LeftMenu() {
		Debug.Log ("LeftMenu init");
	}

	public void init(int winId) {
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("款式", "STYLE_BTN_MODEL")) {
			showRightMenu(TYPE_MODEL);
		}
		GUILayout.Space (45);

		if (GUILayout.Button ("颜色", "STYLE_BTN_COLOR")) {
			showRightMenu(TYPE_COLOR);
		}
		GUILayout.Space (45);

		if(GUILayout.Button ("口袋", "STYLE_BTN_DETAIL")) {
			showRightMenu(TYPE_DETAIL);
		}

		GUILayout.EndVertical ();
	}

	private void showRightMenu(int type) {
		rightMenuType = (rightMenuType == type)? 0 :type;
	}

	public Rect getRect() {
		return menuRect;
	}
		 

}
