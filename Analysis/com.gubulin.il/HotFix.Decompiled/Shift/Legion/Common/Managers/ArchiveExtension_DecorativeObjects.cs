using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using ProtoBuf;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_DecorativeObjects
{
	public class Model
	{
		public Dictionary<string, DecorativeObjects> DOs = new Dictionary<string, DecorativeObjects>();

		public string Cur_AvatarFrame { get; set; }

		public string Cur_Title { get; set; }

		public string Cur_Nameplate { get; set; }
	}

	[ProtoContract]
	public class ListDecorativeObjects
	{
		[ProtoMember(1, TypeName = "Shift.Legion.Common.Managers.ArchiveExtension_DecorativeObjects/DecorativeObjects")]
		public List<DecorativeObjects> List = new List<DecorativeObjects>();

		[ProtoMember(2)]
		public string Cur { get; set; }
	}

	[ProtoContract]
	public class DecorativeObjects
	{
		[ProtoMember(1)]
		public string Id { get; set; }

		[ProtoMember(2)]
		public int Type { get; set; }

		[ProtoMember(3)]
		public int State { get; set; }

		[ProtoMember(4)]
		public int ExpiredTime { get; set; }

		public DecorativeObjects()
		{
		}

		public DecorativeObjects(GDEDecorativeObjectsData data)
		{
			Id = data.Key;
			Type = data.Type;
		}

		public void Refresh()
		{
			if (State == 1 && DateTimeHelper.GetTimeStamp(DateTimeHelper.Now) > ExpiredTime)
			{
				State = 0;
			}
		}

		public bool SetState(State _state, int _expired_time)
		{
			switch (_state)
			{
			case ArchiveExtension_DecorativeObjects.State.Disable:
			case ArchiveExtension_DecorativeObjects.State.Expired:
			case ArchiveExtension_DecorativeObjects.State.Permanent:
				State = (int)_state;
				ExpiredTime = 0;
				return true;
			case ArchiveExtension_DecorativeObjects.State.Enable:
				if (_expired_time < DateTimeHelper.GetTimeStamp(DateTimeHelper.Now))
				{
					State = 0;
					ExpiredTime = 0;
					return false;
				}
				State = (int)_state;
				ExpiredTime = _expired_time;
				return true;
			default:
				Refresh();
				return false;
			}
		}
	}

	public enum State
	{
		Disable,
		Enable,
		Expired,
		Permanent
	}

	public enum Type
	{
		Title = 1,
		AvatarFrame,
		Nameplate
	}

	private const string DecorativeObjectsKey = "DECORATIVE_OBJECTS";

	public static bool AddDecorativeObjects(this UserArchiveManager manager, string title_id, State state, int expiredtime = 0)
	{
		GDEDecorativeObjectsData gDEDecorativeObjectsData = GDMgr.Get<GDEDecorativeObjectsData>(title_id);
		if (gDEDecorativeObjectsData == null)
		{
			return false;
		}
		Model decorativeObjectsModel = manager.GetDecorativeObjectsModel();
		if (!decorativeObjectsModel.DOs.TryGetValue(title_id, out var value))
		{
			value = new DecorativeObjects(gDEDecorativeObjectsData);
			decorativeObjectsModel.DOs.Add(title_id, value);
		}
		value.SetState(state, expiredtime);
		value.Refresh();
		manager.SetDecorativeObjectsModel(decorativeObjectsModel);
		return true;
	}

	public static DecorativeObjects GetDecorativeObjects(this UserArchiveManager manager, string Id)
	{
		Model decorativeObjectsModel = manager.GetDecorativeObjectsModel();
		if (decorativeObjectsModel.DOs.Values.Count > 0)
		{
			return decorativeObjectsModel.DOs?.Values.First((DecorativeObjects _do) => _do?.Id == Id);
		}
		return null;
	}

	public static ListDecorativeObjects GetDecorativeObjects(this UserArchiveManager manager, int type)
	{
		Model decorativeObjectsModel = manager.GetDecorativeObjectsModel();
		ListDecorativeObjects listDecorativeObjects = new ListDecorativeObjects();
		if (decorativeObjectsModel.DOs.Values.Count > 0)
		{
			listDecorativeObjects.List = decorativeObjectsModel.DOs.Values.Where((DecorativeObjects _do) => _do != null && _do.Type == type)?.ToList();
		}
		return listDecorativeObjects;
	}

	public static Model GetDecorativeObjectsModel(this UserArchiveManager manager)
	{
		Model model = manager.GetConfigValue<Model>("DECORATIVE_OBJECTS");
		if (model == null)
		{
			model = new Model();
			if (model.DOs == null)
			{
				model.DOs = new Dictionary<string, DecorativeObjects>();
			}
			manager.SetConfigValue("DECORATIVE_OBJECTS", model);
		}
		return model;
	}

	public static void SetDecorativeObjectsModel(this UserArchiveManager manager, Model _model)
	{
		manager.SetConfigValue("DECORATIVE_OBJECTS", _model);
	}
}
