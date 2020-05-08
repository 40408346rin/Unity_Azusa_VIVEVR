using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   //引用 場景管理器 API
using Valve.VR.InteractionSystem;   //引用 VR 互動 API
public class GameManager : MonoBehaviour
{
    [Header("籃球數量")]
    public Text textBallCount;
    [Header("分數")]
    public Text textScore;
    [Header("兩分球音效")]
    public AudioClip soundTwo;
    [Header("三分球音效")]
    public AudioClip soundThree;

    private AudioSource aud;
    private int ballCount = 5;
    private int score;

    private ThreePoint threePoint;

    private void Start()
    {
        aud = GetComponent<AudioSource>();

        threePoint = FindObjectOfType<ThreePoint>();
    }


    public void UseBall(GameObject ball)
    {
        //刪除(球.取得元件<丟擲>())
        //刪除(球.取得元件<互動>())
        Destroy(ball.GetComponent<Throwable>());
        Destroy(ball.GetComponent<Interactable>());

        //數量遞減
        ballCount--;
        //更新文字
        textBallCount.text = "籃球數量:" + ballCount + " / 5";

    }

        private void OnTriggerEnter(Collider other)
    {
        if (threePoint.inThreePoint)
        {
            score += 3;
            aud.PlayOneShot(soundThree);
        }
        else
        {
            score += 2;
            aud.PlayOneShot(soundTwo);
        }
            //分數遞減2
            score += 2;
            //更新文字
            textScore.text = "分數:" + score;
    }

    public void Replay()
    {
        //場景管理器.載入場景("場景名稱")
        SceneManager.LoadScene("投籃");
    }

    public void Quit()
    {
        //應用程式.離開遊戲() - 適用於 PC.手機
        Application.Quit();
    }

}
