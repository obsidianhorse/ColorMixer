using System;
using System.Collections.Generic;
using UnityEngine;


public class Mixator : MonoBehaviour
{
    public static event EventHandler _FruitDroped;
    public static event EventHandler<float> _FruitMixed;


    [SerializeField] private int _maxCountOfFruits = 5;

    [SerializeField] private GameObject _juice;

    private List<Color> _fruitsColor = new List<Color>();
    private List<GameObject> _fruits = new List<GameObject>();




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            Fruit fruit = other.gameObject.GetComponent<Fruit>();

            _fruitsColor.Add(fruit.Color);
            _fruits.Add(other.gameObject);

            OnFruitDroped();


            DeleteExcessFruit();
        }
    }


    public void UnsubscribeAllEvents()
    {
        MixButton.ButtonPressed -= Mix;
    }
    private void Start()
    {
        MixButton.ButtonPressed += Mix;
    }


    private void DeleteExcessFruit()
    {
        if (_fruits.Count > _maxCountOfFruits)
        {
            Destroy(_fruits[0].gameObject);
            _fruits.RemoveAt(0);
        }
    }
    private void DeleteAllFruits()
    {
        for (int i = 0; i < _fruits.Count; i++)
        {
            Destroy(_fruits[i].gameObject);
            _fruits.RemoveAt(i);
        }
    }
    private void Mix(object sender, EventArgs e)
    {
        if (_fruitsColor.Count == 0)
        {
            return;
        }


        DeleteAllFruits();
        _juice.SetActive(true);

        Color firstColor;


        firstColor = MixColors(_fruitsColor) / 255;
        _juice.GetComponent<MeshRenderer>().material.color = firstColor;

        CompareColors(firstColor);
    }

    private Color MixColors(List<Color> aColors)
    {
        Color result = new Color(0, 0, 0, 0);
        foreach (Color c in aColors)
        {
            result += c;
        }
        result /= aColors.Count;
        return result;
    }

    private void CompareColors(Color color)
    {
        float percantage;
        float r, g, b; // perñantage



        r = GetPercentAsSimilarChannel(Character.ColorReference.r, color.r);

        g = GetPercentAsSimilarChannel(Character.ColorReference.g, color.g);

        b = GetPercentAsSimilarChannel(Character.ColorReference.b, color.b);


        percantage = (int)(r + b + g) / 3;
        if (percantage > 100)
        {
            percantage = 100 - (percantage - 100);
        }
        else if (percantage < 0)
        {
            percantage = 0;
        }
        OnFruitMixed(percantage);
    }
    private float GetPercentAsSimilarChannel(float c1, float c2)
    {
        if (c1 != 0 && c2 != 0)
        {
            return (c1 * 100 / c2);
        }
        return 100;
    }

    protected virtual void OnFruitDroped()
    {
        _FruitDroped?.Invoke(this, EventArgs.Empty);
    }
    protected virtual void OnFruitMixed(float percantage)
    {
        _FruitMixed?.Invoke(this, percantage);
    }
}
