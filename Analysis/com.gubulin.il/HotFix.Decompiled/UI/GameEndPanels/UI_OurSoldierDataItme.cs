using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_OurSoldierDataItme : GButton
{
	public Controller button;

	public Controller Status;

	public Controller MvpStatus;

	public GGraph n15;

	public UI_SoldierIcon Icon;

	public UI_DamageBar DamageBar;

	public GImage n11;

	public GTextField num;

	public GTextField percent;

	public UI_eff_Star_1 n14;

	public const string URL = "ui://hda5vzklrjqw3g";

	public static string Name = "UI_OurSoldierDataItme";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3g";
	}

	public static UI_OurSoldierDataItme CreateInstance()
	{
		return (UI_OurSoldierDataItme)(object)UIPackage.CreateObject("GameEndPanels", "OurSoldierDataItme");
	}

	public static UI_OurSoldierDataItme CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurSoldierDataItme).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		MvpStatus = ((GComponent)this).GetController("MvpStatus");
		n15 = (GGraph)((GComponent)this).GetChild("n15");
		Icon = (UI_SoldierIcon)(object)((GComponent)this).GetChild("Icon");
		DamageBar = (UI_DamageBar)(object)((GComponent)this).GetChild("DamageBar");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://hda5vzklrjqw3g".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		percent = (GTextField)((GComponent)this).GetChild("percent");
		n14 = (UI_eff_Star_1)(object)((GComponent)this).GetChild("n14");
	}
}
