using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace UI.Tips;

public class UI_SkillEffectPanel : GComponent, IUiController
{
	private class SkillEffect
	{
		public string EffectName { get; set; }

		public string EffectNameDesc { get; set; }

		public string EffectLimit { get; set; }

		public string EffectLimitDesc { get; set; }

		public string Desc { get; set; }
	}

	public GGraph mask;

	public UI_SkillEffectDialog skillDialog;

	public Transition showDialog;

	public const string URL = "ui://47lbpgx9p37ntan";

	public static string Name = "UI_SkillEffectPanel";

	private string EffectKey;

	public static string GetURL()
	{
		return "ui://47lbpgx9p37ntan";
	}

	public static UI_SkillEffectPanel CreateInstance()
	{
		return (UI_SkillEffectPanel)(object)UIPackage.CreateObject("Tips", "SkillEffectPanel");
	}

	public static UI_SkillEffectPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillEffectPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9p37ntan", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		skillDialog = (UI_SkillEffectDialog)(object)((GComponent)this).GetChild("skillDialog");
		showDialog = ((GComponent)this).GetTransition("showDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)this).sortingOrder = ((!parameters.TryGetValue("SortingOrder", out var value)) ? 1 : ((int)value));
		if (parameters.TryGetValue("EffectKey", out var value2))
		{
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			EffectKey = value2.ToString();
			ShowData();
		}
		else
		{
			End();
		}
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

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void ShowData()
	{
		try
		{
			GDELanguagesData gDELanguagesData = GDMgr.Get<GDELanguagesData>(EffectKey);
			SkillEffect skillEffect = JsonHelper.ToObject<SkillEffect>(gDELanguagesData.Template);
			((GObject)skillDialog.EffectName).text = skillEffect.EffectName;
			((GObject)skillDialog.EffectNameDesc).text = skillEffect.EffectNameDesc;
			((GObject)skillDialog.EffectLimit).text = skillEffect.EffectLimit;
			((GObject)skillDialog.EffectLimitDesc).text = skillEffect.EffectLimitDesc;
			((GObject)skillDialog.Desc).text = skillEffect.Desc;
			showDialog.Play();
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError(ex.Message);
		}
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}
}
