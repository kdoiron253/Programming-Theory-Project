using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRegularWall : ObstacleParent
{
	// INHERITANCE

	public static new string wallName = "RegularWall";
	private static new int value;

	private void Awake()
	{
		Setvalue();
	}

	public static int Getvalue()
	{
		return value;
	}

	private static void Setvalue()
	{
		value = 2;
	}


}
