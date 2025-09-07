using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    Animator animator;
    bool isMenuOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMenu()
    {
        isMenuOpen = !isMenuOpen;
        animator.SetBool("MenuOpen", isMenuOpen);
    }

    void OnGUI()
    {
        pointsText.text = GameManager.instance.points.ToString();
    }


}
