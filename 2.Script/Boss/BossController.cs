using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    Animator animator;
    public GameObject weapon;
    public GameObject deathEffect;
    public float health;
    bool canAttack = true;
    Vector3[] teleports;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        teleports = new Vector3[]{
            new Vector3( 0.0f,  2.5f,  0.0f),
            new Vector3(-4.5f,  0.5f,  0.0f),
            new Vector3( 4.5f,  0.5f,  0.0f),
            new Vector3( 0.0f, -1.5f,  0.0f),
            new Vector3(-6.5f, -3.5f,  0.0f),
            new Vector3( 6.5f, -3.5f,  0.0f)
        };
        Debug.Log("debuging");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player") && canAttack) {
            transform.localScale = new Vector3(3, 3, 0);
            animator.Play("weapon_swing");
            Invoke(nameof(Attack), .6f);
            canAttack = false;
        }

        if (other.CompareTag("Weapon")) {
            health -= 10f;

            if (health <= 0f) {
                Destroy(gameObject);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                SceneManager.LoadScene("Menu");
            } else {
                Teleport();
            }
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            //animator.Play("weapon_walk");
        }
    }

    void Attack() {
        weapon.SetActive(true);
    }

    void Teleport() {
        int tp_pos;
        do {
            tp_pos = Random.Range(0, 5);
        } while (transform.position == teleports[tp_pos]);
        transform.localScale = new Vector3(1.5f, 1.5f, 0f);
        transform.position = teleports[tp_pos];
        canAttack = true;
    }
}
