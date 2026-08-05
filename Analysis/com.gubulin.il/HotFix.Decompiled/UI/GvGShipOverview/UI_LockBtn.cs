using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_LockBtn : GButton
{
	public Controller State;

	public GImage n140;

	public GTextField n142;

	public GTextField n143;

	public GTextField n144;

	public const string URL = "ui://7ymaonxtb2oh2n";

	public static string Name = "UI_LockBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtb2oh2n";
	}

	public static UI_LockBtn CreateInstance()
	{
		return (UI_LockBtn)(object)UIPackage.CreateObject("GvGShipOverview", "LockBtn");
	}

	public static UI_LockBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LockBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtb2oh2n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n142 = (GTextField)((GComponent)this).GetChild("n142");
		string id = "ui://7ymaonxtb2oh2n".Replace("ui://", "") + "-" + ((GObject)n142).id;
		((GObject)n142).text = LanguagesManager.GetDesc(id);
		n143 = (GTextField)((GComponent)this).GetChild("n143");
		string id2 = "ui://7ymaonxtb2oh2n".Replace("ui://", "") + "-" + ((GObject)n143).id;
		((GObject)n143).text = LanguagesManager.GetDesc(id2);
		n144 = (GTextField)((GComponent)this).GetChild("n144");
		string id3 = "ui://7ymaonxtb2oh2n".Replace("ui://", "") + "-" + ((GObject)n144).id;
		((GObject)n144).text = LanguagesManager.GetDesc(id3);
	}
}
