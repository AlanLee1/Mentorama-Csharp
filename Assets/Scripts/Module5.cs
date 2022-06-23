using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Module5 : MonoBehaviour
{
    [SerializeField] GameObject cubePrefabBorder;
    [SerializeField] GameObject cubePrefabMiddle;
    List<GameObject> allCubes = new List<GameObject>();
    [SerializeField] int terrainSize;
    [SerializeField] int limit = 5;

    void Start()
    {
        for (int column = 0; column < terrainSize; column++)
        {
            for (int line = 0; line < terrainSize; line++)
            {
                if (column == 0 || line == 0 || line == terrainSize - 1 || column == terrainSize - 1)
                {
                    //borda
                    StartCoroutine(InstantiatePrefab(cubePrefabBorder, limit, line, column));
                } else
                {
                    //meio
                    int random = Random.Range(1, 5);
                    StartCoroutine(InstantiatePrefab(cubePrefabMiddle, random, line, column));
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveFirstAndLast();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(RemoveCubesTopPosition());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(RemoveAllCubes());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //Instanciar objeto na cena conforme a posição passada
    IEnumerator InstantiatePrefab(GameObject cube, int limit, int line, int column)
    {
        for (int height = 0; height < limit; height++)
        {
            allCubes.Add(Instantiate(cube, new Vector3(line, height, column), Quaternion.identity));
            yield return new WaitForSeconds(.03f);
        }
    }

    //Remove all cubes from top in position y
    IEnumerator RemoveCubesTopPosition()
    {
        for (int i = 0; i < allCubes.Count; i++)
        {
            if (allCubes[i].transform.position.y == limit - 1)
            {
                Destroy(allCubes[i]);
                allCubes.Remove(allCubes[i]);
                i--;
                yield return new WaitForSeconds(.06f);
            }

        }
        limit--;
    }

    //Remove all cubes
    IEnumerator RemoveAllCubes()
    {
        for (int i = 0; i < allCubes.Count; i++)
        {
            Destroy(allCubes[i]);
            allCubes.Remove(allCubes[i]);
            i--;
            yield return new WaitForSeconds(.03f);
        }
    }

    //Remove first and last cube
    public void RemoveFirstAndLast()
    {
        Destroy(allCubes[0]);
        allCubes.Remove(allCubes[0]);

        Destroy(allCubes[allCubes.Count - 1]);
        allCubes.Remove(allCubes[allCubes.Count - 1]);
    }

}
