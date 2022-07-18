using UnityEngine;

public class GameObjectAndComponents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Encontrando GameObjects (somente ativos)
        GameObject scriptsObject = GameObject.Find("Scripts");
        GameObject cubeObject = GameObject.FindWithTag("Cube");
        GameObject[] sphereObjects = GameObject.FindGameObjectsWithTag("Sphere");

        bool hasCubeTag = this.gameObject.CompareTag("Cube");
        hasCubeTag = cubeObject.CompareTag("Cube");

        //Ativando e desativando GameObjects
        this.gameObject.SetActive(false);
        //Checar se o objeto esta ativo na hierarquia
        bool isActive = this.gameObject.activeInHierarchy;

        //Desativava todos os filhos
        //gameObject.SetActiveRecursively(false); //[deprecated]
        //checa se esta ativo unitariamente
        //gameObject.active = false; //[deprecated]

        //-----------------------------------------------------

        //Encontrando Componentes dos GameObjects
        HealthComponent cubeHealthComponent = (HealthComponent)cubeObject.GetComponent("HealthComponent");
        cubeHealthComponent.CurrentHealth = 10;

        HealthComponent myHealthComponent = this.gameObject.GetComponent<HealthComponent>();
        myHealthComponent.CurrentHealth = 10; //Null ref

        if (this.gameObject.TryGetComponent<HealthComponent>(out var healthComponent2))
        {
            healthComponent2.MaxHealth = 12;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
