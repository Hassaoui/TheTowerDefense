using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speedDeBase = 10f;
    public float health = 0;
    public float slowTime = 10f;
    public float burnTics = 4f;
    public int MoneyDrop = 10;
    public GameObject bloodAnim;
    public GameObject burnAnim;
    public Transform burnPoint;

    //private

    private Rigidbody2D rb;
    private Transform target;
    private bool IsSlow = false;
    private int numberPoints = 0;
    private float burnRate = 0.5f;

    //temp
    float useHealth;
    float speed;
    float useSpeed;


    void Start()
    {
        useHealth = health;
        speed = speedDeBase;
        useSpeed = speed;
       
        rb = this.GetComponent<Rigidbody2D>();
        target = WayPoints.points[0];
        InvokeRepeating("StillSlow", 0f, slowTime);
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * useSpeed * Time.deltaTime, Space.World);
        if(Vector2.Distance(transform.position, target.position)<= 0.1f)
        {
            nextPoint();
        }
    }
    void nextPoint()
    {
        if(numberPoints >= (WayPoints.points.Length - 1))
        {
            PlayerStat.lives--;
            Destroy(gameObject);
            return;
        }
        numberPoints++;
        target = WayPoints.points[numberPoints];
    }

    public void takeDmg(float amount)
    {
        health -= amount;
        Instantiate(bloodAnim, transform.position, transform.rotation);
        if (health <= 0)
        {
            Die();
        }
    }

    public void StillSlow()
    {
        useSpeed = speed;
        IsSlow = false;
    }

    public void slow(float slowAmount)
    {
       if (IsSlow == false ) {
            useSpeed = useSpeed * slowAmount;
            Instantiate(bloodAnim, transform.position, transform.rotation);
            IsSlow = true;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerStat.Money += MoneyDrop;
    }

    public void burn(float dmgPerSec, float timeBurn)
    {
        StartCoroutine(burnOverTime(dmgPerSec, timeBurn));
    }

    IEnumerator burnOverTime (float dmgPerSec, float timeBurn)
    {
        float timeBetweenTic = 0.5f;
        timeBurn = timeBurn / timeBetweenTic;

        for (int i = 0; i < timeBurn; i++)
        {
            Instantiate(burnAnim, burnPoint.position, burnPoint.rotation);
            health -= dmgPerSec;

            if (health <= 0)
            {
                Die();
            }
            yield return new WaitForSeconds(timeBetweenTic);
        }
        
    }

    public void SetNewHealth(float multiplicateur)
    {
        health =  health * multiplicateur;
    }

    public float GetNewHealth()
    {
        return health;
    }

    public void SetNewSpeed(float mutipli)
    {
        speed = speed * mutipli;
        useSpeed = speed;
    }

}
