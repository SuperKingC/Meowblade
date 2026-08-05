using System;
using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Helpers;
using UnityEngine;

public class InputProcessorSystem : IExecuteSystem, ISystem, ICleanupSystem
{
	private InputContext _context;

	private TouchCreator _fakeTouch0;

	private TouchCreator _fakeTouch1;

	private List<Touch> _touches;

	public InputProcessorSystem(Contexts contexts)
	{
		_context = contexts.input;
		_touches = new List<Touch>();
		if (_fakeTouch0 == null)
		{
			_fakeTouch0 = new TouchCreator();
		}
		if (_fakeTouch1 == null)
		{
			_fakeTouch1 = new TouchCreator();
		}
	}

	public void Execute()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		_touches.Clear();
		if (Input.touchCount > 0)
		{
			_touches.AddRange(Input.touches);
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (Math.Abs(axis) > 0.001f)
		{
			_context.ReplaceMouseScrollDelta(0f - axis);
		}
		if (!Input.touchSupported && Input.GetMouseButton(0))
		{
			Resolution currentResolution = Screen.currentResolution;
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector((float)((Resolution)(ref currentResolution)).width, (float)((Resolution)(ref currentResolution)).height);
			bool flag = Input.GetKey((KeyCode)308) || Input.GetKey((KeyCode)307);
			if (Input.GetMouseButtonDown(0))
			{
				_fakeTouch0.phase = (TouchPhase)0;
				_fakeTouch0.deltaPosition = Vector2.zero;
				_fakeTouch0.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				_fakeTouch0.fingerId = 0;
				_touches.Add(_fakeTouch0.Create());
				if (flag)
				{
					_fakeTouch1.phase = (TouchPhase)0;
					_fakeTouch1.deltaPosition = Vector2.zero;
					_fakeTouch1.position = val - _fakeTouch0.position;
					_fakeTouch1.fingerId = 1;
					_touches.Add(_fakeTouch1.Create());
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				_fakeTouch0.phase = (TouchPhase)3;
				Vector2 val2 = default(Vector2);
				((Vector2)(ref val2))._002Ector(Input.mousePosition.x, Input.mousePosition.y);
				_fakeTouch0.deltaPosition = val2 - _fakeTouch0.position;
				_fakeTouch0.position = val2;
				_fakeTouch0.fingerId = 0;
				_touches.Add(_fakeTouch0.Create());
				if (flag)
				{
					_fakeTouch1.phase = (TouchPhase)3;
					_fakeTouch1.deltaPosition = -_fakeTouch0.deltaPosition;
					_fakeTouch1.position = val - _fakeTouch0.position;
					_fakeTouch1.fingerId = 1;
					_touches.Add(_fakeTouch1.Create());
				}
			}
			else if (Input.GetMouseButton(0))
			{
				_fakeTouch0.phase = (TouchPhase)1;
				Vector2 val3 = default(Vector2);
				((Vector2)(ref val3))._002Ector(Input.mousePosition.x, Input.mousePosition.y);
				_fakeTouch0.deltaPosition = val3 - _fakeTouch0.position;
				_fakeTouch0.position = val3;
				_fakeTouch0.fingerId = 0;
				_touches.Add(_fakeTouch0.Create());
				if (flag)
				{
					_fakeTouch1.phase = (TouchPhase)1;
					_fakeTouch1.deltaPosition = -_fakeTouch0.deltaPosition;
					_fakeTouch1.position = val - _fakeTouch0.position;
					_fakeTouch1.fingerId = 1;
					_touches.Add(_fakeTouch1.Create());
				}
			}
		}
		_context.ReplaceTouches(_touches.Count, _touches);
		if (_touches.Count == 2)
		{
			Touch val4 = _touches[0];
			Touch val5 = _touches[1];
			Vector2 val6 = ((Touch)(ref val4)).position - ((Touch)(ref val4)).deltaPosition;
			Vector2 val7 = ((Touch)(ref val5)).position - ((Touch)(ref val5)).deltaPosition;
			Vector2 val8 = val6 - val7;
			float magnitude = ((Vector2)(ref val8)).magnitude;
			val8 = ((Touch)(ref val4)).position - ((Touch)(ref val5)).position;
			float magnitude2 = ((Vector2)(ref val8)).magnitude;
			float num = magnitude - magnitude2;
			_context.ReplaceZoomDelta(num * 0.005f);
		}
	}

	public void Cleanup()
	{
		if (_context.hasMouseScrollDelta)
		{
			_context.RemoveMouseScrollDelta();
		}
		if (_context.hasZoomDelta)
		{
			_context.RemoveZoomDelta();
		}
	}
}
