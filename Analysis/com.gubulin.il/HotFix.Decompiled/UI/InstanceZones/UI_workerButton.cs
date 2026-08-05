using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_workerButton : GButton
{
	public Controller button;

	public GImage background;

	public GButton addButton;

	public GGraph textBack;

	public GTextField num;

	public GImage n14;

	public GLoader icon;

	public GTextField MaxNum;

	public GTextField separate;

	public GTextField ExtraLimit;

	public const string URL = "ui://f4wr270rmm8nd";

	public static string Name = "UI_workerButton";

	public static string GetURL()
	{
		return "ui://f4wr270rmm8nd";
	}

	public static UI_workerButton CreateInstance()
	{
		return (UI_workerButton)(object)UIPackage.CreateObject("InstanceZones", "workerButton");
	}

	public static UI_workerButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_workerButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rmm8nd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		addButton = (GButton)((GComponent)this).GetChild("addButton");
		textBack = (GGraph)((GComponent)this).GetChild("textBack");
		num = (GTextField)((GComponent)this).GetChild("num");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		MaxNum = (GTextField)((GComponent)this).GetChild("MaxNum");
		separate = (GTextField)((GComponent)this).GetChild("separate");
		ExtraLimit = (GTextField)((GComponent)this).GetChild("ExtraLimit");
	}
}
