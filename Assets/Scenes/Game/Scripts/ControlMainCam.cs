using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlMainCam : MonoBehaviour
{
    public float max_speed;
    


    private Vector3    _current_position;
    private Quaternion _current_rotation;
    private string     _current_scene;
    private float      _speed;
    private bool       _startingMoving;
    private Vector3    _target_position;
    private Quaternion _target_rotation;
    private Vector3    _target_rotation_euler;
    private float      _total_time;



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        GameObject mainCam     = GameObject.Find("Main Camera");
        _current_position      = mainCam.transform.position;
        _current_rotation      = mainCam.transform.rotation;
        _target_position       = new Vector3( 2f, 3.5f, -6f);
        _target_rotation_euler = new Vector3(32f, 324f,  0f);

        _current_scene   = SceneManager.GetActiveScene().name;
        _startingMoving  = true;
        _total_time      = 0;
        _target_rotation = Quaternion.Euler(_target_rotation_euler);

    }   // Start()


    private void Update()
    {
        GameObject mainCam = GameObject.Find("Main Camera");

        if (!SceneManager.GetActiveScene().name.Equals(_current_scene)) 
        {
            _current_scene  = SceneManager.GetActiveScene().name;
            _startingMoving = true;
            _total_time     = 0;

            if (_current_scene.Contains("Starting"))
            {
                _target_position       = new Vector3(2f, 3.5f, -6f);
                _target_rotation_euler = new Vector3(32f, 324f, 0f);
            }
            else if (_current_scene.Contains("Main"))
            {
                _target_position       = new Vector3(3.5f, 3.5f, -5f);
                _target_rotation_euler = new Vector3(32f, 328f, 0f);
            }

            _target_rotation = Quaternion.Euler(_target_rotation_euler);
        }
        else if (_startingMoving)
        {
            if (_total_time < 0.1f)
            {
                _total_time += Time.deltaTime;
            }
            else if (_total_time < 10f)
            {
                _total_time += Time.deltaTime;

                float pos_diff   = Vector3.Distance(_current_position, _target_position);
                float angle_diff = Quaternion.Angle(_current_rotation, _target_rotation);

                if (pos_diff < 0.015f && angle_diff < 0.15f)
                {
                    _startingMoving = false;
                }

                if (_speed < 1)
                {
                    _speed += _speed + Time.deltaTime * 0.15f;
                }
                else
                {
                    _speed = 1;
                }

                _current_position = Vector3   .Lerp(_current_position, _target_position, _speed * max_speed * Time.deltaTime);
                _current_rotation = Quaternion.Lerp(_current_rotation, _target_rotation, _speed * max_speed * Time.deltaTime);
            }
        }
        
        mainCam.transform.SetPositionAndRotation(_current_position, _current_rotation);

    }   // Update()


}   // class ControlMainCam
