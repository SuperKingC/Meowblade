using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_workerBackItem : GButton
{
	public Controller button;

	public GImage reduceState;

	public const string URL = "ui://72poq8plkxixr";

	public static string Name = "UI_workerBackItem";

	public static string GetURL()
	{
		return "ui://72poq8plkxixr";
	}

	public static UI_workerBackItem CreateInstance()
	{
		return (UI_workerBackItem)(object)UIPackage.CreateObject("RecyclingCenter", "workerBackItem");
	}

	public static UI_workerBackItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_workerBackItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		reduceState = (GImage)((GComponent)this).GetChild("reduceState");
	}
}
