using UnityEngine;


public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField]private PlayerStats playerStats;

    private PlayerAnimation playerAnimations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
        }
    }

    public void PlayerDead()
    {
        Debug.Log("Jogador Derrotado");
        playerAnimations.SetDeadAnimation();
    }

    // O método encontra-se acessível porque está a ser implementado a partir da interface IDamagable
    public void TakeDamage(float amount)
    {
        playerStats.health -= amount;
        if (playerStats.health <= 0)
        {
            PlayerDead();
        }
    }
}
