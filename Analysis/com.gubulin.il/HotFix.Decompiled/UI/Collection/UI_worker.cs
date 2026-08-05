using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_worker : GButton
{
	public Controller button;

	public GImage normal;

	public GImage increase;

	public Transition increase_2;

	public Transition reduce;

	public const string URL = "ui://ehe4tm5zb8ch1q";

	public static string Name = "UI_worker";

	public static string GetURL()
	{
		return "ui://ehe4tm5zb8ch1q";
	}

	public static UI_worker CreateInstance()
	{
		return (UI_worker)(object)UIPackage.CreateObject("Collection", "worker");
	}

	public static UI_worker CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_worker).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zb8ch1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		normal = (GImage)((GComponent)this).GetChild("normal");
		increase = (GImage)((GComponent)this).GetChild("increase");
		increase_2 = ((GComponent)this).GetTransition("increase");
		reduce = ((GComponent)this).GetTransition("reduce");
	}
}
