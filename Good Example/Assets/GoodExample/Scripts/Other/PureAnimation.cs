﻿using System;
using System.Collections;
using UnityEngine;

public class PureAnimation
{
    public TransformChanges LastChanges { get; private set; }

    private Coroutine _lastAnimation;
    private MonoBehaviour _context;

    public PureAnimation(MonoBehaviour context)
    {
        _context = context;
    }

    public void Play(float duration, Func<float, TransformChanges> body)
    {
        if (_lastAnimation != null)
            _context.StopCoroutine(_lastAnimation);

        _lastAnimation = _context.StartCoroutine(GetAnimation(duration, body));
    }

    private IEnumerator GetAnimation(float duration, Func<float, TransformChanges> body)
    {
        float expiredSeconds = 0f;
        float progress = 0f;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            LastChanges = body.Invoke(progress);

            yield return null;
        }
    }
}
