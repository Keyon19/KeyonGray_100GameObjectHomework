using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;

    public Vector3 rotationAxis;
    public float rotationAngle;

    void Start()
    {
        Spawn3DGridPrefabs();
    }

    public void Spawn3DGridPrefabs()
    {
        float spacing = 10;
        for(int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    float x = i * spacing;
                    float y = j * spacing;
                    float z = k * spacing; 
                    GameObject go = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);

                    Renderer rend = go.GetComponent<Renderer>();
                    rend.material.color = GetRandomColor();


                }
            }
        }
    }
    public void SpawnCirclePrefab()
    {
        for (int i = 0; i < 12; i++)
        {
            float x = 5 * Mathf.Cos(2 * Mathf.PI * i / 12);
            float y = 5 * Mathf.Sin(2 * Mathf.PI * i / 12);
            Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity);
            
        }

    }

    public Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(prefab.transform.position, rotationAxis, rotationAngle);
    }

}
