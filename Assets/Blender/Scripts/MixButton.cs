using System;
using DG.Tweening;
using UnityEngine;

public class MixButton : MonoBehaviour
{
    public static event EventHandler ButtonPressed;

    private bool _isClicked = false;




    private void OnMouseDown()
    {
        if (_isClicked == false)
        {
            OnButtonPressed();
            PlayAnimation();

            _isClicked = true;
        }
        
    }


    private void PlayAnimation()
    {
        Vector3 beginPositin = transform.localPosition;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(beginPositin - new Vector3(0, 0.01f, 0.008f), 0.2f));
        sequence.Append(transform.DOLocalMove(beginPositin, 0.12f).OnComplete(() => _isClicked = false));
    }
    protected virtual void OnButtonPressed()
    {
        ButtonPressed?.Invoke(this, EventArgs.Empty);
    }
}
