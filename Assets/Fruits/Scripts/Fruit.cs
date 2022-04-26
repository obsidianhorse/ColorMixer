using System;
using DG.Tweening;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public static event EventHandler FruitJumped;

    protected Color _color;

    private bool _isMoved = false;

    public Color Color
    {
        get { return _color; }
    }



    private void OnMouseDown()
    {
        if (_isMoved == false)
        {
            MoveToBlender();
            OnFruitJumped();
            _isMoved = true;
        }
    }

    protected virtual void OnFruitJumped()
    {
        FruitJumped?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void MoveToBlender()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(Blender.PositionToMove.y, 0.15f));
        sequence.Append(transform.DOMove(Blender.PositionToMove, 0.15f).OnComplete(TurnOffCinematic));

        SpawnNewFruit();
    }
    private void TurnOffCinematic()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    
    private void SpawnNewFruit()
    {
        Vector3 fruitPositionToMove = transform.position;
        Vector3 positionToSpawn = transform.position + Vector3.forward * 0.5f;

        GameObject newFruit = Instantiate(gameObject, positionToSpawn, transform.rotation);
        newFruit.transform.DOMove(fruitPositionToMove, 0.3f);
        newFruit.name = gameObject.name;
    }

}
