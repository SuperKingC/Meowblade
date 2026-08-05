using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_workerButton : GComponent
{
	public Controller button;

	public GImage background;

	public GGraph workerButtonSpine;

	public GImage worker;

	public UI_addButton addButton;

	public GTextField CurrentWorkerAmount;

	public GTextField AllWorkerAmount;

	public GTextField separate;

	public UI_ExclamationMarkBtn ExclamationMarkBtn;

	public GGroup n18;

	public Transition textHeoghtLight;

	public const string URL = "ui://kt6rg65ol3sc14";

	public static string Name = "UI_workerButton";

	public static string GetURL()
	{
		return "ui://kt6rg65ol3sc14";
	}

	public static UI_workerButton CreateInstance()
	{
		return (UI_workerButton)(object)UIPackage.CreateObject("PublicResources", "workerButton");
	}

	public static UI_workerButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_workerButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ol3sc14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		workerButtonSpine = (GGraph)((GComponent)this).GetChild("workerButtonSpine");
		worker = (GImage)((GComponent)this).GetChild("worker");
		addButton = (UI_addButton)(object)((GComponent)this).GetChild("addButton");
		CurrentWorkerAmount = (GTextField)((GComponent)this).GetChild("CurrentWorkerAmount");
		AllWorkerAmount = (GTextField)((GComponent)this).GetChild("AllWorkerAmount");
		separate = (GTextField)((GComponent)this).GetChild("separate");
		ExclamationMarkBtn = (UI_ExclamationMarkBtn)(object)((GComponent)this).GetChild("ExclamationMarkBtn");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		textHeoghtLight = ((GComponent)this).GetTransition("textHeoghtLight");
	}
}
