using UnityEngine;


public class TipsMover : MonoBehaviour
{
    public float Speed;



    private int     _mode;
    private Vector3 _target_position;
    private Vector3 _destroy_position;


    public void Close()
    {
        _mode = -1;

    }   // Close()



    private void Start()
    {
        _mode             = 1; // 1: opening; 0: stay; -1: closing
        _target_position  = new Vector3(960,  540, 0);
        _destroy_position = new Vector3(480, -540, 0);

    }   // Start()


    private void Update()
    {
        if (_mode == -1)
        {
            transform.position = Vector3.Lerp(transform.position, _destroy_position, 4 * Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _target_position, 4 * Speed * Time.deltaTime);
        }

        if (_mode == 1)
        {
            transform.localScale += new Vector3
            (
                Time.deltaTime * Speed,
                Time.deltaTime * Speed,
                Time.deltaTime * Speed
            );

            if (transform.localScale.x >= 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
                _mode = 0;
            }
        }
        else if (_mode == -1)
        {
            transform.localScale -= new Vector3
            (
                Time.deltaTime * Speed,
                Time.deltaTime * Speed,
                Time.deltaTime * Speed
            );

            if (transform.localScale.x <= 0)
            {
                transform.localScale = Vector3.zero;
                Destroy(transform.gameObject);
            }
        }

    }   // Update()


}   // class TipsMover
