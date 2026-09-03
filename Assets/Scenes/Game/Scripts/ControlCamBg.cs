using UnityEngine;
using UnityEngine.UI;


public class ControlCamBg : MonoBehaviour 
{
    public Image ImageBg;
    public float ChangingSpeed255;
    public float MinValue255;



    private float _changingSpeed;
    private float _minValue;
    private int   _stage;



    private void AddOne2Statge()
    {
        _stage ++;

        if (_stage > 5) _stage = 0;

    }   // AddOne2Statge()


    private void Start() 
    {
        _stage         = 0;
        _changingSpeed = ChangingSpeed255 / 255;
        _minValue      = MinValue255      / 255;
        ImageBg.color  = new Color(_minValue, 1f, 1f);

    }   // Start()


    private void Update() 
    {
        Color c = new(ImageBg.color.r, ImageBg.color.g, ImageBg.color.b);

        // Debug.Log(c);
        switch (_stage)
        {
            case 0:
                c.b -= Time.deltaTime * _changingSpeed;

                if (c.b <= _minValue)
                {
                    c.b = _minValue;
                    AddOne2Statge();
                }

                ImageBg.color = c;
                break;

            case 1:
                c.r += Time.deltaTime * _changingSpeed;

                if (c.r >= 1) 
                {
                    c.r = 1;
                    AddOne2Statge();
                }

                ImageBg.color = c;
                break;

            case 2:
                c.g -= Time.deltaTime * _changingSpeed;

                if (c.g <= _minValue)
                {
                    c.g = _minValue;
                    AddOne2Statge();
                }

                ImageBg.color = c;
                break;

            case 3:
                c.b += Time.deltaTime * _changingSpeed;

                if (c.b >= 1)
                {
                    c.b = 1;
                    AddOne2Statge();
                }

                ImageBg.color = c;
                break;

            case 4:
                c.r -= Time.deltaTime * _changingSpeed;

                if (c.r <= _minValue)
                {
                    c.r = _minValue;
                    AddOne2Statge();
                }

                ImageBg.color = c;
                break;

            case 5:
                c.g += Time.deltaTime * _changingSpeed;

                if (c.g >= 1)
                {
                    c.g = 1;
                    AddOne2Statge();
                }

                ImageBg.color = c;
                break;
        }

    }   // Update()


}   // class ControlCamBg
