using DG.Tweening;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wintp;
    [SerializeField] private TextMeshProUGUI gameOvertp;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject gameOverMenu;


    void Start()
    {
        wintp.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        gameOvertp.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void StartTheGame()
    {
        winMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
}
