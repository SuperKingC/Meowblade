using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_HoldingPercent : GComponent
{
	public Controller CampId;

	public Controller State;

	public GLoader n0;

	public GLoader n1;

	public GTextField HoldingPercent;

	public GImage n6;

	public GMovieClip n5;

	public const string URL = "ui://hd2s9kukcqf74o";

	public static string Name = "UI_HoldingPercent";

	public static string GetURL()
	{
		return "ui://hd2s9kukcqf74o";
	}

	public static UI_HoldingPercent CreateInstance()
	{
		return (UI_HoldingPercent)(object)UIPackage.CreateObject("GvGWorldMap2", "HoldingPercent");
	}

	public static UI_HoldingPercent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HoldingPercent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukcqf74o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		State = ((GComponent)this).GetController("State");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		HoldingPercent = (GTextField)((GComponent)this).GetChild("HoldingPercent");
		string id = "ui://hd2s9kukcqf74o".Replace("ui://", "") + "-" + ((GObject)HoldingPercent).id;
		((GObject)HoldingPercent).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GMovieClip)((GComponent)this).GetChild("n5");
	}
}
