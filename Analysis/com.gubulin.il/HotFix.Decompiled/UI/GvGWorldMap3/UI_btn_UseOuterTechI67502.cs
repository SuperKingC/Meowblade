using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_UseOuterTechI67502 : GButton
{
	public Controller button;

	public GGraph n3;

	public GImage bg;

	public GImage n5;

	public const string URL = "ui://4eq8fgd2mn6ws9e";

	public static string Name = "UI_btn_UseOuterTechI67502";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mn6ws9e";
	}

	public static UI_btn_UseOuterTechI67502 CreateInstance()
	{
		return (UI_btn_UseOuterTechI67502)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_UseOuterTechI67502");
	}

	public static UI_btn_UseOuterTechI67502 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_UseOuterTechI67502).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mn6ws9e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
