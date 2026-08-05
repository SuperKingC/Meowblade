using Assets.Scripts.Managers;

namespace Shift.Legion.Common.Models;

public struct ActionResult
{
	public bool Result;

	public ActionResultCode ResultCode;

	public object[] Params;

	public string ErrorMessage
	{
		get
		{
			if (ResultCode == ActionResultCode.Default)
			{
				return "";
			}
			string text = LanguagesManager.GetActionResultMessage(ResultCode);
			if (Params != null && Params.Length != 0)
			{
				text = string.Format(text, Params);
			}
			return text;
		}
	}
}
