using System;
using System.Collections;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class RotateSystem2 : MonoBehaviour
    {
        [SerializeField] private GameObject Rect;
        [SerializeField] private GameObject RectTarget;
        
        
        [SerializeField] 
        [Range(15,30f)]
        private float _speed = 15f;

        [SerializeField]
        [Range(0,100f)]
        private float LerpSpeed;
        
        [SerializeField]
        private float _xValue = 90;

        private Vector3 Ray1;
        private Vector3 Ray2;
        private Vector3 _crossVector;
        private float _dot;
        private float _angle;
        private float _angleDegrees;
        private int _clockwise;
        private Quaternion _current;
        private Quaternion _next;
        private float _futureAngle;


        //private const float _yValue = 270;

        //private const float _zValue = 90;
        private Vector3 _targetPosition;

        private Coroutine _lerpCoroutine;
        private bool rotate;
        


        private void Start()
        {
            _targetPosition = RectTarget.transform.position;
            StartCoroutine(TestCoroutine());
            //StartCoroutine(MoveCoroutine());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                //CalculateAngleAndDirection();
                //RotateObject(_angleDegrees);
            }

            //StartCoroutine(CalculateAngleAndDirection());

        }

        private IEnumerator TestCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                Debug.Log("Coroutine ended: " + Time.time + "seconds");
                CalculateAngleAndDirection();
                GetPositions();
                //StartCoroutine(MoveCoroutine());
                if (Mathf.Abs(_angleDegrees) > 10f)
                {
                    
                    if (_lerpCoroutine != null)
                    {
                        StopCoroutine(_lerpCoroutine);
                    }
                    _lerpCoroutine = StartCoroutine(RotateCoroutine(_current, _next));
                    _xValue = _xValue - _angleDegrees;
                }
                else
                {
                    Debug.Log("Корутина поворота остановлена");
                    StopCoroutine(RotateCoroutine(_current,_next));
                }

            }
        }

        private IEnumerator LerpRotationFixedSpeed()
        {
            //Rect.transform.position = CenterTarget.position;
            Debug.Log("Coroutine Rotate Start " + Time.time);
            Rect.transform.rotation = Quaternion.identity;
            
            while (true)
            {
     
                float step = LerpSpeed * Time.deltaTime;
                while (Rect.transform.rotation.eulerAngles.y < 180)
                {
                    Debug.Log("<180");
                    Debug.Log($"Current Angle: {Rect.transform.rotation.eulerAngles.y}");
                    Rect.transform.rotation = Quaternion.RotateTowards(Quaternion.identity, Quaternion.Euler(0, 180, 0), step);
                    //Debug.Log("Rotate! " + Time.time);
                    step += LerpSpeed * Time.deltaTime;
                    yield return null;
                }

                while (Rect.transform.rotation.eulerAngles.y > 0)
                {
                    Debug.Log(">0");
                    Debug.Log($"Current Angle: {Rect.transform.rotation.eulerAngles.y}");
                    Rect.transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0, 180, 0), Quaternion.identity, step);
                    step += LerpSpeed * Time.deltaTime;
                    yield return null;
                }

                //StopCoroutine(LerpRotationFixedSpeed());
            }
        }

        private IEnumerator RotateCoroutine(Quaternion current, Quaternion next)
        {
            float step = LerpSpeed * Time.deltaTime;
            while (!Mathf.Approximately(Mathf.Abs(Rect.transform.rotation.eulerAngles.x),Mathf.Abs(_futureAngle)))
            {
                Debug.Log($"Current{Rect.transform.rotation.eulerAngles.x}, Future{_futureAngle}, {_clockwise}");
                Rect.transform.rotation = Quaternion.RotateTowards(current, next, step);
                Debug.Log($"Step {step}");
                if (_clockwise == -1)
                {
                    step += LerpSpeed * Time.deltaTime;
                }
                else
                {
                    //TODO почему - то с отрицательными числами плохо работает. Игнорирует условие остановки
                    step -= LerpSpeed * Time.deltaTime;
                    if (Rect.transform.rotation.eulerAngles.x < _futureAngle)
                    {
                        Debug.Log("STAP!");
                        yield break;
                    }
                }

                yield return  null;
            }
        }

        private void GetPositions()
        {
            _current = Quaternion.Euler(_xValue, Constants._yValue, Constants._zValue);
            _futureAngle = _xValue - _angleDegrees;
            _next = Quaternion.Euler(_futureAngle, Constants._yValue, Constants._zValue);
            Debug.Log($"Current Euler X: {_xValue} Y: {Constants._yValue}, Z: {Constants._zValue}" +
                      $"-  Next Euler X: {_futureAngle} Y: {Constants._yValue} Z: {Constants._zValue}");
        }

        private void RotateObject(float angleDegrees)
        {
            if (Mathf.Abs(angleDegrees) > 10f)
            {
                var current = Quaternion.Euler(_xValue, Constants._yValue, Constants._zValue);
                float xTemp = _xValue - _angleDegrees;
                Quaternion smoth = Quaternion.Euler(xTemp, Constants._yValue, Constants._zValue);
                //SmothRotate(current, smoth, _speed);
                _xValue = _xValue - _angleDegrees;
            }
        }

        private void CalculateAngleAndDirection()
        {
            CalculateDirections(Rect, RectTarget);
            _dot = MathModule.DotProductXY(Ray1, Ray2);
            _angle = MathModule.AngleBetween(_dot, Ray1, Ray2);
            _angleDegrees = MathModule.TranslateAngleInDegrees(_angle);
            _crossVector = MathModule.CrossProduct(Ray1, Ray2);
            _clockwise = MathModule.GetClockWise(_crossVector);
        }

        private void CalculateDirections(GameObject obj1, GameObject obj2)
        {
            Vector3 selfForward = obj1.transform.forward;
            Vector3 targedDirection = obj2.transform.position - transform.position;
            Debug.Log($"(this.name{this.name}): Obj1 position: {Rect.transform.position}, " +
                      $"Obj1 vectorForward: {selfForward}, " +
                      $"Obj2: {RectTarget.transform.position} " +
                      $"Direction between: {targedDirection}");
            Debug.DrawRay(Rect.transform.position, selfForward * 15, Color.green, 10);
            Debug.DrawRay(Rect.transform.position, targedDirection, Color.red, 10);

            Ray1 = selfForward;
            Ray2 = targedDirection;
        }

        public void OnDisable()
        {
            
        }
    }
}