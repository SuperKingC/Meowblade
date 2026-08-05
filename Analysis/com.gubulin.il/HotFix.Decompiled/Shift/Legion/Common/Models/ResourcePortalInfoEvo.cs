using System.Collections.Generic;
using Assets.Scripts.Managers;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class ResourcePortalInfoEvo : InfoEvo
{
	protected new const string DefaultName = "资源传送门";

	private const string DefaultImagePath = "back1";

	private const string DefaultGuiderImg = "icon_01_victory_balance";

	private const string KeyDesc = "Desc";

	private const string KeyImagePath = "Image";

	private const string KeyGuiderTip = "GuiderTip";

	private const string KeyGuiderImg = "GuiderImg";

	private const string KeyGuiderName = "GuiderName";

	public List<string> DescList;

	public List<string> ImagePathList;

	public List<string> GuiderTipList;

	public List<string> GuiderImgList;

	public List<string> GuiderNameList;

	private string DefaultDesc => LanguagesManager.GetDesc("CsharpCodeZhTcText822");

	private string DefaultGuiderTip => LanguagesManager.GetDesc("CsharpCodeZhTcText823");

	private string DefaultGuiderName => LanguagesManager.GetDesc("CsharpCodeZhTcText824");

	public ResourcePortalInfoEvo(string evoInfoId)
		: base(evoInfoId)
	{
		DescList = new List<string>();
		ImagePathList = new List<string>();
		GuiderTipList = new List<string>();
		GuiderImgList = new List<string>();
		GuiderNameList = new List<string>();
		GDEInfoEvoData gDEInfoEvoData = GDMgr.Get<GDEInfoEvoData>(evoInfoId);
		if (gDEInfoEvoData == null)
		{
			return;
		}
		for (int i = 0; i < NameList.Count; i++)
		{
			string text = string.Empty;
			object obj = gDEInfoEvoData.GetType().GetProperty($"Extra{i}")?.GetValue(gDEInfoEvoData);
			if (obj != null)
			{
				text = obj.ToString();
			}
			if (obj != null && string.IsNullOrEmpty(text))
			{
				DescList.Add(DefaultDesc);
				ImagePathList.Add("back1");
			}
			else if (text == string.Empty)
			{
				DescList.Add(DefaultDesc);
				ImagePathList.Add("back1");
				GuiderTipList.Add(DefaultGuiderTip);
				GuiderImgList.Add("icon_01_victory_balance");
				GuiderNameList.Add(DefaultGuiderName);
			}
			else
			{
				Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(text);
				DescList.Add(dictionary.ContainsKey("Desc") ? dictionary["Desc"] : DefaultDesc);
				ImagePathList.Add(dictionary.ContainsKey("Image") ? dictionary["Image"] : "back1");
				GuiderTipList.Add(dictionary.ContainsKey("GuiderTip") ? dictionary["GuiderTip"] : DefaultGuiderTip);
				GuiderImgList.Add(dictionary.ContainsKey("GuiderImg") ? dictionary["GuiderImg"] : "icon_01_victory_balance");
				GuiderNameList.Add(dictionary.ContainsKey("GuiderName") ? dictionary["GuiderName"] : DefaultGuiderName);
			}
		}
	}
}
