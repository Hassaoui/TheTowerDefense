using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpbullet : MonoBehaviour
{
    
    private float dmgDeal = 50;
    private float explosionRadius = 0f;
    private float burnPerSec = 0f;
    private float timeBurn;
    private bool isBurningBullet = false;
    private bool canSlow = false;
    private float slow = 5f;


    public void SetItUp(float _dmgDeal ,float _explosionRadius, float _burnPerSec, float _slow, float _timeBurn)
	{
        dmgDeal = _dmgDeal;
        explosionRadius = _explosionRadius;
        burnPerSec = _burnPerSec;
        slow = _slow;
        timeBurn = _timeBurn;
        if (slow != 0)
            canSlow = true;
        if (burnPerSec != 0)
            isBurningBullet = true;

	}

    public void hitTarget(Transform target)
    {
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider2D[] InRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D  collider in InRange)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void Damage(Transform enemy)
    {
        enemy e = enemy.GetComponent<enemy>();

        e.takeDmg(dmgDeal);
        if(canSlow)
            e.slow(slow);
        if(isBurningBullet)
            e.burn(burnPerSec, timeBurn);
    }
}
