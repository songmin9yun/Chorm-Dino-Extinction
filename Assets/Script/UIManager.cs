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
        Process process = new Process();                                          //프로세스는 컴퓨터에서 명령을 실행 할 수 있도록 하는 함수

        process.StartInfo.FileName = "netsh";                                     //netsh라는 파일명의 프로그램 실행          netsh는 Windows에 기본적으로 포함된 네트워크 관리 프로그램
        process.StartInfo.Arguments = "wlan show interfaces";                     //wlan은 무선 네트워크과련 함수를 실행, show는 보여주다, interfaces를
        process.StartInfo.UseShellExecute = false;                                //콘솔창 안보이게 하기
        process.StartInfo.RedirectStandardOutput = true;                          //CMD에 출력되는 글자를 코드에서 읽을 수 있게 합기
        process.StartInfo.CreateNoWindow = true;                                  //CMD창 안보이게 하기

        process.Start();                                                          //실행

        string output = process.StandardOutput.ReadToEnd();                       //실행한 결과를 문자열 output에 저장하기
        process.WaitForExit();                                                    //명령어가 끝날 때 까지 기다리기

        foreach (string line in output.Split('\n'))                              //라인별로 나누기                        //foreach는 배열이나 리스트 안에 있는 모든 데이터를 하나씩 꺼내는 반복문
        {
            string trimmed = line.Trim();                                        //Trim은 문자열 사이에 공백을 없앤다

            if (trimmed.StartsWith("SSID") && !trimmed.StartsWith("SSID BSSID"))
            {
                string[] parts = trimmed.Split(':');                             //:을 기준으로 자르기 

                if (parts.Length > 1)                                            //값이 있는지 확인
                    return parts[1].Trim();                                      //와이파이 이름 반환
            }
        }

        return "Chrome WIFI";                                                    //와이파이를 못 찾았을 때
    }
}
