//!
using UnityEngine;

public class HealthBonusMono : MonoBehaviour
{
	bool moves = false;
	private Rigidbody body;


	// Start is called before the first frame update
	void Start()
	{
		body = gameObject.GetComponent<Rigidbody> ();

		int move = Random.Range(0, 5);

		if (move == 0)
		{
			moves = true;
		}

		Debug.Log("Spawned" + (moves? " movable " : " ") + "box");
	}

	// Update is called once per frame
	void Update()
	{
		if (moves)  //TODO: IMPL wall-collision
		{
			Vector3 by = new Vector3(Random.Range(0, 50) * 0.001f, 0f, Random.Range(0, 50) * 0.001f);
			body.MovePosition(transform.position + by);
		} else if (name == "Stun")
		{
			Vector3 by = new Vector3(Random.Range(0, 50) * 0.003f, 0f, Random.Range(0, 50) * 0.003f);
			body.MovePosition(transform.position + by);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Tank 0" || other.gameObject.name == "Tank 1")  //All tanks prefabs spawn with that name. If box collides with tank:
		{
			TankHealth hp = other.gameObject.GetComponent<TankHealth>();  //Target collided tank health module
			if (gameObject.name == "Trap")  //in case consumable is a Trap
			{
				hp.TakeDamage();
				gameObject.SetActive(false);
			}
			else if (gameObject.name == "Health")  //in case consumable is a HealthBox
			{
				hp.Heal();
				gameObject.SetActive(false);
			}  //in case consumable is a Stun, pass handling on TankMovement passive script
		}  //box collides with wall:
	}
}
//^