using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Entry2 : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n8;

	public GRichTextField NewEntry;

	public GRichTextField NewEntryUnlockLevel;

	public GRichTextField OldEntryTitle;

	public GRichTextField OldEntry;

	public GImage n7;

	public const string URL = "ui://h09dvkcglxbt42";

	public static string Name = "UI_com_Entry2";

	public static string GetURL()
	{
		return "ui://h09dvkcglxbt42";
	}

	public static UI_com_Entry2 CreateInstance()
	{
		return (UI_com_Entry2)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Entry2");
	}

	public static UI_com_Entry2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Entry2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcglxbt42", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		NewEntry = (GRichTextField)((GComponent)this).GetChild("NewEntry");
		string id = "ui://h09dvkcglxbt42".Replace("ui://", "") + "-" + ((GObject)NewEntry).id;
		((GObject)NewEntry).text = LanguagesManager.GetDesc(id);
		NewEntryUnlockLevel = (GRichTextField)((GComponent)this).GetChild("NewEntryUnlockLevel");
		OldEntryTitle = (GRichTextField)((GComponent)this).GetChild("OldEntryTitle");
		string id2 = "ui://h09dvkcglxbt42".Replace("ui://", "") + "-" + ((GObject)OldEntryTitle).id;
		((GObject)OldEntryTitle).text = LanguagesManager.GetDesc(id2);
		OldEntry = (GRichTextField)((GComponent)this).GetChild("OldEntry");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
