using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("config")]
    Rigidbody _rigidbody;
    [SerializeField] private float speed = 2000f;
    [SerializeField] private float jumppower;
    bool jumpp;
    float hInput;
    float vInput;
    public Text hitungText;
    public Text winText;
    private int hitung;
    public Image WinImage;
    public Button backButton, menuButton;

    void Start()
    {
        hitung = 0;
        SetHitungText();
        winText.text = "";
        WinImage.gameObject.SetActive(false);
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        jumpp = Input.GetKeyDown(KeyCode.Space);
        Vector3 move = new Vector3(-Horizontal, 0f, -Vertical);
        if (_rigidbody)
            _rigidbody.AddForce((move * speed) * Time.deltaTime);
    }
    void Jump ()
    {
        _rigidbody.AddForce(Vector3.up * jumppower * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    void Move()
    {
        _rigidbody.AddForce(hInput * Time.fixedDeltaTime, 0f, vInput * Time.fixedDeltaTime);
    }
    void FixedUpdate()
    {
        Move();
        if (jumpp)
        {
            Jump();
            jumpp = false;

        }
    }
    void SetHitungText()
    {
        hitungText.text = "Jumlah Kubus : " + hitung.ToString();
        if (hitung >= 8) 
        
        {
            winText.text = "Kamu Menang!";
            WinImage.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin") ;

        {
            other.gameObject.SetActive(false);
            hitung = hitung + 1;
            SetHitungText();
         
        }
    }
}
