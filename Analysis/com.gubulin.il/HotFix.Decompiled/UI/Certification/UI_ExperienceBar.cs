using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_ExperienceBar : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://56q48tcqm13tv";

	public static string Name = "UI_ExperienceBar";

	public static string GetURL()
	{
		return "ui://56q48tcqm13tv";
	}

	public static UI_ExperienceBar CreateInstance()
	{
		return (UI_ExperienceBar)(object)UIPackage.CreateObject("Certification", "ExperienceBar");
	}

	public static UI_ExperienceBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExperienceBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
