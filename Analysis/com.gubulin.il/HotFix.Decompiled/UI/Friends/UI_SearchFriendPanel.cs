using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_SearchFriendPanel : GComponent
{
	public GImage tipBackground;

	public GRichTextField title;

	public GImage inputBackground;

	public GTextInput inputId;

	public UI_SendBtn n5;

	public const string URL = "ui://3rz8gv6cc3w3i";

	public static string Name = "UI_SearchFriendPanel";

	public static string GetURL()
	{
		return "ui://3rz8gv6cc3w3i";
	}

	public static UI_SearchFriendPanel CreateInstance()
	{
		return (UI_SearchFriendPanel)(object)UIPackage.CreateObject("Friends", "SearchFriendPanel");
	}

	public static UI_SearchFriendPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SearchFriendPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tipBackground = (GImage)((GComponent)this).GetChild("tipBackground");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://3rz8gv6cc3w3i".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		inputBackground = (GImage)((GComponent)this).GetChild("inputBackground");
		inputId = (GTextInput)((GComponent)this).GetChild("inputId");
		string id2 = "ui://3rz8gv6cc3w3i".Replace("ui://", "") + "-" + ((GObject)inputId).id + "-prompt";
		inputId.promptText = LanguagesManager.GetDesc(id2);
		n5 = (UI_SendBtn)(object)((GComponent)this).GetChild("n5");
	}
}
