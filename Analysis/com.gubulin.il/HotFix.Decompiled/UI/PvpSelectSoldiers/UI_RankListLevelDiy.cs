using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankListLevelDiy : GComponent
{
	public Controller Status;

	public GLoader LastLevelHun;

	public GLoader LastLevelDec;

	public GLoader LastLevelIn;

	public GImage n32;

	public const string URL = "ui://82mo10n5lt7m9n";

	public static string Name = "UI_RankListLevelDiy";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9n";
	}

	public static UI_RankListLevelDiy CreateInstance()
	{
		return (UI_RankListLevelDiy)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankListLevelDiy");
	}

	public static UI_RankListLevelDiy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankListLevelDiy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		LastLevelHun = (GLoader)((GComponent)this).GetChild("LastLevelHun");
		LastLevelDec = (GLoader)((GComponent)this).GetChild("LastLevelDec");
		LastLevelIn = (GLoader)((GComponent)this).GetChild("LastLevelIn");
		n32 = (GImage)((GComponent)this).GetChild("n32");
	}

	public void ShowRankLevel(int _level)
	{
		if (_level <= 0 || _level > 800)
		{
			Status.selectedIndex = 3;
			return;
		}
		string text = LevelStringReverse(_level.ToString());
		if (text.Length > 0)
		{
			Status.selectedIndex = text.Length - 1;
			if (Status.selectedIndex == 2)
			{
				LastLevelHun.url = $"ui://PublicResources/{text[2]}";
				LastLevelDec.url = $"ui://PublicResources/{text[1]}";
				LastLevelIn.url = $"ui://PublicResources/{text[0]}";
			}
			else if (Status.selectedIndex == 1)
			{
				LastLevelDec.url = $"ui://PublicResources/{text[1]}";
				LastLevelIn.url = $"ui://PublicResources/{text[0]}";
			}
			else if (Status.selectedIndex == 0)
			{
				LastLevelIn.url = $"ui://PublicResources/{text[0]}";
			}
		}
	}

	private string LevelStringReverse(string input)
	{
		string text = "";
		for (int num = input.Length - 1; num >= 0; num--)
		{
			text += input[num];
		}
		return text;
	}
}
