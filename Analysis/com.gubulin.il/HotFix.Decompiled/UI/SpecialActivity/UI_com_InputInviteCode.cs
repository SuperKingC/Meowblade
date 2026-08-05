using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_com_InputInviteCode : GComponent
{
	public Controller IsClaimed;

	public GImage b1;

	public GTextInput Input;

	public GTextField n44;

	public const string URL = "ui://kozswd8hbwf1f3z";

	public static string Name = "UI_com_InputInviteCode";

	public static string GetURL()
	{
		return "ui://kozswd8hbwf1f3z";
	}

	public static UI_com_InputInviteCode CreateInstance()
	{
		return (UI_com_InputInviteCode)(object)UIPackage.CreateObject("SpecialActivity", "com_InputInviteCode");
	}

	public static UI_com_InputInviteCode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_InputInviteCode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hbwf1f3z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		b1 = (GImage)((GComponent)this).GetChild("b1");
		Input = (GTextInput)((GComponent)this).GetChild("Input");
		string id = "ui://kozswd8hbwf1f3z".Replace("ui://", "") + "-" + ((GObject)Input).id + "-prompt";
		Input.promptText = LanguagesManager.GetDesc(id);
		n44 = (GTextField)((GComponent)this).GetChild("n44");
		string id2 = "ui://kozswd8hbwf1f3z".Replace("ui://", "") + "-" + ((GObject)n44).id;
		((GObject)n44).text = LanguagesManager.GetDesc(id2);
	}
}
