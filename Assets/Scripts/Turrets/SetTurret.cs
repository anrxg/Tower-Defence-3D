using UnityEngine;
using System;

[Serializable]
public class SetTurret
{
    public string name;
    public int cost;
    public GameObject prefab;

    void Turret(string _name, int _cost, GameObject _prefab)
    {
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
}
