using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module4_CreateTerrain : MonoBehaviour
{
    [SerializeField] GameObject cubePrefabBorder;
    [SerializeField] GameObject cubePrefabMiddle;
    [SerializeField] int terrainSize;
    void Start()
    {
        for (int column=0; column< terrainSize; column++)
        {
            for (int line=0; line<terrainSize; line++)
            {
                 if (column == 0 || line == 0 || line == terrainSize - 1 || column == terrainSize - 1)
                {
                    //borda
                    InstantiatePrefab(cubePrefabBorder, 5, line, column);
                } else
                {
                    //meio
                    int random = Random.Range(1, 5);
                    InstantiatePrefab(cubePrefabMiddle, random, line, column);
                }
            }
        }
    }
    //Instanciar objeto na cena conforme a posição passada
    public void InstantiatePrefab(GameObject cube ,int limit, int line, int column)
    {
        for (int height = 0; height < limit; height++)
        {
            Instantiate(cube, new Vector3(line, height, column), Quaternion.identity);
        }
    }
}
