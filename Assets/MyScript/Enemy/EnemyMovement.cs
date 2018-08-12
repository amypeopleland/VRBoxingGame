using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Transform player;
    private NavMeshAgent nav;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);
	}
}
