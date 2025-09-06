using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform[] paths;
    public Transform startPoint;

    void Awake()
    {
        instance = this;
    }
}
