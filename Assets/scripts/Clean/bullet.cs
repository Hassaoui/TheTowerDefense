using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	private Transform target;
	private Rigidbody2D rb;
    private SetUpbullet dmgDealer;
    public float speed = 6f;

	public void Start()
	{
        dmgDealer = this.GetComponent<SetUpbullet>();
		rb = this.GetComponent<Rigidbody2D>();
	}

	public void seek(Transform _target)
	{
		target = _target;
	}

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distanceThisFrame = speed * Time.deltaTime;
        Vector2 dir = SuivreEnemy();

        if (dir.magnitude <= distanceThisFrame)
        {
            dmgDealer.hitTarget(target);
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    Vector2 SuivreEnemy()
    {
        Vector2 dir = target.position - transform.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        rb.rotation = angle;

        return dir;
    }
}
