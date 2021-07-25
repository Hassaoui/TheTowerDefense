using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turret : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public float range = 10f;
    public float shotPerSec = 2f;
    private float fireCountDown = 0;
    private float fireRate;

    public int Cout = 30;

    public GameObject bulletPrefab;
   

    private string EnemyTag = "Enemy";

    public LineRenderer lazer;
    public float DmgLaser = 0f;

    [Header("BruBru")]
    public bool mulipleFirePoint = false;

    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    private int firepoint = 1;

    private Animator mAnimator = null;
    public GameObject rangeImage;


    [Header("Bullet Stat")]
    public float dmgDeal = 50;
    public float explosionRadius = 0f;
    public float burnPerSec = 0f;
    public float timeBurn = 0f;
    public float slow = 5f;


    void Start()
    {
        fireRate = 1 /  shotPerSec;
        mAnimator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy!=null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(lazer != null)
			{
                if (lazer.enabled)
                {
                    lazer.enabled = false;
                    mAnimator.SetBool("shoot",true);
                }
            }
            
            return;
        }

        if (fireCountDown <= 0 && lazer == null)
        {
            StartCoroutine(AnimShoot());
        }

        if (mulipleFirePoint)
        {
            if (fireCountDown <= 0)
            {
                if (firepoint == 1)
                {
                    ShootBruBru(firePoint);
                }
                if (firepoint == 2)
                {
                    ShootBruBru(firePoint2);
                }
                if (firepoint == 3)
                {
                    ShootBruBru(firePoint3);
                    firepoint = 0;
                }
                fireCountDown = 1f / shotPerSec;
                firepoint++;
            }
            fireCountDown -= Time.deltaTime;
            return;
        }

        if (lazer != null)
        {
            laser();
            return;
        }
        else
        {
            
            if (fireCountDown <= 0)
            {
                Shoot();
                fireCountDown = 1f / shotPerSec;
            }
            
            fireCountDown -= Time.deltaTime;
        }
        
    }

    void laser()
    {
        mAnimator.SetBool("shoot", true);
        target.GetComponent<enemy>().takeDmg(DmgLaser * Time.deltaTime);
        if (!lazer.enabled)
            lazer.enabled = true;
        lazer.SetPosition(0, firePoint.position);
        lazer.SetPosition(1, target.position);
    }
    
    void Shoot()
    {
        
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();
        bulletGO.GetComponent<SetUpbullet>().SetItUp(dmgDeal, explosionRadius, burnPerSec, slow, timeBurn);
        if (bullet != null)
            bullet.seek(target);
    }

    void ShootBruBru(Transform Point)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, Point.position, Point.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();
        bulletGO.GetComponent<SetUpbullet>().SetItUp(dmgDeal, explosionRadius, burnPerSec, slow, timeBurn);
        if (bullet != null)
            bullet.seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

   public int GetCoutTurret()
    {
        return Cout;
    }


    IEnumerator AnimShoot()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                mAnimator.SetBool("shoot", true);
            }
            if (i == 1)
            {
                mAnimator.SetBool("shoot", false);
            }
            yield return new WaitForSeconds(fireRate * 0.9f);
        }
    }

    public void DestroyTurret()
    {
        Destroy(gameObject);
    }

    public void SetRange()
    {
        rangeImage.SetActive(true);
    }

    public void StopRange()
    {
        rangeImage.SetActive(false);
    }
}
