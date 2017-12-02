using System;
using UnityEngine;

public class Location {


	private readonly int _x;
	private readonly int _y;
	private float _v;
	
	public Location(int x, int y){
		_x = x;
		_y = y;
		_v = 0;
	}

	public int X(){return _x;}
	public int Y(){return _y;}
	public float V(){return _v;}
	
	public void AddV(float f){
		_v += f;
	//	Debug.Log("NewV on: " + ToString());
	}

	public bool IsDirection(){
		return _x != 0 ^ _y != 0;
	}
	
	protected bool Equals(Location other){
		return _x == other.X() && _y == other.Y(); //base.Equals(other) && 
	}

	public override bool Equals(object obj){
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != this.GetType()) return false;
		return Equals((Location) obj);
	}

	public override int GetHashCode(){
		unchecked{
			//int hashCode = base.GetHashCode();
			return 397 ^ _x + 54 ^ _y; //+ 33 ^ (int) Math.Round(_v, 3);
		}
	}

	public override string ToString(){
		return "[" + _x + "|" + _y + "] V: " + _v;
	}
}
