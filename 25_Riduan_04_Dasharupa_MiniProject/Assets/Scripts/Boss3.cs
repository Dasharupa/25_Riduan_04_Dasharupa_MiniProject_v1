using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    private Transform player;
    public float moveSpeed;
    public float lineOfSite;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private float nextFireTime;

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
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        float distaceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distaceFromPlayer < lineOfSite && distaceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        else if (distaceFromPlayer <= shootingRange && nextFireTime <Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
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

        void Dead()
        {
            Destroy(gameObject);
        }
    }

}
