using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_dec_block10 : GComponent
{
	public GImage n74;

	public GImage n75;

	public GGroup n76;

	public Transition t0;

	public const string URL = "ui://th385mtt7ztlo63";

	public static string Name = "UI_dec_block10";

	public static string GetURL()
	{
		return "ui://th385mtt7ztlo63";
	}

	public static UI_dec_block10 CreateInstance()
	{
		return (UI_dec_block10)(object)UIPackage.CreateObject("GvGOuterTech", "dec_block10");
	}

	public static UI_dec_block10 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_block10).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt7ztlo63", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n76 = (GGroup)((GComponent)this).GetChild("n76");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
