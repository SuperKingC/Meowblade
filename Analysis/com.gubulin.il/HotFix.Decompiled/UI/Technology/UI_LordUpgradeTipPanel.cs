using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Technology;

public class UI_LordUpgradeTipPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_LordUpgradeTipDialog Dialog;

	public Transition ShowPopup;

	public const string URL = "ui://7ca77a3fcg2k3h";

	public static string Name = "UI_LordUpgradeTipPanel";

	public const string ShowParamLevel = "Level";

	private int _mainTechLevel;

	private List<string> textureList = new List<string>();

	private string mainTech;

	public static string GetURL()
	{
		return "ui://7ca77a3fcg2k3h";
	}

	public static UI_LordUpgradeTipPanel CreateInstance()
	{
		return (UI_LordUpgradeTipPanel)(object)UIPackage.CreateObject("Technology", "LordUpgradeTipPanel");
	}

	public static UI_LordUpgradeTipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LordUpgradeTipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fcg2k3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_LordUpgradeTipDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowPopup = ((GComponent)this).GetTransition("ShowPopup");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("MainTechId", out var value))
		{
			mainTech = (string)value;
		}
		else
		{
			End();
		}
		int num = (_mainTechLevel = (int)parameters["Level"]);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		RenderMainUi();
		int maxLevel = TechnologyData.GetMaxLevel();
		bool flag = num >= maxLevel;
		if (num > 1)
		{
			((GObject)Dialog.tip1).text = LanguagesManager.GetDesc("CsharpCodeZhTcText962");
			if (flag)
			{
				((GObject)Dialog.tip3).text = LanguagesManager.GetDesc("CsharpCodeZhTcText963");
			}
		}
	}

	public void OnShow()
	{
		ShowPopup.Play();
		Dialog.SetButtonTitle();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBtn).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void RenderMainUi()
	{
		Dialog.icon.url = "ui://Technology/techIcon_" + mainTech;
		Dialog.title.url = "ui://Technology/techTitle_" + mainTech;
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(mainTech);
		List<Modifier> techEffects = GameManagers.Instance.TechnologyManager.GetTechEffects(mainTech, _mainTechLevel);
		string text = "";
		if (techEffects != null)
		{
			foreach (Modifier item in techEffects)
			{
				text = text + item.Desc + " ";
			}
		}
		else
		{
			text += gDETechnologyData.GainDescrible;
		}
		if (text.Contains(LanguagesManager.GetDesc("CsharpCodeZhTcText568") + "："))
		{
			text = text.Substring(6);
		}
		((GObject)Dialog.tip2).text = text;
		((GObject)Dialog.tip3).text = LanguagesManager.GetDesc("CsharpCodeZhTcText567");
	}
}
