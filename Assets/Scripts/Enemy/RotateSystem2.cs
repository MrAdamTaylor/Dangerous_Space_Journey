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
        [Range(0,100f)]
        private float LerpSpeed;
        
        [SerializeField]
        private float _xValue = 90;

        [SerializeField] private Quaternion myQuaternion;
        
        private float _newXValue;

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
        private bool _endedRotate;

        private Vector3 _targetPosition;

        private Coroutine _lerpCoroutine;
        private bool rotate;


        private void Start()
        {
            Debug.Log($"Круги Эйлера до: (" + transform.rotation.eulerAngles.x 
                                            + ") - (" + transform.rotation.eulerAngles.y + ") - ("
                                            + transform.rotation.eulerAngles.z + ")");
            
            _targetPosition = RectTarget.transform.position;
            StartCoroutine(TestCoroutine());
        }

        private void Update()
        {
            Debug.Log($"Круги Эйлера после: (" + transform.rotation.eulerAngles.x 
                                            + ") - (" + transform.rotation.eulerAngles.y + ") - ("
                                            + transform.rotation.eulerAngles.z + ")");
            myQuaternion = Rect.transform.rotation;
        }

        private IEnumerator TestCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);
                Debug.Log("Coroutine ended: " + Time.time + "seconds");
                CalculateAngleAndDirection();
                GetPositions();
                if (Mathf.Abs(_angleDegrees) > 10f)
                {
                    if (_lerpCoroutine != null)
                    {
                        if (_endedRotate)
                        {
                            StopCoroutine(_lerpCoroutine);
                            _endedRotate = false;
                        }
                    }
                    //_lerpCoroutine = StartCoroutine(RotateCoroutine(_current, _next));
                    _lerpCoroutine = StartCoroutine(RotateCoroutine2(_current, _next));
                    _xValue = _xValue + _angleDegrees;
                }
                else
                {
                    Debug.Log("Корутина поворота остановлена");
                    StopCoroutine(RotateCoroutine2(_current,_next));
                }

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

        private IEnumerator RotateCoroutine2(Quaternion current, Quaternion next)
        {
            float step = LerpSpeed * Time.deltaTime;
            while (MathModule.DifferenceBetween(Rect.transform.rotation.eulerAngles.x, _futureAngle))
            {
                Rect.transform.rotation = Quaternion.RotateTowards(current, next, step);
                step += LerpSpeed * Time.deltaTime;
                yield return null;
            }
            _endedRotate = true;
            yield break;
        }

        private void GetPositions()
        {
            Debug.Log($"Clockwise: {_clockwise}");
            if (_clockwise < 0)
            {
                GetNegativeQuaternion();
                Debug.Log($"Current Euler X: {_xValue} Y: {Constants.NEGATIVEYVALUE}, Z: {Constants.NEGATIVEZVALUE}" +
                          $"-  Next Euler X: {_futureAngle} Y: {Constants.NEGATIVEYVALUE} Z: {Constants.NEGATIVEZVALUE}");
                
            }
            else
            {
                GetPositiveQuaternion();
                Debug.Log($"Current Euler X: {_xValue} Y: {Constants.YVALUE}, Z: {Constants.ZVALUE}" +
                          $"-  Next Euler X: {_futureAngle} Y: {Constants.YVALUE} Z: {Constants.ZVALUE}");
            }
        }

        private void GetNegativeQuaternion()
        {
            if (MathModule.CompareBuffValue())
            {
                _xValue = MathModule.AngleWithChangeDirection(_xValue);
            }
            _current = Quaternion.Euler(_xValue,Constants.NEGATIVEYVALUE, Constants.NEGATIVEZVALUE);
            _futureAngle = _xValue + _angleDegrees;
            _futureAngle = MathModule.AroundAngle(_futureAngle);

            _next = Quaternion.Euler(_futureAngle,Constants.NEGATIVEYVALUE, Constants.NEGATIVEZVALUE);
        }

        private void GetPositiveQuaternion()
        {
            if (MathModule.CompareBuffValue())
            {
                _xValue = MathModule.AngleWithChangeDirection(_xValue);
            }
            _current = Quaternion.Euler(_xValue,Constants.YVALUE, Constants.ZVALUE);
            _futureAngle = _xValue + _angleDegrees;
            _futureAngle = MathModule.AroundAngle(_futureAngle);
            _next = Quaternion.Euler(_futureAngle,Constants.YVALUE, Constants.ZVALUE);
        }

        private void CalculateAngleAndDirection()
        {
            CalculateDirections(Rect, RectTarget);
            _dot = MathModule.DotProductXY(Ray1, Ray2);
            _angle = MathModule.AngleBetween(_dot, Ray1, Ray2);
            _angleDegrees = MathModule.TranslateAngleInDegrees(_angle);
            _crossVector = MathModule.CrossProduct(Ray1, Ray2);
            _clockwise = MathModule.GetClockWise(_crossVector);
            MathModule.AddClockwiseInBuffer(_clockwise);
            
            Debug.Log($"Compare Result: {MathModule.CompareBuffValue()}");
        }

        private void CalculateDirections(GameObject obj1, GameObject obj2)
        {
            Vector3 selfForward = -obj1.transform.up;
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