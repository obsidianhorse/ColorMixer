using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blender : MonoBehaviour
{
    [SerializeField] private Transform _TransformOfPoint;


    private static Vector3 _positionToMove;

    private Animator _animator;



    public static Vector3 PositionToMove
    {
        get
        {
            return _positionToMove;
        }
    }

    public void UnsubscribeAllEvents()
    {
            Fruit.FruitJumped -= FruitJumped;
            Mixator._FruitDroped -= FruitDroped;
            MixButton.ButtonPressed -= Mix;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _positionToMove = _TransformOfPoint.position;

        Fruit.FruitJumped += FruitJumped;
        Mixator._FruitDroped += FruitDroped;
        MixButton.ButtonPressed += Mix;
    }


    private void FruitJumped(object sender, EventArgs e)
    {
        _animator.SetFloat("SpeedOfOpenCap", 1);
        _animator.SetTrigger("Open");
    }
    private void FruitDroped(object sender, EventArgs e)
    {
        _animator.SetFloat("SpeedOfOpenCap", -1);
        _animator.SetTrigger("Close");
    }


    private void Mix(object sender, EventArgs e)
    {
        StartCoroutine(MixAnim());
    }

    IEnumerator MixAnim()
    {
        _animator.SetTrigger("Mix");

        yield return new WaitForSeconds(2f);

        _animator.SetTrigger("StopMix");
    }
}
