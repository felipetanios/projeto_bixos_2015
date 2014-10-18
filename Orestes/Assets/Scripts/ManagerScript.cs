using UnityEngine;
using System.Collections;


// Class responsavel por realizar as atualizacoes gerais do jogo como:
// Aparecimento de pombas
public class ManagerScript : MonoBehaviour {
	float pombaSpawn = 0;
	float relativeDistance = 1f;

	public GameObject pombaObject;
	public Transform[] spawnPoint;

	// Update is called once per frame
	void Start () {
		StartCoroutine ("SpawnPomba");
	}

	IEnumerator SpawnPomba () {
		int i, aux = 0;

		while (true) {
			yield return new WaitForSeconds (1 / (relativeDistance * 1.2f));
			pombaSpawn = Random.Range (1, 3);

			for (i = 0; i < pombaSpawn; i++) 
			{
				// Garante que, caso ja tenha sido spawnado mais que uma pomba, nao seja duas seguidas do mesmo lado
				if (i > 0)
					if (aux == 0)
						aux = 1;
					else if (aux == 1)
						aux = 0;
				else
					aux = Random.Range(0, 1);

				Instantiate(pombaObject, spawnPoint[aux].position, spawnPoint[aux].rotation);
			}
		}
	}
}
