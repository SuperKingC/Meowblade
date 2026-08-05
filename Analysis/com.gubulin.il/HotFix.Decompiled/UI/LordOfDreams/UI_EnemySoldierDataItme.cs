using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_EnemySoldierDataItme : GButton
{
	public Controller button;

	public Controller Status;

	public UI_SoldierIcon Icon;

	public UI_DamageBar DamageBar;

	public GImage n11;

	public GTextField num;

	public GTextField percent;

	public const string URL = "ui://0i520nzmt300o6l";

	public static string Name = "UI_EnemySoldierDataItme";

	public static string GetURL()
	{
		return "ui://0i520nzmt300o6l";
	}

	public static UI_EnemySoldierDataItme CreateInstance()
	{
		return (UI_EnemySoldierDataItme)(object)UIPackage.CreateObject("LordOfDreams", "EnemySoldierDataItme");
	}

	public static UI_EnemySoldierDataItme CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemySoldierDataItme).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmt300o6l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Icon = (UI_SoldierIcon)(object)((GComponent)this).GetChild("Icon");
		DamageBar = (UI_DamageBar)(object)((GComponent)this).GetChild("DamageBar");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://0i520nzmt300o6l".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		percent = (GTextField)((GComponent)this).GetChild("percent");
	}
}
