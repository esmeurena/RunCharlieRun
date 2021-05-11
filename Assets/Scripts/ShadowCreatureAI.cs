using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowCreatureAI : MonoBehaviour
{
    private NavMeshAgent ShadowCreature;
    public Animator Animator;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        ShadowCreature = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ShadowCreature.isOnOffMeshLink)
            Animator.Play("SC_Jump");
        ShadowCreature.SetDestination(Player.transform.position);
        if (Input.GetKeyDown("p"))
        {
            Animator.Play("SC_Jump");
        }

    }
}
