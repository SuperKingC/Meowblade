using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_SpearAndShield : GComponent, IUiController
{
	public GGraph mask;

	public UI_SpearAndShieldDialog tip;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9jgn71k";

	public static string Name = "UI_SpearAndShield";

	private bool _type;

	private int _index;

	private float pos_x;

	private float pos_y;

	private readonly string[] attackTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText196"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText197"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText198"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText199")
	};

	private readonly string[] armorTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText605"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText606"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText607"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText203")
	};

	private List<string> textureList = new List<string>();

	public static string GetURL()
	{
		return "ui://47lbpgx9jgn71k";
	}

	public static UI_SpearAndShield CreateInstance()
	{
		return (UI_SpearAndShield)(object)UIPackage.CreateObject("Tips", "SpearAndShield");
	}

	public static UI_SpearAndShield CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SpearAndShield).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9jgn71k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		tip = (UI_SpearAndShieldDialog)(object)((GComponent)this).GetChild("tip");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters.ContainsKey("Pos"))
		{
			pos_x = ((Vector2)parameters["Pos"]).x;
			pos_y = ((Vector2)parameters["Pos"]).y;
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
			((GObject)this).sortingOrder = 1;
		}
		if (!parameters.ContainsKey("Type") || !parameters.ContainsKey("Index"))
		{
			End();
		}
		else
		{
			_type = (bool)parameters["Type"];
			_index = (int)parameters["Index"];
		}
		MainUiInit();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(End));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
		UI_SpearAndShieldDialog uI_SpearAndShieldDialog = tip;
		if (uI_SpearAndShieldDialog != null)
		{
			((GObject)uI_SpearAndShieldDialog).SetXY(pos_x, pos_y);
		}
	}

	private void MainUiInit()
	{
		if (_type)
		{
			tip.mainIcon.url = $"ui://PublicResources/icon_atk_{_index}";
			((GObject)tip.title).text = attackTypeNames[_index - 1] + LanguagesManager.GetDesc("CsharpCodeZhTcText608");
			tip.pageController.selectedIndex = _index - 1;
		}
		else
		{
			tip.mainIcon.url = $"ui://PublicResources/icon_def_{_index}";
			((GObject)tip.title).text = armorTypeNames[_index - 1] ?? "";
			tip.pageController.selectedIndex = _index + 3;
		}
		tip.SetControllerPageText();
		for (int i = 0; i < 6; i++)
		{
			GLoader asLoader = ((GComponent)tip).GetChild($"Icon{tip.pageController.selectedIndex}{i}").asLoader;
			if (((GObject)asLoader).data != null)
			{
				object data = ((GObject)asLoader).data;
				asLoader.url = "ui://PublicResources/" + (string)data;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			GTextField asTextField = ((GComponent)tip).GetChild($"Text{tip.pageController.selectedIndex}{j}").asTextField;
			((GObject)asTextField).text = ((((GObject)asTextField).data == null) ? string.Empty : LanguagesManager.GetDesc(((GObject)asTextField).data.ToString()));
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}
}
