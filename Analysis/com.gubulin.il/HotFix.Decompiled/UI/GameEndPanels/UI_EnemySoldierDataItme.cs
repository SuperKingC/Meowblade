using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_EnemySoldierDataItme : GButton
{
	public Controller button;

	public Controller Status;

	public Controller MvpStatus;

	public GGraph n16;

	public UI_SoldierIcon Icon;

	public UI_DamageBar DamageBar;

	public GImage n11;

	public GTextField num;

	public GTextField percent;

	public UI_eff_Star_1 n15;

	public const string URL = "ui://hda5vzklrjqw3m";

	public static string Name = "UI_EnemySoldierDataItme";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3m";
	}

	public static UI_EnemySoldierDataItme CreateInstance()
	{
		return (UI_EnemySoldierDataItme)(object)UIPackage.CreateObject("GameEndPanels", "EnemySoldierDataItme");
	}

	public static UI_EnemySoldierDataItme CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemySoldierDataItme).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n16 = (GGraph)((GComponent)this).GetChild("n16");
		Icon = (UI_SoldierIcon)(object)((GComponent)this).GetChild("Icon");
		DamageBar = (UI_DamageBar)(object)((GComponent)this).GetChild("DamageBar");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://hda5vzklrjqw3m".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		percent = (GTextField)((GComponent)this).GetChild("percent");
		n15 = (UI_eff_Star_1)(object)((GComponent)this).GetChild("n15");
	}
}
