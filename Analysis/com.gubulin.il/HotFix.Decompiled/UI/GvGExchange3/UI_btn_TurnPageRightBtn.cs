using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_TurnPageRightBtn : GButton
{
	public Controller button;

	public GGraph n1;

	public GImage n3;

	public const string URL = "ui://tt2iq07oiarz5i";

	public static string Name = "UI_btn_TurnPageRightBtn";

	public static string GetURL()
	{
		return "ui://tt2iq07oiarz5i";
	}

	public static UI_btn_TurnPageRightBtn CreateInstance()
	{
		return (UI_btn_TurnPageRightBtn)(object)UIPackage.CreateObject("GvGExchange3", "btn_TurnPageRightBtn");
	}

	public static UI_btn_TurnPageRightBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TurnPageRightBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oiarz5i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
