[System.Serializable]
public class GameData
{
	public float[] leaderBoard = new float[6];
	public int attempts;
	public GameData()
	{
		for(int i = 0; i < 6; i++)
			leaderBoard[i] = 0;
		attempts = 0;
	}
}
