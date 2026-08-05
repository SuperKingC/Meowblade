using System.Collections.Generic;
using GameDataEditor;

namespace Shift.Legion.Common.Models.LegendItem;

public class SuitData
{
	private GDELegendItemSetData _data;

	public List<string> SuitIdentitiesList;

	public List<string> SuitProperties;

	public string SuitName => _data?.SetName;

	public string SuitDesc => _data?.SetDesc;

	public int SuitNum => _data?.SetPiecesQty ?? 0;

	public SuitData(GDELegendItemSetData data)
	{
		_data = data;
		SuitIdentitiesList = _data.SetPieces;
		SuitProperties = _data.SetFxEntries;
	}
}
