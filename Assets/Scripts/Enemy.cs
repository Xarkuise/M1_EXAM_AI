using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    //[SerializeField] private float speed = 1.5f;
    //private GameObject player;

    //private bool hasLineOfSight = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (hasLineOfSight)
        //{
            agent.SetDestination(target.position);
        //    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //}
    }

    //private void FixedUpdate()
    //{
    //    RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
    //}
}
