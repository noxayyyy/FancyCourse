using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	public float[] leaderBoard = new float[5];
	public GameData()
	{
		for(int i = 0; i < 5; i++)
			this.leaderBoard[i] = 0;
	}
}
