using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_Zoom : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://hd2s9kukjm2l46";

	public static string Name = "UI_Zoom";

	public static string GetURL()
	{
		return "ui://hd2s9kukjm2l46";
	}

	public static UI_Zoom CreateInstance()
	{
		return (UI_Zoom)(object)UIPackage.CreateObject("GvGWorldMap2", "Zoom");
	}

	public static UI_Zoom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Zoom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukjm2l46", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://hd2s9kukjm2l46".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
