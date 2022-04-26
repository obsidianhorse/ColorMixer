using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Color _setColorReference;
    [SerializeField] private GameObject _cup;

    private GameObject[] _characters;



    private static Color _colorReference;
    public static Color ColorReference
    {
        get {return _colorReference; }
    }


    private void Start()
    {
        _colorReference = _setColorReference;
        _cup.GetComponent<SpriteRenderer>().color = _colorReference;
        ChooseRandomCharacter();
    }
    private void ChooseRandomCharacter()
    {
        transform.GetChild(Random.Range(1, transform.childCount)).gameObject.SetActive(true);
    }
}
