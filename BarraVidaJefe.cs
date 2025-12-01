using UnityEngine;
using UnityEngine.UI;

public class BarraVidaJefe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image rellenoBarraVida;
    public BossController boss;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarraVida.fillAmount = boss.health / 100;
    }
}
