using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using UI.Tips;

namespace UI.ReturningRewards;

public class UI_btn_GerMore : GButton
{
	public Controller button;

	public GImage n6;

	public const string URL = "ui://rx5ntv98win2d";

	public static string Name = "UI_btn_GerMore";

	private const string RECALL_PACK = "RecallPack";

	private StoreItem _storeItem;

	public static string GetURL()
	{
		return "ui://rx5ntv98win2d";
	}

	public static UI_btn_GerMore CreateInstance()
	{
		return (UI_btn_GerMore)(object)UIPackage.CreateObject("ReturningRewards", "btn_GerMore");
	}

	public static UI_btn_GerMore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GerMore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}

	public void Register()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
	}

	public void Unregister()
	{
		((GObject)this).onClick.Clear();
	}

	private void OnClick()
	{
		InsureStoreItemLoaded();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
		{
			{
				"Name",
				_storeItem.Name ?? ""
			},
			{ "CanBuy", true },
			{ "GiftBag", _storeItem },
			{ "Parent", this },
			{ "IsBatchPurchaseMode", true }
		});
	}

	private void InsureStoreItemLoaded()
	{
		if (_storeItem == null)
		{
			_storeItem = StoreItem.Get(GameManagers.Instance, "RecallPack");
		}
	}
}
