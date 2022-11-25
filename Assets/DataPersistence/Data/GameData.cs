[System.Serializable]
public class GameData
{
	public float[] leaderBoard = new float[6];
	public GameData()
	{
		for(int i = 0; i < 6; i++)
			leaderBoard[i] = 0;
	}
}
