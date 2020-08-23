using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    Move2D Player;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<Move2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

}
