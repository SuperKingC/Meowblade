using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Services;

public sealed class TextTranslateService : Service, ITextTranslateService, IService
{
	private Dictionary<string, InfoEvo> _infoEvoDict;

	private Dictionary<string, InfoEvo> InfoEvoDict
	{
		get
		{
			if (_infoEvoDict == null)
			{
				_infoEvoDict = new Dictionary<string, InfoEvo>();
				IEnumerable<GDEInfoEvoData> allItems = GDMgr.GetAllItems<GDEInfoEvoData>();
				foreach (GDEInfoEvoData item in allItems)
				{
					InfoEvoDict.Add(item.Key, new InfoEvo(item.Key));
				}
			}
			return _infoEvoDict;
		}
	}

	public TextTranslateService(Contexts contexts)
		: base(contexts)
	{
	}

	public InfoEvo GetInfoEvo(string infoEvoId)
	{
		return InfoEvoDict.ContainsKey(infoEvoId) ? InfoEvoDict[infoEvoId] : null;
	}
}
