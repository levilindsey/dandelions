using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionSpawner : MonoBehaviour
{
    // Dandelions per square meter.
    public float density = 0.01f;

    public int minX = -400;
    public int minZ = -400;
    public int maxX = 400;
    public int maxZ = 400;

    public GameObject dandelionPrefab;

    private Vector3[] initialPositionOverrides = new Vector3[]
    {
        new Vector3(0, 36.55f, 5),
    };

    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector3 location in initialPositionOverrides)
        {
            SpawnDandelion(ClampPositionToTerrain(location));
        }

        int count = (int) ((maxX - minX) * (maxZ - minZ) * density);
        for (int i = 0; i < count; i++)
        {
            SpawnDandelion(GetRandomSpawnPosition());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnDandelion(Vector3 location)
    {
        Instantiate(dandelionPrefab, location, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.value * (maxX - minX) + minX;
        float z = Random.value * (maxZ - minZ) + minZ;
        float y = 0;
        Vector3 location = new Vector3(x, y, z);
        return ClampPositionToTerrain(location);
    }

    Vector3 ClampPositionToTerrain(Vector3 position)
    {
        position.y = Terrain.activeTerrain.SampleHeight(position);
        return position;
    }
}
