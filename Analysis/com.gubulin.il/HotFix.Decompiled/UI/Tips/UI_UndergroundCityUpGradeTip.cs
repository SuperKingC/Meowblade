using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.Tips;

public class UI_UndergroundCityUpGradeTip : GComponent, IUiController
{
	public GTextField title;

	public GTextField tip;

	public GTextField titleNum;

	public GTextField tipNum;

	public GGroup mainGroup;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9v7wqy";

	public static string Name = "UI_UndergroundCityUpGradeTip";

	private int level;

	private string desc;

	public static string GetURL()
	{
		return "ui://47lbpgx9v7wqy";
	}

	public static UI_UndergroundCityUpGradeTip CreateInstance()
	{
		return (UI_UndergroundCityUpGradeTip)(object)UIPackage.CreateObject("Tips", "UndergroundCityUpGradeTip");
	}

	public static UI_UndergroundCityUpGradeTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UndergroundCityUpGradeTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9v7wqy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9v7wqy".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://47lbpgx9v7wqy".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		titleNum = (GTextField)((GComponent)this).GetChild("titleNum");
		string id3 = "ui://47lbpgx9v7wqy".Replace("ui://", "") + "-" + ((GObject)titleNum).id;
		((GObject)titleNum).text = LanguagesManager.GetDesc(id3);
		tipNum = (GTextField)((GComponent)this).GetChild("tipNum");
		string id4 = "ui://47lbpgx9v7wqy".Replace("ui://", "") + "-" + ((GObject)tipNum).id;
		((GObject)tipNum).text = LanguagesManager.GetDesc(id4);
		mainGroup = (GGroup)((GComponent)this).GetChild("mainGroup");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GObject)this).SetXY(0f, 0f);
		((GObject)this).sortingOrder = 102;
		level = (int)parameters["NextLevel"];
		((GObject)titleNum).text = level.ToString();
		Dictionary<int, UserExpData> userExpData = GameManagers.Instance.ConfigDataManager.UserExpData;
		for (int i = 0; i < userExpData[level].DescList.Count; i++)
		{
			if (i < userExpData[level].DescList.Count - 1)
			{
				desc = desc + userExpData[level].DescList[i] + Environment.NewLine;
			}
			else
			{
				desc += userExpData[level].DescList[i];
			}
		}
		((GObject)tip).text = desc;
		showTip.Play((PlayCompleteCallback)delegate
		{
			End();
		});
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
