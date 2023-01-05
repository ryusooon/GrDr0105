using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour
{
	public GameObject planet;       // ˆø—Í‚Ì”­¶‚·‚é¯
	public float accelerationScale; // ‰Á‘¬“x‚Ì‘å‚«‚³

	public Rigidbody ThisRig;

	void Start()
	{ 
	
	}

	void FixedUpdate()
	{
		// ¯‚ÉŒü‚©‚¤Œü‚«‚Ìæ“¾
		var direction = planet.transform.position - transform.position;
		direction.Normalize();

		// ‰Á‘¬“x—^‚¦‚é
		ThisRig.AddForce(accelerationScale * direction, ForceMode.Acceleration);
	}
}