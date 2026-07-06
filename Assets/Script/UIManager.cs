using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Process = System.Diagnostics.Process;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI conectingText;
    public TextMeshProUGUI warningtext1;
    public TextMeshProUGUI warningtext2;
    public TextMeshProUGUI wifiText;
    
    public Image image;
    public Color imageColor;

    private string dot;
    private float time;
    
    void Awake()
    {
        if(image != null)
        {
            imageColor = image.color;
        }
    }
    
    void Start()
    {
        if (conectingText != null)
        {
            conectingText.text = $"연결중{dot}";
        }
        if (wifiText != null)
        {
            wifiText.text = GetConnectedWifi();
        }

        time = 0;
    }

    void Update()
    {
        
        if (conectingText != null)
        {
            conectingText.text = $"연결중{dot}";
        }

        if (dot == "....")
        {
            dot = ".";
        }
        else if(time >= 0.5f)
        {
            dot += ".";
            time = 0;
        }

        time += Time.deltaTime;
    }
    // 바꿜때 마다 갱신되게 만들기
    
    public void noClickImage()
    {
        image.rectTransform.anchoredPosition = Vector2.Lerp(transform.position, new Vector2(1635, -390), 1);
        warningtext1.gameObject.SetActive(false);
        warningtext2.gameObject.SetActive(false);
    }

    public void isClickImage()
    {
        image.rectTransform.anchoredPosition = Vector2.Lerp(transform.position, new Vector2(950.42f, -384.37f), 1);
        warningtext1.gameObject.SetActive(true);
        warningtext2.gameObject.SetActive(true);
    }
    
    public void endClickImage()
    {
        image.rectTransform.anchoredPosition = Vector2.Lerp(transform.position, new Vector2(1635, -390), 1);
        warningtext1.gameObject.SetActive(false);
        warningtext2.gameObject.SetActive(false);
    }
    
    public string GetConnectedWifi()
    {
        Process process = new Process();

        process.StartInfo.FileName = "netsh";
        process.StartInfo.Arguments = "wlan show interfaces";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;

        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        foreach (string line in output.Split('\n'))
        {
            string trimmed = line.Trim();

            if (trimmed.StartsWith("SSID") && !trimmed.StartsWith("SSID BSSID"))
            {
                string[] parts = trimmed.Split(':');

                if (parts.Length > 1)
                    return parts[1].Trim();
            }
        }

        return "Chorm WIFI";
    }
}
