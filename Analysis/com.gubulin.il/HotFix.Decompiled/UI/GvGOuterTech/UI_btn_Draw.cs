using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_Draw : GButton
{
	public Controller button;

	public GImage n9;

	public GLoader n11;

	public GImage note;

	public const string URL = "ui://th385mttlgfv1i";

	public static string Name = "UI_btn_Draw";

	public static string GetURL()
	{
		return "ui://th385mttlgfv1i";
	}

	public static UI_btn_Draw CreateInstance()
	{
		return (UI_btn_Draw)(object)UIPackage.CreateObject("GvGOuterTech", "btn_Draw");
	}

	public static UI_btn_Draw CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Draw).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttlgfv1i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n11 = (GLoader)((GComponent)this).GetChild("n11");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
