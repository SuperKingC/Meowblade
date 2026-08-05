using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_IntegralNode : GButton
{
	public Controller button;

	public UI_nodeBtn nodeBtn;

	public GImage arrow;

	public GTextField integral;

	public GLoader integralIcon;

	public GGroup pointsRequired;

	public GTextField omissionMark;

	public const string URL = "ui://f4wr270rjcdfm";

	public static string Name = "UI_IntegralNode";

	public static string GetURL()
	{
		return "ui://f4wr270rjcdfm";
	}

	public static UI_IntegralNode CreateInstance()
	{
		return (UI_IntegralNode)(object)UIPackage.CreateObject("InstanceZones", "IntegralNode");
	}

	public static UI_IntegralNode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IntegralNode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rjcdfm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		nodeBtn = (UI_nodeBtn)(object)((GComponent)this).GetChild("nodeBtn");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		integral = (GTextField)((GComponent)this).GetChild("integral");
		string id = "ui://f4wr270rjcdfm".Replace("ui://", "") + "-" + ((GObject)integral).id;
		((GObject)integral).text = LanguagesManager.GetDesc(id);
		integralIcon = (GLoader)((GComponent)this).GetChild("integralIcon");
		pointsRequired = (GGroup)((GComponent)this).GetChild("pointsRequired");
		omissionMark = (GTextField)((GComponent)this).GetChild("omissionMark");
		string id2 = "ui://f4wr270rjcdfm".Replace("ui://", "") + "-" + ((GObject)omissionMark).id;
		((GObject)omissionMark).text = LanguagesManager.GetDesc(id2);
	}
}
