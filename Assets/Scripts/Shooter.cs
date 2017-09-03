using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start()
    {
        // Creates a parent if necessary
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        animator = GameObject.FindObjectOfType<Animator>();

        SetMyLaneSpawner();
    }

    void Update()
    {
        animator.SetBool("isAttacking", IsAttackerAheadInLane());
    }

    // Look through all spawners and set myLaneSpawner if found
    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
        {
            if (Mathf.Approximately(spawner.transform.position.y, transform.position.y))
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        // Exit if not attackers in lane
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        // If there are attackers, are they ahead?
        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
