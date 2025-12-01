using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] public float cantidadPuntos; 
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField] public bool dobleJump = false;
    [SerializeField] public bool swim = false;  
    [SerializeField] public bool climb = false; 
    public static MainController Instance;

    private void Awake()
    {
        if(MainController.Instance == null)
        {
            MainController.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(float puntos)
    {
        cantidadPuntos += puntos;
    }
}
