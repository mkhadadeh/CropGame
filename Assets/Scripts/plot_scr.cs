using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot_scr : MonoBehaviour {
	public Material[] fertilityMaterials;
	public bool[] fertilityScores = {true, true, true}; // Of Elements A, B, C
	public int seed_type; // Of Plants 1, 2, 3. 0 for no plant
	public int growth;
	public GameObject current_plant;
	public bool art_fert_used;

  public GameObject parts;
  public bool has_parts;

	// Use this for initialization
	void Start () {
        has_parts = false;
		art_fert_used = false;
		fertilityMaterials = new Material[8];
		seed_type = 0;
		growth = 0;
		for(int i = 0; i < 8; i++) {
			string path = "Materials/element" + i.ToString();
			Material mat = Resources.Load(path, typeof(Material)) as Material;
			fertilityMaterials[i] =  mat;
		}
	}

	// Update is called once per frame
	void Update () {
		UpdateMaterial();
        UpdateParticles();
	}

	void UpdateMaterial() {
		int mat_num = ((fertilityScores[0] ? 1 : 0)* 4) + ((fertilityScores[1] ? 1 : 0) * 2) + (fertilityScores[2] ? 1 : 0);
		GetComponent<MeshRenderer>().material = fertilityMaterials[mat_num];
	}

	public bool Plant(int plant_type) {
		// If the tile is not occupied, occupy it with the new plant
		if(seed_type == 0) {
			seed_type = plant_type;
			var plant_seed = Resources.Load("Plants/plant" + plant_type.ToString() + "growth0");
			current_plant = Instantiate(plant_seed, transform.position + (new Vector3(0f,0f,0f)), Quaternion.identity) as GameObject;
			var poof_part_prefab = Resources.Load("PlantedParts");
			Instantiate(poof_part_prefab, transform.position, Quaternion.identity);
			return true;
		}
		return false;
	}

	public void Grow() {
		if(growth != seed_type && seed_type != 0 && fertilityScores[seed_type-1]) {
			Destroy(current_plant);
			growth++;
			var plant = Resources.Load("Plants/plant" + seed_type.ToString() + "growth" + growth.ToString());
			current_plant = Instantiate(plant, transform.position + (new Vector3(0f,0f,0f)), Quaternion.identity) as GameObject;
			if(growth == seed_type) {
				fertilityScores[seed_type - 1] = false;
				fertilityScores[seed_type % 3] = true;
			}
		}
	}

	public int Harvest() {

		//if(current_plant != null) {
			int seed_was = seed_type;
			seed_type = 0;
			Destroy(current_plant);

        if (has_parts)
        {
            Destroy(parts);
            has_parts = false;
        }
        //}
        if (growth == seed_was && seed_was != 0) {
			growth = 0;
			return seed_was * 10; // seed_type * 10 implies the fully grown plant has been harvested
		}
		growth = 0;



		return seed_was; // seed_type implies that only the seeds were harvested. 0 implies nothing was in the tile.
	}

	public void Fertilize(bool artificial) {
		if(artificial) {
			art_fert_used = true;
			fertilityScores[0] = true;
			fertilityScores[1] = true;
			fertilityScores[2] = true;
		}
		else {
			var poof_part_prefab = Resources.Load("PlantedParts");
			Instantiate(poof_part_prefab, transform.position, Quaternion.identity);
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

    void UpdateParticles()
    {
        if(!has_parts && growth == seed_type && seed_type != 0)
        {
            var part_prefab = Resources.Load("GrownParts");
            parts = (GameObject)Instantiate(part_prefab, transform.position, Quaternion.identity);
            has_parts = true;
        }
    }
}
