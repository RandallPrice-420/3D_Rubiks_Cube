using UnityEngine;
using UnityEngine.UI;


public class ControlTimer : MonoBehaviour
{
    public Toggle ReadyToggle;
    public Text   TimerText;



    private float _current_time;
    private bool  _isRunning;



    public void ClearTimer()
    {
        _isRunning    = false;
        _current_time = 0;

    }   // ClearTimer()


    public void StartTimer()
    {
        _isRunning = true;

    }   // StartTimer()


    public void StopTimer()
    {
        _isRunning = false;

    }    // StopTimer()


    public void ToggleTimer()
    {
        _isRunning = !_isRunning;

    }   // ToggleTimer()



    private string ParseTime(float t) 
    {
        int n_min = (int)(t / 60);

        if (n_min > 99)
        {
            return "99' 99\" 99";
        }

        int    n_sec  = (int)(t - n_min * 60);
        int    n_msec = (int)((t - n_min * 60 - n_sec) * 100);
        string s_min  = n_min.ToString();
        string s_sec  = n_sec.ToString();
        string s_msec = n_msec.ToString();

        if (s_min.Length  == 1) s_min  = "0" + s_min;
        if (s_sec.Length  == 1) s_sec  = "0" + s_sec;
        if (s_msec.Length == 1) s_msec = "0" + s_msec;

        return $"{s_min}' {s_sec}\" {s_msec}";

    }   // ParseTime()


    private void Start() 
    {
        _isRunning    = false;
        _current_time = 0;

    }   // Start()


    private void Update()
    {
        if (_isRunning)
        {
            _current_time += Time.deltaTime;
        }

        TimerText.text = ParseTime(_current_time);
        _isRunning = ((Input.anyKeyDown)   &&
                      (_current_time == 0) &&
                      (!_isRunning)        &&
                      (!ReadyToggle.isOn));

    }   // Update()


}   // class ControlTimer
