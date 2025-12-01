using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportAgua : MonoBehaviour
{
    public string scena;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && MainController.Instance.swim){
                SceneManager.LoadScene(scena);
        }
        else
        {
            MainController.Instance.health -= 10;
        }
    }
}
