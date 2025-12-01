using UnityEngine;

public class CredistsController : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true); // Muestra el panel
    }

    public void Close()
    {
        gameObject.SetActive(false); // Muestra el panel
    }
}
