using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            MainController.Instance.health -= 20f;
            Debug.Log("Damaged player");
        }
    }

    private void OnEnable() {
        Invoke(nameof(StopAttack), .4f);
    }

    void StopAttack() {
        gameObject.SetActive(false);
        Debug.Log("Weapon disabled");
    }
}
