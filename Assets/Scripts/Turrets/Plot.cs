using UnityEngine;

public class Plot : MonoBehaviour
{
    GameObject turret;

    [SerializeField] Color hoverColor;
    [SerializeField] Transform spawnPoint;
    Color startColor;
    [SerializeField] Renderer rend;

    void Awake()
    {
        if (rend == null) rend = GetComponent<Renderer>();
    }

    void Start()
    {
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (turret != null) return;  // prevent building multiple turrets on the same plot
        SetTurret turretObj = BuildManager.instance.GetSelectedTurret();
        if (turretObj.cost > GameManager.instance.points) 
        {
            Debug.Log("Not enough points");
            return;
        }
        GameManager.instance.Buy(turretObj.cost); //Buying turrets
        Vector3 spawnPos = spawnPoint.position; 
        turret = Instantiate(turretObj.prefab, spawnPos, Quaternion.identity);  // Instantiate turret directly at this plot’s position
    }
}
