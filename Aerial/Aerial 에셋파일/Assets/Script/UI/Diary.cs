using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    /* 엑셀 쓰지말자,,^^
     * 일지 이름, 내용 받아야함 인식을위한 번호도 넣을가,,
     * 자기 번호가 없으면 추가, 있으면 무시해야함 
     * 딕셔너리 사용,,해보기 얘가 빠름 ㅎㅎ
     * 
     * 
     * string 이름, 내용 
     */

    Dictionary<int,string> DiaryID = new Dictionary<int, string>();

   void DiaryData()
    {
        /*
         * 아이디 호출이 들어오면 얘가,,ui에 추가 하는걸로? 그럼 얜 database아니냐
         * id [200]
         * string name:배고파
         * string content: 어쩌라고 
         * 여기 한번타고 ui 추가는 다른 함수로
         * 
         */
    }
    void addData()
    {
        /*
         * if 있는 아이디면 return
         * diaryID의 string 버튼 text 에 넣고 자체 생성, 
         * ui 내용에 자체 내용연동
         * institate
         */
    }
}
