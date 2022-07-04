using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CamScreenShot : MonoBehaviour
{
    private string directoryLink;
    public GameObject canvas;
    public RawImage Rimage;
    [SerializeField] public InputField inputField;


    void Start()
    {
        //caminho do diretorio da pasta
        directoryLink = Application.dataPath + "/capturas/";
        
        //verifica se o diretorio n�o existe
        if (!Directory.Exists(directoryLink))
        {
            Directory.CreateDirectory(directoryLink);
        }
    }

    void Update()
    {
        ScreenShot();
    }


    public void ScreenShot()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(VerifyStatusCanvas());
        }
    }

    IEnumerator VerifyStatusCanvas()
    {
            

            Debug.Log("Desativei");
            canvas.SetActive(false);

            Debug.Log("Tirei Print");
            //string nomeImagem = directoryLink + inputField.text.Trim() + ".png";
            string nomeImagem = directoryLink + "Teste1.png";
            ScreenCapture.CaptureScreenshot(nomeImagem);
            yield return new WaitForSeconds(0.1f);

            Debug.Log("Ativei");
            canvas.SetActive(true);
    }

}
