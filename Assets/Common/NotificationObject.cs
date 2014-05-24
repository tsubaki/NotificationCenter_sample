using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class NotificationObject<T> 
{
	public delegate void NotificationAction(T t);
	private T data;
	
	public NotificationObject(T t)
	{
		Value = t;
	}
	
	public NotificationObject(){}
	
	~NotificationObject()
	{
		Dispose();
	}
	
	public event NotificationAction action;
	public event NotificationAction changed {
		add {
			action += value;
			
		}
		remove {
			action -= value;
		}
	}
	
	public T Value
	{
		get{
			return data;
		}
		set{
			data = value;
			Notice ();
		}
	}
	
	private void Notice ()
	{
		if (action != null)
			action (data);
	}
	
	public void Dispose ()
	{
		action = null;
	}
}