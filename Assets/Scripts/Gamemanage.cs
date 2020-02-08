using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanage : MonoBehaviour
{
    public CardModule[] cards = null;
    public TimerModule timer = null;
    public ControllManager manager = null;
    public GameObject menu = null;

    public void Awake()
    {
        OnStart();
        
    }

    public void OnStart()
    {

        menu.SetActive(false);
        manager.OnStart();
        List<Color> colors = new List<Color>(cards.Length / 2);
        SetRandomColor(colors, cards.Length / 2);

        colors.AddRange(colors);
        Shuffle(colors, colors.Count);

        for (int i = 0; i < cards.Length; ++i)
        {
            cards[i].Reset();
            cards[i].CardColor = colors[i];
            cards[i].gameObject.SetActive(true);
        }

        timer.OnStart();
    }

    private void SetRandomColor(List<Color> list, int count)
    {
        if (count == 0) return;

        Color color = new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
            );

        //0, 1, 2
        //Exists -> 있는가?
        if (list.Exists(x => x.Equals(color))) SetRandomColor(list, count);
        else
        {
            list.Add(color);
            SetRandomColor(list, count - 1);
        }
    }
    //Fisher-Yates Shuffle 
    private void Shuffle(List<Color> list, int count)
    {
        while (count-- > 1)
        {
            int i = UnityEngine.Random.Range(0, count);

            Color col = list[i];
            list[i] = list[count];
            list[count] = col;
        }
    }

    public void OnTitle()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
