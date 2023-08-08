using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEndWall : ObstacleParent
{
	private static new int value;
	public static new string wallName = "EndWall";

	// INHERITANCE
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
		value = 5;
	}

}
