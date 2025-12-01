using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    Enemy enemy;
    public GameObject Maiz;
    public GameObject DeathEffec;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            enemy.healthPoints -= 2f;
            if(enemy.healthPoints <= 0)
            {
                Destroy(gameObject);
                Instantiate(DeathEffec, transform.position, Quaternion.identity);
                //Instantiate(Maiz, transform.position, Quaternion.identity);
            }
        }
    }
}