using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Necromancer_Controller : MonoBehaviour
{
	public static Necromancer_Controller instance;
	public float speed;
    public SpriteRenderer spriteRenderer;
	public float minX;
	public float maxX;
	public float waitingTime = 0.5f;
	private GameObject _target;
	public string playerTag = "Player";
    public Animator animator;
	public bool stillInside = true;

    void Awake() {
        instance = this;
    }

    void Start()
    {
		animator = gameObject.GetComponent<Animator>();
		UpdateTarget();
		StartCoroutine("PatrolToTarget");
	}

    void Update()
    {
		if(Necromancer_HealthController.instance.currentHealth <= 0) {
			StopCoroutine("PatrolToTarget");
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
			if (collision.CompareTag(playerTag))
            {
                animator.SetFloat("necro_speed", 0);
				StopCoroutine("PatrolToTarget");
				animator.SetBool("player_in", true);
				AudioController.instance.PlaySound(8);
				InvokeRepeating("AttackPlayer", 4f, 1f);
            }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
			AudioController.instance.StopSound(8);
            animator.SetFloat("necro_speed", 1);
			CancelInvoke("AttackPlayer");
			animator.SetBool("player_in", false);
			UpdateTarget();
            StartCoroutine("PatrolToTarget");
        }
    }

	private void UpdateTarget()
	{
			if (_target  == null) {
				_target = new GameObject("Target");
				_target.transform.position = new Vector2(minX, transform.position.y);
				transform.localScale = new Vector3(-1, 1, 1);
				return;
			}

			if (_target.transform.position.x == minX) {
				_target.transform.position = new Vector2(maxX, transform.position.y);
				transform.localScale = new Vector3(1, 1, 1);
			}

			else if (_target.transform.position.x == maxX) {
				_target.transform.position = new Vector2(minX, transform.position.y);
				transform.localScale = new Vector3(-1, 1, 1);
			}
	}

	private IEnumerator PatrolToTarget()
	{
            animator.SetFloat("necro_speed", 1);
			while(Vector2.Distance(transform.position, _target.transform.position) > 0.05f) {
				Vector2 direction = _target.transform.position - transform.position;
				float xDirection = direction.x;
				transform.Translate(direction.normalized * speed * Time.deltaTime);
				yield return null;
			}

			transform.position = new Vector2(_target.transform.position.x, transform.position.y);
			
			yield return new WaitForSeconds(waitingTime);
			UpdateTarget();
			StartCoroutine("PatrolToTarget");
	}

	private void AttackPlayer() {
		if (CharacterHealthController.instance.currentHealth <= 0 || Necromancer_HealthController.instance.currentHealth <= 0) {
			CancelInvoke("AttackPlayer");
		}
		else {
			CharacterHealthController.instance.TakeDamage();
		}
	}

	
}
