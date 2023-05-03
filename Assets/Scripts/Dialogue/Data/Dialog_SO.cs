using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogData", menuName = "Data/DialogData")]
public class Dialog_SO : ScriptableObject
{
    public List<string> dialog = new List<string>();
}
