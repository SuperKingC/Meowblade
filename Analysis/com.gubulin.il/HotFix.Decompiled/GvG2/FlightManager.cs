using System.Collections.Generic;
using System.Linq;
using GvG2.Common.Models;
using UnityEngine;

namespace GvG2;

public class FlightManager
{
	private List<FlightEntity> Flights;

	private ShipManager ShipManager;

	private MapDataManager MapDataManager;

	private float StartUnityTime;

	private int StartManagerTime;

	public FlightManager(ShipManager shipManager, MapDataManager mapDataManager)
	{
		Flights = new List<FlightEntity>();
		ShipManager = shipManager;
		MapDataManager = mapDataManager;
		StartUnityTime = Time.realtimeSinceStartup;
		StartManagerTime = (int)GameController.Instance.GetServerTime();
	}

	public void AddFlightSchedule(int shipId, FlightSchedule flightSchedule, bool isInit = false)
	{
		int num = Flights.FindIndex((FlightEntity flight) => flight.Id == shipId);
		if (num != -1 && Flights[num].StartTime == flightSchedule.StartTime)
		{
			return;
		}
		Ship byId = ShipManager.GetById(shipId);
		Island islandById = MapDataManager.GetIslandById($"{byId.Details.StayIslandId}");
		if (islandById != null && byId != null)
		{
			if (byId.Details.State == 4)
			{
				islandById.DockingManager?.UndockShip(byId);
			}
			else
			{
				islandById.DockingManager?.DockShip(byId, isInit);
			}
		}
		int[] route = flightSchedule.Route;
		if (route == null || route.Length == 0)
		{
			return;
		}
		NavLineProps[] array = new NavLineProps[route.Length - 1];
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			NavLineProps navLine = MapDataManager.GetNavLine(route[num2], route[num2 + 1]);
			if (navLine == null)
			{
				return;
			}
			array[num2] = navLine;
		}
		FlightEntity flightEntity = new FlightEntity(shipId, flightSchedule.StartTime, flightSchedule.EndTime, array, byId);
		if (num == -1)
		{
			Flights.Add(flightEntity);
		}
		else
		{
			Flights[num] = flightEntity;
		}
	}

	public void Update()
	{
		float num = Time.realtimeSinceStartup - StartUnityTime;
		int curTime = StartManagerTime + (int)num;
		float deltaInSecond = num % 1f;
		for (int num2 = Flights.Count - 1; num2 >= 0; num2--)
		{
			FlightEntity flightEntity = Flights[num2];
			if (flightEntity.Ship != null)
			{
				if (flightEntity.UpdateFlightPos(curTime, deltaInSecond))
				{
					Flights.RemoveAt(num2);
				}
			}
			else
			{
				flightEntity.Ship = ShipManager.GetById(flightEntity.Id);
				Ship ship = flightEntity.Ship;
				if (ship != null)
				{
					ship.ShipObj.SetActive(true);
				}
			}
		}
	}

	public void CreateFakeSchedule(int shipId)
	{
		AddFlightSchedule(shipId, new FlightSchedule
		{
			StartTime = (int)(Time.time * 1000f),
			EndTime = (int)((Time.time + (float)Random.Range(10, 20)) * 1000f),
			Route = RandomRoute()
		});
	}

	public int[] RandomRoute()
	{
		int num = Random.Range(3, 7);
		int[] array = new int[num];
		Dictionary<string, IslandProps> islands_Dict = MapDataManager.WorldMapData.Islands_Dict;
		IslandProps islandProps = islands_Dict.ElementAt(Random.Range(0, islands_Dict.Count)).Value;
		for (int i = 0; i < num; i++)
		{
			array[i] = islandProps.Id;
			int num2 = islandProps.Conn[Random.Range(0, islandProps.Conn.Count)];
			islandProps = islands_Dict[$"{num2}"];
		}
		return array;
	}

	public int[] RandomRoute(string startId)
	{
		int num = Random.Range(5, 7);
		int[] array = new int[num];
		Dictionary<string, IslandProps> islands_Dict = MapDataManager.WorldMapData.Islands_Dict;
		IslandProps islandProps = islands_Dict[startId];
		for (int i = 0; i < num; i++)
		{
			array[i] = islandProps.Id;
			int num2 = islandProps.Conn[Random.Range(0, islandProps.Conn.Count)];
			islandProps = islands_Dict[$"{num2}"];
		}
		return array;
	}
}
