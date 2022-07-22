using UnityEngine;

public class GameObjectAndComponents : MonoBehaviour
{

    public GameObject GameObjectPrefab;
    public HealthComponent HealthComponentPrefab;

    void Start()
    {
        //Encontrando Game Objects (somente ativos)
        //encontrar o objeto pelo nome do objeto
        GameObject scriptsObject = GameObject.Find("Scripts");
        //encontrar o objeto pela TAG
        GameObject cubeObject = GameObject.FindWithTag("Cube");
        //encontrar todos objetos pela TAG
        GameObject[] sphereObjects = GameObject.FindGameObjectsWithTag("Sphere");

        //Objeto do proprio script vinculado

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
        // myHealthComponent.CurrentHealth = 10; //Null ref


        //verifica se o componente existe, se não crie
        if (cubeObject.TryGetComponent<HealthComponent>(out var healthComponent2))
        {
            healthComponent2.MaxHealth = 12;
        }

        //Setup
        var allSpheresObject = GameObject.Find("AllSpheres");
        var lastActiveSphere = sphereObjects[sphereObjects.Length - 1]; //sphere (3)

        //Components em filhos e parentes. Caso queira pegar os objetos desativados, colocar true
        HealthComponent componentInChildren = allSpheresObject.GetComponentInChildren<HealthComponent>(false); //default false
        HealthComponent componentInParent = lastActiveSphere.GetComponentInParent<HealthComponent>(false);



    }

    // Update is called once per frame
    void Update()
    {

    }
}
