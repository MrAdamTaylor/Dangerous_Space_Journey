using System.Collections;
using UnityEngine;

public class LerpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Rect;
    [SerializeField]
    private GameObject SecondRect;
    [SerializeField]
    private Transform StartPoint;
    [SerializeField]
    private Transform CenterTarget;
    [SerializeField]
    private Transform EndPoint;
    [SerializeField]
    [Range(0, 100)]
    private float LerpSpeed = 1f;
    [SerializeField]
    [Range(0, 25)]
    private float MoveSpeed = 1f;
    
    private Coroutine LerpCoroutine;

    private void Update()
    {
        StartCorutineByButton(KeyCode.L, LerpRectFixedTime());
        StartCorutineByButton(KeyCode.K, LerpRectFixedSpeed());
        StartCorutineByButton(KeyCode.P, LerpRotationFixedTime());
        StartCorutineByButton(KeyCode.O, LerpRotationFixedSpeed());
    }

    private void StartCorutineByButton(KeyCode button, IEnumerator input_coroutine)
    {
        if (Input.GetKeyDown(button))
        {
            if (LerpCoroutine != null)
            {
                StopCoroutine(LerpCoroutine);
            }

            LerpCoroutine = StartCoroutine(input_coroutine);
        }
    }

    private IEnumerator LerpRectFixedTime()
    {
        //Rect.transform.rotation = Quaternion.identity;

        while (true)
        {
            float time = 0;

            while (time < 1)
            {
                Rect.transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position, time);
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            time = 0;

            while (time < 1)
            {
                Rect.transform.position = Vector3.Lerp(EndPoint.position, StartPoint.position, time);
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }
        }
    }
    
    private IEnumerator LerpRectFixedSpeed()
    {
        //Rect.transform.rotation = Quaternion.identity;

        while (true)
        {
            float distance = Vector3.Distance(StartPoint.position, EndPoint.position);
            float remainingDistance = distance;
            while (remainingDistance > 0)
            {
                Rect.transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position, 1 - (remainingDistance / distance));
                remainingDistance -= MoveSpeed * Time.deltaTime;
                yield return null;
            }

            remainingDistance = distance;
            while (remainingDistance > 0)
            {
                Rect.transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position, remainingDistance / distance);
                remainingDistance -= MoveSpeed * Time.deltaTime;
                yield return null;
            }
        }
    }
    
    
    private IEnumerator LerpRotationFixedTime()
    {
        SecondRect.gameObject.SetActive(true);
       // Rect.transform.rotation = Quaternion.identity;
        //SecondRect.transform.rotation = Quaternion.identity;
        Rect.transform.position = StartPoint.position;
        SecondRect.transform.position = EndPoint.position;
        

        while (true)
        {
            float time = 0;

            while (time < 1)
            {
                Rect.transform.rotation = Quaternion.Lerp(Quaternion.Euler(180,0,0), Quaternion.Euler(0, 180, 0), time);
                SecondRect.transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(0, 180, 0), time);
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            time = 0;
            while (time < 1)
            {
                Rect.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 180, 0), Quaternion.Euler(180, 0, 0), time);
                SecondRect.transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 180, 0), Quaternion.Euler(0, 360, 0), time);
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }
        }
    }
    
    private IEnumerator LerpRotationFixedSpeed()
    {
        Rect.transform.position = CenterTarget.position;
        Rect.transform.rotation = Quaternion.identity;

        while (true)
        {
            float step = LerpSpeed * Time.deltaTime;
            while (Rect.transform.rotation.eulerAngles.y < 180)
            {
                Rect.transform.rotation = Quaternion.RotateTowards(Quaternion.identity, Quaternion.Euler(0, 180, 0), step);
                step += LerpSpeed * Time.deltaTime;
                yield return null;
            }

            while (Rect.transform.rotation.eulerAngles.y > 0)
            {
                Rect.transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0, 180, 0), Quaternion.identity, step);
                step += LerpSpeed * Time.deltaTime;
                yield return null;
            }
        }
    }
    
}
