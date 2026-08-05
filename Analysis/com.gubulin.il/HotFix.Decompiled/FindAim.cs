using System.Collections.Generic;
using FairyGUI;
using UI.Guide;
using UnityEngine;

public class FindAim : MonoBehaviour
{
	private static FindAim _instance;

	public Dictionary<string, string> FindIndex = new Dictionary<string, string>();

	public static FindAim Instance => _instance;

	private void Awake()
	{
		_instance = this;
		FindIndexInit();
	}

	private void Start()
	{
		SharedMessenger.AddListener<string>("CLOSE_FGUI", Dispose);
	}

	private void Dispose(string str)
	{
		if (str == UI_Guide.Name)
		{
			SharedMessenger.RemoveListener<string>("CLOSE_FGUI", Dispose);
			Object.Destroy((Object)(object)this);
		}
	}

	private void FindIndexInit()
	{
		FindIndex.Add("LoginButton", "FUI_LoginAndName>loginButton");
	}

	public List<Vector2> Find_UGUI_Control(GameObject aim, Camera aimCamera)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		Vector2 sizeDelta = aim.GetComponent<RectTransform>().sizeDelta;
		Vector2 val = Vector2.op_Implicit(aimCamera.WorldToScreenPoint(((Transform)aim.GetComponent<RectTransform>()).position));
		Vector2 item = default(Vector2);
		((Vector2)(ref item))._002Ector(val.x, (float)Screen.height - val.y);
		List<Vector2> list = new List<Vector2>();
		list.Add(item);
		list.Add(sizeDelta);
		return list;
	}

	public List<Vector2> Find_FGUI_Control(GObject aim1)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		Vector2 item = aim1.LocalToGlobal(new Vector2(aim1.width / 2f, aim1.height / 2f));
		List<Vector2> list = new List<Vector2>();
		list.Add(item);
		list.Add(aim1.size);
		return list;
	}

	public List<Vector2> Find_Control(string address)
	{
		string text = address.Substring(1);
		string[] array = text.Split(new char[1] { '>' });
		if (address[0] == 'U')
		{
			GameObject aim = GameObject.Find(array[0]);
			Camera component = GameObject.Find(array[1]).GetComponent<Camera>();
			return Find_UGUI_Control(aim, component);
		}
		if (address[0] == 'F')
		{
			switch (array.Length)
			{
			case 3:
			{
				GObject child = (GObject)(object)((GComponent)GRoot.inst).GetChild(array[0]).asCom.GetChild(array[1]).asCom.GetChild(array[2]).asCom;
				return Find_FGUI_Control(child);
			}
			case 2:
			{
				GObject child = (GObject)(object)((GComponent)GRoot.inst).GetChild(array[0]).asCom.GetChild(array[1]).asCom;
				return Find_FGUI_Control(child);
			}
			case 4:
			{
				GObject child = ((GComponent)GRoot.inst).GetChild(array[0]).asCom.GetChild(array[1]).asCom.GetChild(array[2]).asCom.GetChild(array[3]);
				return Find_FGUI_Control(child);
			}
			}
		}
		return null;
	}
}
