using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	Transform Player;
	[SerializeField]
	int Difference;
	Vector3 TempPos;
	[SerializeField]
	float MinX, MaxX;

	// Start is called before the first frame update
	void Start()
	{
		Player = GameObject.FindWithTag("Player").transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		TempPos = transform.position;
		TempPos.x = Player.position.x - Difference;
		TempPos.y = Player.position.y;
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
