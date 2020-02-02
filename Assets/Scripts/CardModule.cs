using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModule : MonoBehaviour
{
    [SerializeField] private SpriteRenderer frontRenderer = null;
    [SerializeField] private SpriteRenderer backRenderer = null;
    [SerializeField] private AudioSource audioSourece = null;
    private bool isActive = true;

    public Color CardColor
    {
        get { return backRenderer.color; }
        set { backRenderer.color = value; }
    }

    public void Reset()
    {
        isActive = true;
        gameObject.SetActive(true);
        transform.rotation = Quaternion.identity;
        frontRenderer.color = Color.white;
    }

    public void RotateAnimation(bool isUp)
    {
        if (!isActive) return;
        StartCoroutine(UpdateRotate(isUp, 0.5f));

        
    }

    public void ReleaseAnimation()
    {
        if (!isActive) return;
        StartCoroutine(UpdateOpacity(0.5f));

        isActive = false;
    }
    
    private IEnumerator UpdateRotate(bool isUp, float time)
    {
        float currTime = Time.time;
        Vector3 vecAngle = isUp ? Vector3.up : Vector3.zero;

        Quaternion prev = isUp ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        Quaternion next = isUp ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        while (Time.time - currTime <= time)
        {
            transform.rotation = Quaternion.Lerp(
                prev,
                next,
                (Time.time - currTime) / time);
            yield return null;

        }
        transform.rotation = next;
        yield break;
    }

    private IEnumerator UpdateOpacity(float time)
    {
        float fixedTime = Time.time;
        Color color = CardColor;

        while (Time.time - fixedTime <= time)
        {
            color.a = Mathf.Lerp(
                1, 0,
                (Time.time - fixedTime) / time);

            CardColor = color;
            frontRenderer.color = new Color(1, 1, 1, color.a);

            yield return null;

        }

        color.a = 0;
        CardColor = color;
        frontRenderer.color = new Color(1, 1, 1, 0);

        gameObject.SetActive(false);
        yield break;
    }
}
