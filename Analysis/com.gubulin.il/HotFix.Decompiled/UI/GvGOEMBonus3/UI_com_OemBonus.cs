using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMBonus3;

public class UI_com_OemBonus : GComponent
{
	public Controller Type;

	public Controller Get;

	public GImage n209;

	public GTextField Count;

	public GTextField n210;

	public GTextField n211;

	public GTextField n212;

	public GTextField n213;

	public GTextField n216;

	public GImage n214;

	public GImage n215;

	public const string URL = "ui://h3bpjkt7pzxd5u";

	public static string Name = "UI_com_OemBonus";

	public static string GetURL()
	{
		return "ui://h3bpjkt7pzxd5u";
	}

	public static UI_com_OemBonus CreateInstance()
	{
		return (UI_com_OemBonus)(object)UIPackage.CreateObject("GvGOEMBonus3", "com_OemBonus");
	}

	public static UI_com_OemBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OemBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pzxd5u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Get = ((GComponent)this).GetController("Get");
		n209 = (GImage)((GComponent)this).GetChild("n209");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n210 = (GTextField)((GComponent)this).GetChild("n210");
		string id = "ui://h3bpjkt7pzxd5u".Replace("ui://", "") + "-" + ((GObject)n210).id;
		((GObject)n210).text = LanguagesManager.GetDesc(id);
		n211 = (GTextField)((GComponent)this).GetChild("n211");
		string id2 = "ui://h3bpjkt7pzxd5u".Replace("ui://", "") + "-" + ((GObject)n211).id;
		((GObject)n211).text = LanguagesManager.GetDesc(id2);
		n212 = (GTextField)((GComponent)this).GetChild("n212");
		string id3 = "ui://h3bpjkt7pzxd5u".Replace("ui://", "") + "-" + ((GObject)n212).id;
		((GObject)n212).text = LanguagesManager.GetDesc(id3);
		n213 = (GTextField)((GComponent)this).GetChild("n213");
		string id4 = "ui://h3bpjkt7pzxd5u".Replace("ui://", "") + "-" + ((GObject)n213).id;
		((GObject)n213).text = LanguagesManager.GetDesc(id4);
		n216 = (GTextField)((GComponent)this).GetChild("n216");
		string id5 = "ui://h3bpjkt7pzxd5u".Replace("ui://", "") + "-" + ((GObject)n216).id;
		((GObject)n216).text = LanguagesManager.GetDesc(id5);
		n214 = (GImage)((GComponent)this).GetChild("n214");
		n215 = (GImage)((GComponent)this).GetChild("n215");
	}
}
