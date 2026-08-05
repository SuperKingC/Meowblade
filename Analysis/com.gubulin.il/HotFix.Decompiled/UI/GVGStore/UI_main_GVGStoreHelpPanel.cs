using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Services;

namespace UI.GVGStore;

public class UI_main_GVGStoreHelpPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_HelpDialog Dialog;

	public GGraph Mask2;

	public UI_com_HelpTip2 DropDetail2;

	public UI_com_HelpTip1 DropDetail1;

	public Transition ShowDialog;

	public Transition ShowTip1;

	public Transition ShowTip2;

	public const string URL = "ui://fvc33k3gjsii5";

	public static string Name = "UI_main_GVGStoreHelpPanel";

	private GvGExpeditionHallModel Data;

	public static string GetURL()
	{
		return "ui://fvc33k3gjsii5";
	}

	public static UI_main_GVGStoreHelpPanel CreateInstance()
	{
		return (UI_main_GVGStoreHelpPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreHelpPanel");
	}

	public static UI_main_GVGStoreHelpPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreHelpPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gjsii5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_HelpDialog)(object)((GComponent)this).GetChild("Dialog");
		Mask2 = (GGraph)((GComponent)this).GetChild("Mask2");
		DropDetail2 = (UI_com_HelpTip2)(object)((GComponent)this).GetChild("DropDetail2");
		DropDetail1 = (UI_com_HelpTip1)(object)((GComponent)this).GetChild("DropDetail1");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
		ShowTip1 = ((GComponent)this).GetTransition("ShowTip1");
		ShowTip2 = ((GComponent)this).GetTransition("ShowTip2");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		HideAllTip();
		Data = new GvGExpeditionHallModel();
		Data.GetData(delegate
		{
			if (Data.IsSigned)
			{
				Data.SelectedIZIndex = Data.IZConfigs.IndexOf(Data.SignedInIZ);
			}
			if (Data.HasActiveGvGStoreDesc())
			{
				DropDetail1.RewardType.selectedIndex = 1;
				List<SpecialRewardItem> gvGStoreRewardsPreview = Data.GetGvGStoreRewardsPreview();
				for (int i = 0; i < gvGStoreRewardsPreview.Count; i++)
				{
					SpecialRewardItem specialRewardItem = gvGStoreRewardsPreview[i];
					UI_com_DropDetailItem uI_com_DropDetailItem = null;
					if (i < 3)
					{
						uI_com_DropDetailItem = DropDetail1.DynamicRewards1.AddItemFromPool() as UI_com_DropDetailItem;
					}
					else if (i < 6)
					{
						uI_com_DropDetailItem = DropDetail1.DynamicRewards2.AddItemFromPool() as UI_com_DropDetailItem;
					}
					else if (i < 9)
					{
						uI_com_DropDetailItem = DropDetail1.DynamicRewards3.AddItemFromPool() as UI_com_DropDetailItem;
					}
					if (uI_com_DropDetailItem != null)
					{
						((GObject)uI_com_DropDetailItem.itemName).text = specialRewardItem.NameText;
						((GObject)uI_com_DropDetailItem.itemRate).text = specialRewardItem.WeightText;
					}
				}
				((GObject)DropDetail1.CountDown).text = GetRemainingTimeStr(Data.GetGvGStoreRemainingSeconds());
			}
			else
			{
				DropDetail1.RewardType.selectedIndex = 0;
			}
		});
	}

	public void OnShow()
	{
	}

	private string GetRemainingTimeStr(int remainingSeconds)
	{
		if (remainingSeconds > 86400)
		{
			return string.Format("{0:F0} {1}", remainingSeconds / 86400, LanguagesManager.GetDesc("DateTime_Days"));
		}
		if (remainingSeconds > 3600)
		{
			return string.Format("{0:F0} {1}", remainingSeconds / 3600, LanguagesManager.GetDesc("DateTime_Hours"));
		}
		return string.Format("{0:F0} {1}", remainingSeconds / 60, LanguagesManager.GetDesc("DateTime_Minutes"));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)Dialog.Close).onClick.Add(new EventCallback0(End));
		((GObject)Mask2).onClick.Set((EventCallback0)delegate
		{
			HideAllTip();
		});
		((GObject)Dialog.n5).onClick.Set((EventCallback0)delegate
		{
			((GObject)Mask2).visible = true;
			((GObject)DropDetail1).visible = true;
			ShowTip1.Play();
		});
		((GObject)Dialog.n6).onClick.Set((EventCallback0)delegate
		{
			((GObject)Mask2).visible = true;
			((GObject)DropDetail2).visible = true;
			ShowTip2.Play();
		});
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.Close).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.n5).onClick.Clear();
		((GObject)Dialog.n6).onClick.Clear();
	}

	private void HideAllTip()
	{
		((GObject)DropDetail1).visible = false;
		((GObject)DropDetail2).visible = false;
		((GObject)Mask2).visible = false;
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
