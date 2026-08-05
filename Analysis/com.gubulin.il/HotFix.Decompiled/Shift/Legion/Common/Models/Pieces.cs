using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Pieces
{
	public GDEPiecesData Data;

	public readonly PiecesType Type;

	public readonly string PiecesId;

	public readonly string ItemId;

	public readonly int CompositeRequirement;

	public readonly string RelativeContext;

	public readonly Dictionary<string, int> Result;

	public Pieces(GDEPiecesData piecesData)
	{
		Data = piecesData;
		Type = (PiecesType)piecesData.Type;
		PiecesId = piecesData.Key;
		ItemId = piecesData.ItemId;
		CompositeRequirement = piecesData.CompositeRequirements;
		RelativeContext = piecesData.RelativeContext;
		Result = new Dictionary<string, int>();
		if (string.IsNullOrEmpty(piecesData.Result))
		{
			return;
		}
		foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(piecesData.Result))
		{
			Result.Add(item.Key, item.Value);
		}
	}
}
