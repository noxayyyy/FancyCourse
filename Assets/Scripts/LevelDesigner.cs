using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Unity.UI;
using UnityEngine.Networking;

public class LevelDesigner : MonoBehaviour
{
	public static string levelName;
	public Colour2Prefab bgPrefab;
	public Colour2Prefab[] colourMappings;
	Texture2D map;

	private void Awake()
	{

	}

	// Start is called before the first frame update
	void Start()
	{
		Texture2D copy = (Texture2D)Resources.Load("Levels/" + levelName); 
		map = duplicateTexture(copy);
		GenerateLevel();
	}

	// Update is called once per frame
	void Update()
	{
		
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
		for(int i = 0; i < map.width; i++)
		{
			for (int j = 0; j < map.height; j++)
				GenerateTile(i,j);
		}
	}

	void GenerateTile(int x, int y)
	{
		Color pixelColour = map.GetPixel(x,y);
		Vector2 position = new Vector2(x,y);
		Instantiate(bgPrefab.prefab, position, Quaternion.identity, transform);

		if (pixelColour.a == 0)
			return;

		foreach (Colour2Prefab colourMapping in colourMappings)
		{
			if (colourMapping.colour.Equals(pixelColour))
			{
				Vector2 colourPosition = new Vector2(x,y);
				Instantiate(colourMapping.prefab, colourPosition, Quaternion.identity, transform);
			}
		}
	}
}