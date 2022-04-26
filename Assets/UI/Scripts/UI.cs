using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _percantageText;
    [SerializeField] private GameObject _winUI;


    private int _percantage;



    public void UnsubscribeAllEvents()
    {
        Mixator._FruitMixed -= UpdateText;
    }
    private void Start()
    {
        Mixator._FruitMixed += UpdateText; 
    }

    private void UpdateText(object sender, float percantage)
    {
        _percantage = (int)percantage;
        _percantageText.text = _percantage.ToString() + '%';

        if (percantage > 90 && percantage < 110)
        {
            ShowWinUI();
        }
    }
    private void ShowWinUI()
    {
        _winUI.SetActive(true);
    }
    
}
