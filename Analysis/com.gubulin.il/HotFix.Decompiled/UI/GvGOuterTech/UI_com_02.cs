using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_02 : GComponent
{
	public Controller activate;

	public Controller c2;

	public GImage n145;

	public GTextField n146;

	public GTextField n151;

	public GTextField n147;

	public GTextField n152;

	public GGroup n148;

	public const string URL = "ui://th385mttj7x6o8i";

	public static string Name = "UI_com_02";

	public static string GetURL()
	{
		return "ui://th385mttj7x6o8i";
	}

	public static UI_com_02 CreateInstance()
	{
		return (UI_com_02)(object)UIPackage.CreateObject("GvGOuterTech", "com_02");
	}

	public static UI_com_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttj7x6o8i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		activate = ((GComponent)this).GetController("activate");
		c2 = ((GComponent)this).GetController("c2");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GTextField)((GComponent)this).GetChild("n146");
		string id = "ui://th385mttj7x6o8i".Replace("ui://", "") + "-" + ((GObject)n146).id;
		((GObject)n146).text = LanguagesManager.GetDesc(id);
		n151 = (GTextField)((GComponent)this).GetChild("n151");
		string id2 = "ui://th385mttj7x6o8i".Replace("ui://", "") + "-" + ((GObject)n151).id;
		((GObject)n151).text = LanguagesManager.GetDesc(id2);
		n147 = (GTextField)((GComponent)this).GetChild("n147");
		string id3 = "ui://th385mttj7x6o8i".Replace("ui://", "") + "-" + ((GObject)n147).id;
		((GObject)n147).text = LanguagesManager.GetDesc(id3);
		n152 = (GTextField)((GComponent)this).GetChild("n152");
		string id4 = "ui://th385mttj7x6o8i".Replace("ui://", "") + "-" + ((GObject)n152).id;
		((GObject)n152).text = LanguagesManager.GetDesc(id4);
		n148 = (GGroup)((GComponent)this).GetChild("n148");
	}
}
