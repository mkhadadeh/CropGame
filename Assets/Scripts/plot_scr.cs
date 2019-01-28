using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot_scr : MonoBehaviour {
	public Material[] fertilityMaterials;
	public bool[] fertilityScores = {true, true, true}; // Of Elements A, B, C
	int seed_type; // Of Plants 1, 2, 3. 0 for no plant
	int growth;

	// Use this for initialization
	void Start () {
		fertilityMaterials = new Material[8];
		seed_type = 0;
		growth = 0;
		for(int i = 0; i < 8; i++) {
			string path = "Materials/element" + i.ToString();
			Debug.Log(path);
			fertilityMaterials[i] =  Resources.Load(path, typeof(Material)) as Material;
		}
	}

	// Update is called once per frame
	void Update () {
		UpdateMaterial();
	}

	void UpdateMaterial() {
		int mat_num = ((fertilityScores[0] ? 1 : 0)* 4) + ((fertilityScores[1] ? 1 : 0) * 2) + (fertilityScores[2] ? 1 : 0);
		GetComponent<MeshRenderer>().material = fertilityMaterials[mat_num];
	}

	bool Plant(int plant_type) {
		// If the tile is not occupied, occupy it with the new plant
		if(seed_type == 0) {
			seed_type = plant_type;
			return true;
		}
		return false;
		//TODO: Add plant model
	}

	public void Grow() {
		if(growth != seed_type && seed_type != 0 && fertilityScores[seed_type-1]) {
			growth++;
			if(growth == seed_type) {
				fertilityScores[seed_type - 1] = false;
				fertilityScores[seed_type % 3] = true;
			}
		}
		//TODO: Change plant model
	}

	int Harvest() {
		if(growth == seed_type && seed_type != 0) {
			growth = 0;
			return seed_type * 10; // seed_type * 10 implies the fully grown plant has been harvested
		}
		growth = 0;
		return seed_type; // seed_type implies that only the seeds were harvested. 0 implies nothing was in the tile.
		//TODO: Remove plant model
	}

	void Fertilize(bool artificial) {
		if(artificial) {
			fertilityScores[0] = true;
			fertilityScores[1] = true;
			fertilityScores[2] = true;
		}
		int num_of_depleted = 0;
		for(int i = 0; i < 3; i++) {
			if(!fertilityScores[i]) {
				num_of_depleted++;
			}
		}
		if(num_of_depleted != 0) {
			int[] depleted = new int[num_of_depleted];
			int j = 0;
			for(int i = 0; i < 3; i++) {
				if(!fertilityScores[i]) {
					depleted[j] = i;
					j++;
				}
			}
			fertilityScores[Random.Range(0, num_of_depleted)] = true;
		}
	}
}
