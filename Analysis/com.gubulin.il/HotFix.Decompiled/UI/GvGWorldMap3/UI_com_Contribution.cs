using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_Contribution : GComponent
{
	public GLoader Icon;

	public GTextField Contribution;

	public GRichTextField Per;

	public Transition ShowContribution;

	public const string URL = "ui://4eq8fgd2eai39q";

	public static string Name = "UI_com_Contribution";

	public bool Available => !ShowContribution.playing;

	public static string GetURL()
	{
		return "ui://4eq8fgd2eai39q";
	}

	public static UI_com_Contribution CreateInstance()
	{
		return (UI_com_Contribution)(object)UIPackage.CreateObject("GvGWorldMap3", "com_Contribution");
	}

	public static UI_com_Contribution CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Contribution).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2eai39q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Contribution = (GTextField)((GComponent)this).GetChild("Contribution");
		Per = (GRichTextField)((GComponent)this).GetChild("Per");
		ShowContribution = ((GComponent)this).GetTransition("ShowContribution");
	}

	public void ShowSelf(ContributionPointsChanged contribution)
	{
		if (Available)
		{
			((GObject)Contribution).text = $"+{Mathf.RoundToInt(contribution.ChangedValue)}";
			((GObject)Per).text = ((contribution.Per > 1f) ? $"{Mathf.RoundToInt(contribution.Per * 100f)}%" : string.Empty);
			ShowContribution.Play();
		}
	}
}
