using DG.Tweening;
using UnityEngine;

public class Banana : Fruit
{
    private void Start()
    {
        _color = new Color(255, 255, 0);
    }


    protected override void MoveToBlender()
    {
        base.MoveToBlender();

        transform.DOLocalRotate(new Vector3(Random.RandomRange(-45, 45), 0, 0), 0.3f, RotateMode.LocalAxisAdd);
    }
}
