using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;


public class APICall3 : MonoBehaviour
{
    public TextMeshProUGUI timeText; 
    public TextMeshProUGUI heart_bpmText;
    private string URL = "http://localhost:3000/api/simulation/state";

//parsing JSON data
    private string id = "";
    private int time = 0;
    private string timer = "";
    private string started_at = "";
    private int heart_bpm = 0;
    private int p_sub = 0;
    private int p_suit = 0;
    private int t_sub = 0;
    private int v_fan = 0;
    private int p_o2 = 0;
    private int rate_o2 = 0;
    private int batteryPercent = 0;
    private int battery_out = 0;
    private int cap_battery = 0;
    private int t_battery = 0;
    private int p_h2o_g = 0;
    private int p_h2o_l = 0;
    private int p_sop = 0;
    private int rate_sop = 0;
    private int t_oxygenPrimary = 0;
    private int t_oxygenSec = 0;
    private int ox_primary = 0;
    private int ox_secondary = 0;
    private string t_oxygen = "";
    private int cap_water = 0;
    private int t_water = 0;
    private int __v = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = " ";
        heart_bpmText.text = "0";
        StartCoroutine(GetSuitInfo());
        
    }

    IEnumerator GetSuitInfo()
    {
        while(true) {
            //Only calls once per second
            yield return new WaitForSeconds(1f);
            
                UnityWebRequest SuitInfoRequest = UnityWebRequest.Get(URL);
                yield return SuitInfoRequest.SendWebRequest();

                if (SuitInfoRequest.isNetworkError || SuitInfoRequest.isHttpError)
                {
                    Debug.LogError(SuitInfoRequest.error);
                    yield break;
                }

                JSONNode suitInfo = JSON.Parse(SuitInfoRequest.downloadHandler.text);

                //assigning API data to variables 
                id = suitInfo["id"];
                time = suitInfo["time"];
                timer = suitInfo["timer"];
                started_at = suitInfo["started_at"];
                heart_bpm = suitInfo["heart_bpm"];
                p_sub = suitInfo["p_sub"];
                p_suit = suitInfo["p_suit"];
                t_sub = suitInfo["t_sub"];
                v_fan = suitInfo["v_fan"];
                p_o2 = suitInfo["p_o2"];
                rate_o2 = suitInfo["rate_o2"];
                batteryPercent = suitInfo["batteryPercent"];
                battery_out = suitInfo["battery_out"];
                cap_battery = suitInfo["cap_battery"];
                t_battery = suitInfo["t_battery"];
                p_h2o_g = suitInfo["p_h2o_g"];
                p_h2o_l = suitInfo["p_h2o_l"];
                p_sop = suitInfo["p_sop"];
                rate_sop = suitInfo["rate_sop"];
                t_oxygenPrimary = suitInfo["t_oxygenPrimary"];
                t_oxygenSec = suitInfo["t_oxygenSec"];
                ox_primary = suitInfo["ox_primary"];
                ox_secondary = suitInfo["ox_secondary"];
                t_oxygen = suitInfo["t_oxygen"];
                cap_water = suitInfo["cap_water"];
                t_water = suitInfo["t_water"];
                __v = suitInfo["__v"];

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = time.ToString();
        heart_bpmText.text = heart_bpm.ToString();
       
        
    }
}
