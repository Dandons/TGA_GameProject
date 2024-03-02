using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationManager : Singleton<NotificationManager>
{
    public TMP_Text bottomLeft;
    public TMP_Text middle;

    public IEnumerator middleNoti(string notiText,float notiDuration){
        middle.text = notiText;
        yield return new WaitForSeconds(notiDuration);
        middle.text = "";
    }
    public IEnumerator bottomLeftNoti(string notiText,float notiDuration){
        bottomLeft.text = notiText;
        yield return new WaitForSeconds(notiDuration);
        bottomLeft.text = "";
    }
}
