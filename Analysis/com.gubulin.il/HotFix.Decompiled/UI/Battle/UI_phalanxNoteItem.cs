using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_phalanxNoteItem : GButton
{
	public Controller button;

	public GGraph n4;

	public GLoader phalanx3;

	public const string URL = "ui://twlbabicl9bq23";

	public static string Name = "UI_phalanxNoteItem";

	public static string GetURL()
	{
		return "ui://twlbabicl9bq23";
	}

	public static UI_phalanxNoteItem CreateInstance()
	{
		return (UI_phalanxNoteItem)(object)UIPackage.CreateObject("Battle", "phalanxNoteItem");
	}

	public static UI_phalanxNoteItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_phalanxNoteItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicl9bq23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		phalanx3 = (GLoader)((GComponent)this).GetChild("phalanx3");
	}
}
