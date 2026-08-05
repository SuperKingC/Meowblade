using System.Collections.Generic;
using GvG2.Common.Models;
using UnityEngine;

namespace GvG2;

public class ShipManager
{
	private Dictionary<int, Ship> Ships;

	private Transform Collector;

	private int curId = 0;

	public ShipManager(Transform collector)
	{
		if (!((Object)(object)collector == (Object)null))
		{
			Ships = new Dictionary<int, Ship>();
			Collector = collector;
		}
	}

	public Ship GetById(int id)
	{
		if (Ships.TryGetValue(id, out var value))
		{
			return value;
		}
		return null;
	}

	public void AddShip(ShipProps props)
	{
		if (!Ships.ContainsKey(props.Id))
		{
			Ship value = new Ship(props, Collector);
			Ships.Add(props.Id, value);
		}
	}

	public void RemoveShip(int id)
	{
		if (Ships.TryGetValue(id, out var value))
		{
			value.Destroy();
			Ships.Remove(id);
		}
	}

	public int CreateFakeShip()
	{
		int campId = Random.Range(1, 5);
		AddShip(new ShipProps
		{
			Id = ++curId,
			CampId = campId,
			UserId = GameController.Contexts.gameState.user.value.UserId
		});
		return curId;
	}
}
