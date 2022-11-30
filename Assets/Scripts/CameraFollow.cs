using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	Transform Player;
	[SerializeField]
	int Xdifference, Ydifference;
	Vector3 TempPos;
	[SerializeField]
	float MinX, MaxX;

	// Start is called before the first frame update
	void Start()
	{
		Player = GameObject.FindWithTag("Player").transform;
	}

	void LateUpdate()
	{
		TempPos = transform.position;
		TempPos.x = Player.position.x - Xdifference;
		TempPos.y = Player.position.y + Ydifference;
		if(TempPos.x > MaxX)
		{
			TempPos.x = MaxX;
		}
		else if (TempPos.x < MinX)
		{
			TempPos.x = MinX;
		}
		transform.position = TempPos;
		
	}
}
