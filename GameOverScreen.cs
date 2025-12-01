using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text puntosText;
    public void Setup()
    {
        puntosText.text = "Puntos: " + MainController.Instance.cantidadPuntos;
        gameObject.SetActive(true); // Muestra el panel
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Nivel1");
        MainController.Instance.cantidadPuntos = 0;
        MainController.Instance.dobleJump = false;
        MainController.Instance.swim = false;
        MainController.Instance.climb = false;

    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
        MainController.Instance.cantidadPuntos = 0;
        MainController.Instance.dobleJump = false;
        MainController.Instance.swim = false;
        MainController.Instance.climb = false;
    }
}
