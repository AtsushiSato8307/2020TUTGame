using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursolMove : MonoBehaviour
{
    private int lockmulti = 1;
    private Vector2 inputVector;
    [SerializeField]
    private float InitSpeed;
    [SerializeField]
    private float SiftSpeed;
    private float Speed
    {
        get
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                return SiftSpeed;
            }
            else
            {
                return InitSpeed;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    private void OnEnable()
    {
        Initialize();
    }
    private void Initialize()
    {
        inputVector = Vector2.zero;
        transform.localPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // input
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 移動処理
        transform.position = (Vector2)transform.position + (inputVector * Speed * lockmulti);
        // 画面外に出ないように修正
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,0,Screen.width),
            Mathf.Clamp(transform.position.y, 0, Screen.height));
    }
    public void Lock(bool is_lock)
    {
        if (is_lock)
        {
            lockmulti = 0;
        }
        else
        {
            lockmulti = 1;
        }
    }
}
