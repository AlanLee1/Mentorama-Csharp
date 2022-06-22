using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module3 : MonoBehaviour
{
    [Header("Variables")]
    [Range(0f,1f)] public float life = 1;
    [SerializeField] public float force;
    [SerializeField] public float speed = 1.5f;
    [SerializeField] public Image lifeImage;

    // Start is called before the first frame update
    void Start()
    {
        force = speed / 100;
        lifeImage.fillAmount = life;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
        VerifyLife();
    }

    public void MoveObject()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Translate(new Vector3(force, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            Translate(new Vector3(-force, 0, 0));

        }

        if (Input.GetKey(KeyCode.A))
        {
            Translate(new Vector3(0, 0, force));
        }

        if (Input.GetKey(KeyCode.D))
        {
            Translate(new Vector3(0, 0, -force));
        }
    }

    public void Translate(Vector3 translation)
    {
        transform.position = transform.position + translation;
        life -= 0.001f;
        lifeImage.fillAmount = life;

    }

    public void VerifyLife()
    {
        if (life <= 0)
        {
            Debug.Log("Morreu");
            Destroy(this.gameObject);
        }
    }
}
