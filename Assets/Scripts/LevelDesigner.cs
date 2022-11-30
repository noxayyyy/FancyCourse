using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
	public static string levelName;
	public GameObject bgPrefab, destroyer;
	public Colour2Prefab[] colourMappings;
	Texture2D map;

	// Start is called before the first frame update
	void Start()
	{
		Texture2D copy = (Texture2D)Resources.Load("Levels/" + levelName); 
		map = duplicateTexture(copy);
		GenerateLevel();
	}

	Texture2D duplicateTexture(Texture2D source)
	{
		RenderTexture renderTex = RenderTexture.GetTemporary(
					source.width,
					source.height,
					0,
					RenderTextureFormat.Default,
					RenderTextureReadWrite.Linear);

		Graphics.Blit(source, renderTex);
		RenderTexture previous = RenderTexture.active;
		RenderTexture.active = renderTex;
		Texture2D readableText = new Texture2D(source.width, source.height);
		readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
		readableText.Apply();
		RenderTexture.active = previous;
		RenderTexture.ReleaseTemporary(renderTex);
		return readableText;
	}
	
	void GenerateLevel()
	{
		for(int i = -5; i <= map.width + 5; i++)
		{
			for(int j = -5; j <= map.height + 5; j++)
			{
				Vector2 prefabPosition = new Vector2(i,j);
				Instantiate(bgPrefab, prefabPosition, Quaternion.identity, GameObject.Find("Game BG").transform.GetChild(1).transform);
			}
		}
		for(int i = 0; i < map.width; i++)
		{
			for (int j = 0; j < map.height; j++)
				GenerateTile(i,j);
		}
		GameObject levelBorder = new GameObject();

		levelBorder.transform.parent = gameObject.transform;
		levelBorder.name = "LevelBorder";
		levelBorder.AddComponent<BoxCollider2D>();
		levelBorder.AddComponent<Rigidbody2D>();
		BoxCollider2D borderCollider = levelBorder.GetComponent<BoxCollider2D>();
		Rigidbody2D borderBody = levelBorder.GetComponent<Rigidbody2D>();

		PhysicsMaterial2D mat = new PhysicsMaterial2D(borderCollider.name + "Material");
		mat.friction = 0;
		borderCollider.sharedMaterial = mat;
		borderBody.constraints = RigidbodyConstraints2D.FreezeAll;

		borderCollider.size = new Vector2(1, map.height);
		levelBorder.transform.position = new Vector2(0,map.height/2);
		Vector2 position = new Vector2(map.width,map.height/2);
		Instantiate(levelBorder, position, Quaternion.identity, transform);

		BoxCollider2D destroyerCollider = destroyer.GetComponent<BoxCollider2D>();
		destroyerCollider.size = new Vector2(map.width, 1);
		Vector2 destroyPos = new Vector2(map.width/2, 0);
		Instantiate(destroyer, destroyPos, Quaternion.identity, transform);
	}

	void GenerateTile(int x, int y)
	{
		Color pixelColour = map.GetPixel(x,y);

		if (pixelColour.a == 0)
			return;

		foreach (Colour2Prefab colourMapping in colourMappings)
		{
			if (colourMapping.colour.Equals(pixelColour))
			{
				if (colourMapping.prefab.name == "FinishLine")
				{
					Vector2 colourPosition1 = new Vector2(x,y);
					Instantiate(colourMapping.prefab, colourPosition1, Quaternion.identity, GameObject.Find("FinishLine").transform);
				}
				else
				{
					Vector2 colourPosition = new Vector2(x,y);
					Instantiate(colourMapping.prefab, colourPosition, Quaternion.identity, GameObject.Find("LevelGenerator").transform);
				}
			}
		}
	}
}