using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFactory : MonoBehaviour
{
    public Unit Prototype;
    public Map Map;
	RaycastHit hit;
	public int y;
	public int x;
	public RawImage playerColor;


    public List<ResourceCost> Costs;
    
    // Temporary until we figure out a better way to decide where to spawn.
	public Vector2Int SpawnCoordinate;

	void Start(){
	}

	void update(){
		if (Input.GetMouseButtonUp(0)) {
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.name.Contains ("Quad")) {
					Debug.Log ("hello");
					x = hit.collider.gameObject.GetComponentInParent<Cell> ().X;
					y = hit.collider.gameObject.GetComponentInParent<Cell> ().Y;						
				}
			}
		}
	}

	public void SpawnUnit()
    {

        bool canAfford = true;
        for (int i = 0; i < Costs.Count; i++)
        {
            if (!Costs[i].CanAfford())
            {
                canAfford = false;
            }
        }
        
        
        if (canAfford)
        {
            for (int i = 0; i < Costs.Count; i++)
            {
                Costs[i].Pay();
            }
            Unit newUnit = Instantiate(Prototype);
			newUnit.GetComponentInChildren<Material> ().color = playerColor.color;
			//newUnit.GetComponent<Material>(mat);
            Cell cell = Map.GetCell(x, y);
            newUnit.transform.SetParent(cell.transform, false);
			cell.unit = newUnit;
        }
        else
        {
            Debug.Log("Not enough resources!");
        }

    }

    [System.Serializable]
    public class ResourceCost
    {
        public Resource Resource;
        public int Cost;

        public bool CanAfford()
        {
            return Resource.CanAfford(Cost);
        }

        public void Pay()
        {
            Resource.RemoveAmount(Cost);
        }
        
    }
}