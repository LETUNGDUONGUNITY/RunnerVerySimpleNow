using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;
using UnityEngine.UI;
public class TungDuongplayer : MonoBehaviour
{
    [SerializeField]
    private int _diem_so=0;
    [SerializeField]
    private Text Score,score2;
    [SerializeField]
    private Image _diem_so_2;
    [SerializeField]
    private GameObject restart;
    LaneRunner runner;
    [SerializeField]
    private AudioSource _nhac; 
    [SerializeField]
    private AudioClip qua, chet; 
    // Start is called before the first frame update
    void Start()
    {
        runner = GetComponent<LaneRunner>();
        restart.SetActive(false);
        _diem_so_2.enabled = false;
        score2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            runner.lane--;
        }
         if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            runner.lane++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("chuong ngai vat"))
        {
            runner.follow = false;
            Debug.Log("Finish");
            _nhac.PlayOneShot(chet);
            restart.SetActive(true);
            _diem_so_2.enabled = true; score2.enabled = true;
        }
        if (other.gameObject.CompareTag("vuot qua"))
        {            
            Debug.Log("Qua");
            _nhac.PlayOneShot(qua);
            _diem_so++;
            Score.text = "Score: " + _diem_so;
            score2.text= "Score: " + _diem_so;
        }
    }
}
