using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour
{
	public GameObject planet;       // ���͂̔������鐯
	public float accelerationScale; // �����x�̑傫��

	public Rigidbody ThisRig;

	void Start()
	{ 
	
	}

	void FixedUpdate()
	{
		// ���Ɍ����������̎擾
		var direction = planet.transform.position - transform.position;
		direction.Normalize();

		// �����x�^����
		ThisRig.AddForce(accelerationScale * direction, ForceMode.Acceleration);
	}
}