using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    private float currentSpeed;
    private GameObject currentTarget;

    // Use this for initialization
    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D()
    {
        Debug.Log(name + " trigger enter");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from animator at the time of actual hit
    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name + " caused damage: " + damage);
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

}
