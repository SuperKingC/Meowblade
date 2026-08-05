using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorkShop;

public class UI_workerItem : GButton
{
	public Controller button;

	public GImage normalState;

	public GImage increaseState;

	public Transition increase;

	public Transition reduce;

	public const string URL = "ui://k6y9jq3appg416";

	public static string Name = "UI_workerItem";

	public static string GetURL()
	{
		return "ui://k6y9jq3appg416";
	}

	public static UI_workerItem CreateInstance()
	{
		return (UI_workerItem)(object)UIPackage.CreateObject("WorkShop", "workerItem");
	}

	public static UI_workerItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_workerItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k6y9jq3appg416", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		normalState = (GImage)((GComponent)this).GetChild("normalState");
		increaseState = (GImage)((GComponent)this).GetChild("increaseState");
		increase = ((GComponent)this).GetTransition("increase");
		reduce = ((GComponent)this).GetTransition("reduce");
	}
}
