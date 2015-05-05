using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	public const int ID_WINDOW_LEFT = 10;
	public const int ID_WINDOW_RIGHT = 20;
	public const int ID_WINDOW_BTN = 30;
	public const int ID_WINDOW_ORDER = 40;

	public static int currentPantsID = 1;

	public GUISkin myGuiSkin;
	private LeftMenu leftMenu;
	private RightMenu rightMenu;

	private bool showOrderWindow = false;

	private JeansController pantsController;
	private Renderer pantsRenderer;

	private ShortsController shortsController;
	private Renderer shortsRenderer;

	private GameObject jeansObj;
	private GameObject pantsObj;
	
	// Use this for initialization 
	void Start () {
		jeansObj = GameObject.Find ("jeans");
		pantsObj = GameObject.Find ("shorts");

		leftMenu = new LeftMenu ();
		rightMenu = new RightMenu ();

		pantsController = jeansObj.GetComponent<JeansController> ();
		pantsRenderer = jeansObj.GetComponent<Renderer> ();

		shortsController = pantsObj.GetComponent<ShortsController> ();
		shortsRenderer = pantsObj.GetComponent<Renderer> ();

		Debug.Log (pantsController.ToString());

	}
	
	// Update is called once per frame
	void Update () {
		if (pantsController != null && shortsController != null) {
			if(rightMenu.model == RightMenu.MODEL_LONG) {
				pantsObj.SetActive(false);
				jeansObj.SetActive(true);

				pantsRenderer.material = pantsController.materials[rightMenu.color + rightMenu.bag];
			}
			else if(rightMenu.model == RightMenu.MODEL_SHORT){
				jeansObj.SetActive(false);
				pantsObj.SetActive(true);

				shortsRenderer.material = shortsController.materials[rightMenu.color + rightMenu.bag];
			}

		}

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();		
		}
	}

	void OnGUI() {
		GUI.skin = myGuiSkin;
		GUI.Window (ID_WINDOW_LEFT, leftMenu.getRect(), leftMenu.init,  "");

		switch (leftMenu.rightMenuType) {
		case LeftMenu.TYPE_MODEL:
			GUI.Window(ID_WINDOW_RIGHT, rightMenu.getRect(leftMenu.rightMenuType), rightMenu.initModel, "");
			break;
		case LeftMenu.TYPE_COLOR:
			GUI.Window(ID_WINDOW_RIGHT, rightMenu.getRect(leftMenu.rightMenuType), rightMenu.initColor, "");
			break;
		case LeftMenu.TYPE_DETAIL:
			GUI.Window(ID_WINDOW_RIGHT, rightMenu.getRect(leftMenu.rightMenuType), rightMenu.initDetail, "");
			break;
		
		}


		if (showOrderWindow) {
			int w = 400, h = 300;
			int x = (Screen.width-w)/2;
			int y = (Screen.height-h)/2;

			GUI.Window(ID_WINDOW_ORDER, new Rect(x,y,w,h), initOrderWindow, "", "STYLE_WINDOW_ORDER");
		}
		else if(leftMenu.rightMenuType == 0){
			int x = Screen.width - 10 - 125;
			GUI.Window (ID_WINDOW_BTN, new Rect(x, 10, 125, 40), addButton, "", "STYLE_WINDOW");
		}

	}

	void addButton(int id) {
		if (GUILayout.Button ("立即购买", "button"))
			showOrderWindow = true;
	}

	void initOrderWindow(int id) {
		GUILayout.BeginVertical ();
		showFirstLine ();

		GUILayout.BeginHorizontal ();
		GUILayout.Space (10);
		showInfoArea ();
		showSizeArea ();
		GUILayout.Space (10);
		GUILayout.EndHorizontal ();
		
		GUILayout.EndVertical ();
	}

	public Texture icon;
	public Texture close;
	void showFirstLine() {
		GUILayout.BeginHorizontal ();
		GUILayout.Space (10);

		GUIContent content = new GUIContent ();
		content.text = "确认订单";
		content.image = icon;
		GUILayout.Label (content);

		if (GUILayout.Button ("", "STYLE_BTN_CLOSE")) {
			showOrderWindow = false;
		}
		GUILayout.EndHorizontal ();
	}

	void showInfoArea() {
		GUILayout.BeginVertical ();
		GUILayout.Space (10);
		showInfoItem ("品名","男款牛仔裤");
		GUILayout.Space (10);
		showInfoItem ("价格","269元");
		GUILayout.Space (10);
		showInfoItem ("型号","YZ-8226");
		GUILayout.Space (10);
		showInfoItem ("颜色","蓝");
		GUILayout.Space (10);
		showInfoItem ("口袋","方袋1");
		GUILayout.Space (10);
		GUILayout.EndVertical ();
	}

	void showInfoItem(string key, string value) {
		GUILayout.BeginHorizontal ();

		GUILayout.Box (key, GUILayout.Width (60));
		GUILayout.Space (3);
		GUILayout.Box (value, GUILayout.Width (117));
		GUILayout.Space (10);
		GUILayout.EndHorizontal ();
	}

	private int stateFlag = 0x0000;
	void showSizeArea() {

		GUILayout.BeginVertical ();
		GUILayout.Space (10);
		GUILayout.Box ("选择尺码");
		GUILayout.Space (10);

		GUILayout.BeginHorizontal ();
		showToggle (0x0001, "32码");
		showToggle (0x0002, "33码");
		GUILayout.EndHorizontal ();
		GUILayout.Space (5);

		GUILayout.BeginHorizontal ();
		showToggle (0x0004, "34码");
		showToggle (0x0008, "35码");
		GUILayout.EndHorizontal ();
		GUILayout.Space (5);

		GUILayout.BeginHorizontal ();
		showToggle (0x0010, "36码");
		showToggle (0x0020, "37码");
		GUILayout.EndHorizontal ();
		GUILayout.Space (5);

		GUILayout.BeginHorizontal ();
		showToggle (0x0040, "38码");
		showToggle (0x0080, "39码");
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		showToggle (0x0100, "40码");
		showToggle (0x0200, "41码");
		GUILayout.EndHorizontal ();
		GUILayout.Space (5);

		GUILayout.BeginHorizontal ();
		showToggle (0x0400, "42码");
		showToggle (0x0800, "43码");
		GUILayout.EndHorizontal ();

		GUILayout.Space (10);
		if (GUILayout.Button ("立即支付")) {
			showOrderWindow = false;
		}
		GUILayout.EndVertical ();
	}

	void showToggle(int flag, string text) {
		if(GUILayout.Toggle ((stateFlag & flag) > 0, text))
			stateFlag = flag;
	}

}
