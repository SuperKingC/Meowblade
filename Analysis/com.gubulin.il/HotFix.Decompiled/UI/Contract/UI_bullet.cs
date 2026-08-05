using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_bullet : GButton
{
	public Controller button;

	public GImage n5;

	public GGraph carrier;

	public Transition left_handed;

	public Transition right_handed;

	public const string URL = "ui://avplaivdnae810";

	public static string Name = "UI_bullet";

	public static string GetURL()
	{
		return "ui://avplaivdnae810";
	}

	public static UI_bullet CreateInstance()
	{
		return (UI_bullet)(object)UIPackage.CreateObject("Contract", "bullet");
	}

	public static UI_bullet CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_bullet).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnae810", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		carrier = (GGraph)((GComponent)this).GetChild("carrier");
		left_handed = ((GComponent)this).GetTransition("left-handed");
		right_handed = ((GComponent)this).GetTransition("right-handed");
	}
}
