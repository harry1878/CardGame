using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanage : MonoBehaviour
{
    public CardModule[] cards = null;

    public void GameStart()
    {
        // List 조사해오기 
        //List<int> list;
        //list.Add, list.Remove, list.AddRange

        //Color? R, G, B, A 가 4개 들어가 있는 float 형 구조체 
        //List? Array?
        //뭔가 담을 때 사용한다
        //사용할때는 반드시 선언을 해주어야 한다

        int[] intArray = new int[10];//10칸 짜리 공간
        List<int> intList = new List<int>(); // 리스트 생성 

        intArray[0] = 1;
        intArray[1] = 2;
        // ...
        intArray[9] = 10;
        //반드시 마지막 값을 접근할 때는 해당크기의 -1 해줘야한다
        // 컴퓨터의 처음 숫자는 0이니깐 

        intList.Add(1);
        intList.Add(2);

        //intList.Add(a);
        intList[0] = 1;
        //OutOfIndex Error!


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

}
