using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecords;

public class UI_ArrayIndex : GButton
{
	public Controller button;

	public Controller btnadd;

	public GImage n4;

	public GImage n5;

	public GTextField indexText;

	public GImage LockIcon;

	public const string URL = "ui://dxmilktydzlsm";

	public static string Name = "UI_ArrayIndex";

	public static string GetURL()
	{
		return "ui://dxmilktydzlsm";
	}

	public static UI_ArrayIndex CreateInstance()
	{
		return (UI_ArrayIndex)(object)UIPackage.CreateObject("GvGBattleRecords", "ArrayIndex");
	}

	public static UI_ArrayIndex CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ArrayIndex).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzlsm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		btnadd = ((GComponent)this).GetController("btnadd");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		indexText = (GTextField)((GComponent)this).GetChild("indexText");
		string id = "ui://dxmilktydzlsm".Replace("ui://", "") + "-" + ((GObject)indexText).id;
		((GObject)indexText).text = LanguagesManager.GetDesc(id);
		LockIcon = (GImage)((GComponent)this).GetChild("LockIcon");
	}
}
