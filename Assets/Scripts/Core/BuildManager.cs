using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    [Header("Refrences")]
    [SerializeField] SetTurret[] turrets;

    int selectedTurret = 0;

    void Awake()
    {
        instance = this;
    }

    public SetTurret GetSelectedTurret()
    {
        return turrets[selectedTurret];
    }

    public void SetSelectedTurret(int _selectedTurret)
    {
        selectedTurret = _selectedTurret;
    }

}
