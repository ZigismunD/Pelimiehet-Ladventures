using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBananaController : MonoBehaviour
{
    public Transform target;
    private float lastAttackTime;
    public float attackDelay;
    public float attackRange;
    public GameObject projectile;
    public float bananaForce;
    public float timeLevelDone;
    public float startTime;
    public GameObject finalBossExit;

    // Hide the exit and start the boss timer. Target the player.
    void Start()
    {
        finalBossExit.SetActive(false);
        startTime = Time.time;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // After certain cooldown throw the banana towards player
    // If timer fills up reveal the exit
    void Update()
    {

        if (Time.time > startTime + timeLevelDone)
        {
            GameObject.FindObjectOfType<DialogueManager>().finalLevelDone = true;
            finalBossExit.SetActive(true);
        }
        //Check to see if the player is in attack range
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            //Turn towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            // Check to see it is time to attack
            if (Time.time > lastAttackTime + attackDelay)
            {
                // Fire the projectile
                GameObject newBanana = Instantiate(projectile, transform.position, transform.rotation);
                newBanana.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bananaForce));
                lastAttackTime = Time.time;
            }
        }
    }
}
