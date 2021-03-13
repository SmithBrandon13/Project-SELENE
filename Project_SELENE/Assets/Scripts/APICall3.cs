using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;


public class APICall3 : MonoBehaviour
{
    public TextMeshProUGUI heartText;
    public TextMeshProUGUI oxyText;
    public TextMeshProUGUI timeText;
    private string URL = "localhost:3000/api/simulation/state";

//parsing JSON data
    private string id = "";
    private string time = "";
    private string timer = "";
    private string started_at = "";
    private string heart_bpm = "";
    private string p_sub = "";
    private string p_suit = "";
    private string t_sub = "";
    private string v_fan = "";
    private string p_o2 = "";
    private string rate_o2 = "";
    private string batteryPercent = "";
    private string battery_out = "";
    private string cap_battery = "";
    private string t_battery = "";
    private string p_h2o_g = "";
    private string p_h2o_l = "";
    private string p_sop = "";
    private string rate_sop = "";
    private string t_oxygenPrimary = "";
    private string t_oxygenSec = "";
    private string ox_primary = "";
    private string ox_secondary = "";
    private string t_oxygen = "";
    private string cap_water = "";
    private string t_water = "";
    private string __v = "";

    // Start is called before the first frame update
    void Start()
    {
        //heartText.text = " ";
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
        heartText.text = heart_bpm;
        oxyText.text = t_oxygen;
        timeText.text = time;
       
        
    }
}
