using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace UI.PublicResources;

public class UI_JumpTip : GComponent
{
	private class JumpData
	{
		public string Desc;

		public string JumpPanel;
	}

	private class JumpModel
	{
		public string Title;

		public List<JumpData> JumpList;
	}

	public GImage n0;

	public GTextField n1;

	public GList JumpList;

	public const string URL = "ui://kt6rg65oh8w9v4oa";

	public static string Name = "UI_JumpTip";

	public static string GetURL()
	{
		return "ui://kt6rg65oh8w9v4oa";
	}

	public static UI_JumpTip CreateInstance()
	{
		return (UI_JumpTip)(object)UIPackage.CreateObject("PublicResources", "JumpTip");
	}

	public static UI_JumpTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_JumpTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oh8w9v4oa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		JumpList = (GList)((GComponent)this).GetChild("JumpList");
	}

	public void Render(string jumpListKey)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		string desc = LanguagesManager.GetDesc("JumpTipList_" + jumpListKey);
		JumpModel jumpModel = JsonHelper.ToObject<JumpModel>(desc);
		((GObject)n1).text = jumpModel.Title;
		foreach (JumpData jumpData in jumpModel.JumpList)
		{
			if (!(JumpList.AddItemFromPool().asCom is UI_btn_JumpTipData uI_btn_JumpTipData))
			{
				continue;
			}
			if (string.IsNullOrEmpty(jumpData.JumpPanel))
			{
				uI_btn_JumpTipData.GotoBtnDisplaying.selectedIndex = 0;
			}
			else
			{
				uI_btn_JumpTipData.GotoBtnDisplaying.selectedIndex = 1;
				((GObject)((GObject)uI_btn_JumpTipData.n7).asButton).onClick.Add((EventCallback0)delegate
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(jumpData.JumpPanel, null);
					End();
				});
			}
			((GObject)uI_btn_JumpTipData.Source).text = jumpData.Desc;
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
