using UnityEngine;

public class Maiz : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MainController.Instance.SumarPuntos(cantidadPuntos);
            MainController.Instance.health += 10;

            Destroy(gameObject);
        }
    }
}
