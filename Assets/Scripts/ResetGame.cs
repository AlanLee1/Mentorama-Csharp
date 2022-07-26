using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Reset Game")]
public class ResetGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
