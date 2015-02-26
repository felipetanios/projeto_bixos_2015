using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float scalingFactorX = 1;

	public GameObject[] enemies;
	public GameObject vehicle;
	public GameObject layer;

	private bool isRunning;
	private static bool alreadyVehicle;

	void Start () {
		isRunning = true;
	}

	// Update is called once per frame
	void Update () {
		var cameraScrolling = CameraScrolling.Instance;

		transform.Translate(cameraScrolling.defaultVector.magnitude * scalingFactorX, 0, 0);

		// If the player is running
		if (MovementManager.Instance.mode == 0) {
			if (!isRunning) {
				prepareRun();

				isRunning = true;
			}
		}
		else {
			if (isRunning) {
				stopRun();

				isRunning = false;
			}
		}
	}

	void prepareRun ()
	{
		if (enemies.Length > 0) {
			StartCoroutine ("SetEnemies");
		}

		StopCoroutine("VehicleDisplay");
	}

	void stopRun ()
	{
		StartCoroutine("SetVehicles");

		if (enemies.Length > 0) {
			StopCoroutine ("EnemiesDisplay");
		}
	}

	IEnumerator SetEnemies()
	{
		yield return new WaitForSeconds(Random.Range(0.5f, 2f));
		StartCoroutine ("EnemiesDisplay");
	}

	IEnumerator SetVehicles()
	{
		yield return new WaitForSeconds(Random.Range(0.5f, 2f));
		StartCoroutine ("VehicleDisplay");
	}

	IEnumerator EnemiesDisplay()
	{
		while (true) {
			int chosen = Random.Range (0, enemies.Length);
			Vector3 position = new Vector3(transform.localPosition.x, enemies[chosen].transform.position.y, transform.position.z);

			GameObject currentEnemy = Instantiate(enemies[chosen], enemies[chosen].transform.position, transform.rotation) as GameObject;

			currentEnemy.transform.parent = layer.transform;
			currentEnemy.transform.localEulerAngles = new Vector3(0, 0, 0);
			currentEnemy.transform.localPosition = position;

			GameObject.Destroy(currentEnemy, 30.0f);
			
			yield return new WaitForSeconds (Random.Range (1/(CameraScrolling.Instance.progress) * 1.75f, 1/(CameraScrolling.Instance.progress) * 3.5f));
		}
	}

	IEnumerator VehicleDisplay()
	{
		while (true) {
			if (!alreadyVehicle) {
				Vector3 position = new Vector3(transform.localPosition.x, vehicle.transform.position.y, vehicle.transform.position.z);

				GameObject currentVehicle = Instantiate(vehicle, position, transform.rotation) as GameObject;

				currentVehicle.transform.parent = layer.transform;
				currentVehicle.transform.localEulerAngles = new Vector3(0, 0, 0);
				currentVehicle.transform.localPosition = position;

				GameObject.Destroy(currentVehicle, 20.0f);

				alreadyVehicle = true;
			}

			else {
				alreadyVehicle = false;
			}
			
			yield return new WaitForSeconds (Random.Range (20f, 23f));
		}
	}
}
