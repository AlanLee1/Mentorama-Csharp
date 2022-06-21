using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 26;
        int b = 100;
        int c = 30;
        int maior = 0;

        if (a > b)
        {
            maior = a;
        } else
        {
            maior = b;
        }
        if (c > maior)
        {
            maior = c;
        }

        Debug.Log(maior);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
