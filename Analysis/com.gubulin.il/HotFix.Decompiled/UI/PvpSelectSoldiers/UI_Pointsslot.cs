using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_Pointsslot : GComponent
{
	public Controller lineBack;

	public Controller hasScore;

	public GGraph bg;

	public GTextField n1;

	public GTextField n2;

	public GTextField n4;

	public GTextField n3;

	public const string URL = "ui://82mo10n5jzv6jdvh";

	public static string Name = "UI_Pointsslot";

	public static string GetURL()
	{
		return "ui://82mo10n5jzv6jdvh";
	}

	public static UI_Pointsslot CreateInstance()
	{
		return (UI_Pointsslot)(object)UIPackage.CreateObject("PvpSelectSoldiers", "Pointsslot");
	}

	public static UI_Pointsslot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Pointsslot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5jzv6jdvh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		lineBack = ((GComponent)this).GetController("lineBack");
		hasScore = ((GComponent)this).GetController("hasScore");
		bg = (GGraph)((GComponent)this).GetChild("bg");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://82mo10n5jzv6jdvh".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://82mo10n5jzv6jdvh".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
	}
}
