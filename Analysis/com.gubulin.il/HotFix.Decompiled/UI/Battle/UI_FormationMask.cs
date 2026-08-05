using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_FormationMask : GComponent
{
	public Controller Type;

	public UI_Mask mask;

	public const string URL = "ui://twlbabicf4sz3t";

	public static string Name = "UI_FormationMask";

	public static string GetURL()
	{
		return "ui://twlbabicf4sz3t";
	}

	public static UI_FormationMask CreateInstance()
	{
		return (UI_FormationMask)(object)UIPackage.CreateObject("Battle", "FormationMask");
	}

	public static UI_FormationMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicf4sz3t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		mask = (UI_Mask)(object)((GComponent)this).GetChild("mask");
	}
}
