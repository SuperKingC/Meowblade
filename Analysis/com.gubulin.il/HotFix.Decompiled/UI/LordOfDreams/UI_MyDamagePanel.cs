using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_MyDamagePanel : GComponent
{
	public Controller StateController;

	public GImage back;

	public UI_MyDamageBtn MyDamageBtn;

	public GImage arrow;

	public GList List;

	public Transition Collapse;

	public Transition Expand;

	public const string URL = "ui://0i520nzmhyas2m";

	public static string Name = "UI_MyDamagePanel";

	public static string GetURL()
	{
		return "ui://0i520nzmhyas2m";
	}

	public static UI_MyDamagePanel CreateInstance()
	{
		return (UI_MyDamagePanel)(object)UIPackage.CreateObject("LordOfDreams", "MyDamagePanel");
	}

	public static UI_MyDamagePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyDamagePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmhyas2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		back = (GImage)((GComponent)this).GetChild("back");
		MyDamageBtn = (UI_MyDamageBtn)(object)((GComponent)this).GetChild("MyDamageBtn");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		List = (GList)((GComponent)this).GetChild("List");
		Collapse = ((GComponent)this).GetTransition("Collapse");
		Expand = ((GComponent)this).GetTransition("Expand");
	}
}
