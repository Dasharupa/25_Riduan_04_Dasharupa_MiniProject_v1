using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 7f;
    public bool isGrounded = false;
    public Animator animator;
    public GameObject bulletToRight, bulletToLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    bool facingRight = true;
    float velX;
    float velY;
    int click = 0;
    public float Health;
    public GameObject Player;

    [Tooltip("Damage on enemy on each hit")]
    public int ShootingDamage;

    [Tooltip("Starting health of the enemy")]
    public int HealthPoint;

    [Tooltip("Player bullet prefeb")]
    public GameObject PlayerBullet;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        animator.SetFloat("moveSpeed", moveSpeed);
        animator.SetInteger("Click", click);

        if (HealthPoint <= 0)
        {
            SceneManager.LoadScene(4);
        }

        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -0.7f;
            facingRight = false;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 0.7f;
            facingRight = true;
        }
        transform.localScale = characterScale;

        if(Input.GetButtonDown("Fire1") && characterScale.x == 0.7f)
        {           
            fire();
            click = 1;
        }
        else
        {
            click = 0;
        }

        if (Input.GetButtonDown("Fire1") && characterScale.x == -0.7f)
        {
            fire2();
            click = 1;
        }
        else
        {
            click = 0;
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        if(Input.GetKey("a") || Input.GetKey("d"))
        {
            moveSpeed = 7f;
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        else
        {
            moveSpeed = 0f;
        }
    }

    void fire()
    {
        bulletPos = transform.position;
        if(facingRight == true)
        {
            bulletPos += new Vector2(+1.5f, +0.8f);
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
        }
        else
        {
            bulletPos += new Vector2(1f, 0.8f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        }
    }

    void fire2()
    {
        if(facingRight == false)
        {
            bulletPos += new Vector2(1f, 0.8f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            NewEnemy EnemyScript = collision.gameObject.GetComponent<NewEnemy>();
            HealthPoint -= EnemyScript.ContactDamage;
            Health -= EnemyScript.ContactDamage;
            GameManager.Instance.UpdateHealth(HealthPoint);
        }

        if (collision.gameObject.tag.Equals("Enemy2"))
        {
            Boss2 EnemyScript = collision.gameObject.GetComponent<Boss2>();
            HealthPoint -= EnemyScript.ContactDamage;
            Health -= EnemyScript.ContactDamage;
            GameManager.Instance.UpdateHealth(HealthPoint);
        }

        if (collision.gameObject.tag.Equals("Enemy3"))
        {
            Boss3 EnemyScript = collision.gameObject.GetComponent<Boss3>();
            HealthPoint -= EnemyScript.ContactDamage;
            Health -= EnemyScript.ContactDamage;
            GameManager.Instance.UpdateHealth(HealthPoint);
        }

        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            EnemyBullet EnemyScript = collision.gameObject.GetComponent<EnemyBullet>();
            HealthPoint -= EnemyScript.ContactDamage;
            Health -= EnemyScript.ContactDamage;
            GameManager.Instance.UpdateHealth(HealthPoint);
        }

        if (collision.gameObject.tag.Equals("EnemyBullet2"))
        {
            HomingBullet EnemyScript = collision.gameObject.GetComponent<HomingBullet>();
            HealthPoint -= EnemyScript.ContactDamage;
            Health -= EnemyScript.ContactDamage;
            GameManager.Instance.UpdateHealth(HealthPoint);
        }

        if (collision.gameObject.tag.Equals("Portal"))
        {
            SceneManager.LoadScene(2);                       
        }

        if (collision.gameObject.tag.Equals("Portal2"))
        {
            SceneManager.LoadScene(3);
        }

    }
}
