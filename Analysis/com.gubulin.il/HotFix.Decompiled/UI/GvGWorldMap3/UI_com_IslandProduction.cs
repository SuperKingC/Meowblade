using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_com_IslandProduction : GComponent
{
	public Controller c1;

	public GImage n4;

	public GList Speciality;

	public GTextField n5;

	public GImage n6;

	public UI_dec_01 n7;

	public const string URL = "ui://4eq8fgd2h4tpdy";

	public static string Name = "UI_com_IslandProduction";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpdy";
	}

	public static UI_com_IslandProduction CreateInstance()
	{
		return (UI_com_IslandProduction)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandProduction");
	}

	public static UI_com_IslandProduction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandProduction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpdy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Speciality = (GList)((GComponent)this).GetChild("Speciality");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://4eq8fgd2h4tpdy".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (UI_dec_01)(object)((GComponent)this).GetChild("n7");
	}

	public void OnRender(IslandStateModel islandState)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		List<GvGMode3IslandOutputModel> productions = islandState.DetailInfo.GetAllCollectingStock();
		productions.Sort(GvGMode3IslandOutputModel.CompareTo);
		List<GvGMode3IslandOutputModel> viewList = productions.Take(4).ToList();
		Speciality.itemRenderer = new ListItemRenderer(RenderProduction);
		Speciality.numItems = viewList.Count;
		((GObject)this).onClick.Set(new EventCallback0(CheckIslandProductions));
		void CheckIslandProductions()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandOutput.Name, new Dictionary<string, object>
			{
				{ "Output", productions },
				{ "DialogType", 0 },
				{ "IslandId", islandState.IslandId },
				{ "IslandDetail", islandState.DetailInfo }
			});
		}
		void RenderProduction(int index, GObject obj)
		{
			if (!(obj is UI_com_IslandSpeciality uI_com_IslandSpeciality))
			{
				ILRuntimeDebug.LogError("UI_com_IslandProduction:productionUi is not UI_com_IslandSpeciality");
			}
			else
			{
				GvGMode3IslandOutputModel gvGMode3IslandOutputModel = viewList[index];
				if (gvGMode3IslandOutputModel.Type == eIslandOutputModel.Normal)
				{
					uI_com_IslandSpeciality.Source.selectedIndex = 0;
				}
				else
				{
					uI_com_IslandSpeciality.Source.selectedIndex = 1;
					uI_com_IslandSpeciality.SourceMark.State.selectedIndex = gvGMode3IslandOutputModel.SourceType;
				}
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_IslandSpeciality.Icon, gvGMode3IslandOutputModel.ItemId);
			}
		}
	}
}
