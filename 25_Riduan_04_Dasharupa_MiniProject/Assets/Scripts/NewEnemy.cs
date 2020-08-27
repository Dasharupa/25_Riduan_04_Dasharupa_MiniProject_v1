using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    private Transform player;
    public float moveSpeed;

    [Tooltip("Damage on player on touch")]
    public int ContactDamage;

    [Tooltip("Health of the enemy")]
    public int HealthPoint;

    [Tooltip("Score reward for destorying enemy")]
    public int ScoreReward;

    [Tooltip("Sound upon death")]
    public AudioClip DeathAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            BulletScript bulletScript = collision.gameObject.GetComponent<BulletScript>();
            HealthPoint -= bulletScript.BulletDamage;

            Destroy(bulletScript.gameObject);
            if (HealthPoint <= 0)
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}
