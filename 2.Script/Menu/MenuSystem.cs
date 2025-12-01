using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CredistsController CredistsController;
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
        Debug.Log("Jugando...");
    }

    // Update is called once per frame
    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public void Creditos()
    {
        CredistsController.Setup();
    }
}
