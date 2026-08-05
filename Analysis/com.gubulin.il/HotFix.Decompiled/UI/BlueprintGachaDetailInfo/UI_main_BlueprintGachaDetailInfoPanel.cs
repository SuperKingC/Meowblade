using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.BlueprintGachaDetailInfo;

public class UI_main_BlueprintGachaDetailInfoPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_com_BlueprintGachaDetailInfoDIalog com_BlueprintGachaDetailInfoDIalog;

	public UI_com_DetailInfoDIalogTips com_DetailInfoDIalogTips;

	public const string URL = "ui://ojhszwlpsxwp1";

	public static string Name = "UI_main_BlueprintGachaDetailInfoPanel";

	public static string GetURL()
	{
		return "ui://ojhszwlpsxwp1";
	}

	public static UI_main_BlueprintGachaDetailInfoPanel CreateInstance()
	{
		return (UI_main_BlueprintGachaDetailInfoPanel)(object)UIPackage.CreateObject("BlueprintGachaDetailInfo", "main_BlueprintGachaDetailInfoPanel");
	}

	public static UI_main_BlueprintGachaDetailInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BlueprintGachaDetailInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ojhszwlpsxwp1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		com_BlueprintGachaDetailInfoDIalog = (UI_com_BlueprintGachaDetailInfoDIalog)(object)((GComponent)this).GetChild("com_BlueprintGachaDetailInfoDIalog");
		com_DetailInfoDIalogTips = (UI_com_DetailInfoDIalogTips)(object)((GComponent)this).GetChild("com_DetailInfoDIalogTips");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)com_BlueprintGachaDetailInfoDIalog.close).onClick.Set(new EventCallback0(End));
		((GObject)com_DetailInfoDIalogTips.mask).onClick.Set(new EventCallback0(OnClickClosePage));
		UI_com_BlueprintGachaDetailInfoDIalog uI_com_BlueprintGachaDetailInfoDIalog = com_BlueprintGachaDetailInfoDIalog;
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.GeneralExclusive).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(0);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.suit).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(1);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.suitEffect).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(2);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.suitEffect2).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(2);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(3);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General2).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(3);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General3).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(3);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General4).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(3);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5General).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(4);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5General2).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(4);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star6General).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(5);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star1General).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(6);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5Exclusive).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(7);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5Exclusive2).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(7);
		});
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star6Exclusive).onClick.Set((EventCallback0)delegate
		{
			OnClickOpenPage(8);
		});
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)com_BlueprintGachaDetailInfoDIalog.close).onClick.Clear();
		UI_com_BlueprintGachaDetailInfoDIalog uI_com_BlueprintGachaDetailInfoDIalog = com_BlueprintGachaDetailInfoDIalog;
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.GeneralExclusive).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.suit).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.suitEffect).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.suitEffect2).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General2).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General3).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star4General4).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5General).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5General2).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star6General).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star1General).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5Exclusive).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star5Exclusive2).onClick.Clear();
		((GObject)uI_com_BlueprintGachaDetailInfoDIalog.star6Exclusive).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		OnClickClosePage();
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

	private void OnClickOpenPage(int index)
	{
		((GObject)com_DetailInfoDIalogTips).visible = true;
		com_DetailInfoDIalogTips.type.SetSelectedIndex(index);
	}

	private void OnClickClosePage()
	{
		((GObject)com_DetailInfoDIalogTips).visible = false;
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
