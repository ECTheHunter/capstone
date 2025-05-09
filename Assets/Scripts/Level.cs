using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;

    void Update()
    {
        if (levelText != null && GameManager.Instance != null)
        {
            levelText.text = " " + GameManager.Instance.level;
        }
    }
}