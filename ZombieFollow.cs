using UnityEngine;
using System.Collections;

public class ZombieFollow : MonoBehaviour
{

    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        AttackTrigger = 0;
    }
    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
           

                EnemySpeed = 0.01f;
                if (AttackTrigger == 0)
                {
                    myAnimator.Play("Walking");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            


            if (AttackTrigger == 1)
            {
                EnemySpeed = 0;
                myAnimator.Play("Attacking");
            }
        }

       

    }
    void OnTriggerEnter()
    {
        AttackTrigger = 1;
        myAnimator.SetBool("attack",true);
    }

    void OnTriggerExit()
    {
        AttackTrigger = 0;
        myAnimator.SetBool("attack", false);
    }
}
