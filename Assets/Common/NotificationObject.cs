using UnityEngine;
using System.Collections;
using System;

public class NotificationObject<T> : IDisposable   where T : System.IComparable
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
	
	public event NotificationAction changed;
	
	public T Value
	{
		get{
			return data;
		}
		set{
			if( data.CompareTo(value) != 0)
			{
				data = value;
				Notice ();
			}
		}
	}
	
	private void Notice ()
	{
		if (changed != null)
			changed (data);
	}
	
	public void Dispose ()
	{
		changed = null;
	}
}