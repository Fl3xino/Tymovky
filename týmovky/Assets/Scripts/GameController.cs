using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private static float health = 6;
    private static int maxHealth = 6;
    private static float moveSpeed = 5;
    private static float fireRate = 0.5f;
    GameObject player;

    public static float Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }

    public Text healthText;

    void Start()
    {
        health = 6;
        moveSpeed = 5;
        fireRate = 0.5f;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        healthText.text = "Health: " + health;
    }

    public static void DamagePlayer(int damage)
    {
        health -= damage;

        if(Health <= 0)
        {
            KillPlayer(GameObject.FindGameObjectWithTag("Player"));
        }

    }

    public static void HealPlayer(float HealAmount)
    {
        health = Mathf.Min(MaxHealth, health + HealAmount);
    }

    public static void MoveChange(float speed)
    {
        moveSpeed += speed;
    }

    public static void AttackSpeedChange(float rate)
    {
        fireRate -= rate;
    }

    private static void KillPlayer(GameObject player)
    {
        Object.Destroy(player);
        SceneManager.LoadScene("Menu");
    }
}
