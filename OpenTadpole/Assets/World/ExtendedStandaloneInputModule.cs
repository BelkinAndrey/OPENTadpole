using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ExtendedStandaloneInputModule : StandaloneInputModule
{
    public PointerEventData GetPointerEventData(int id /* -1 ЛКМ, -2 ПКМ */)
    {
        return GetLastPointerEventData(id);
    }

    public string GetNamePointerEvent() 
    {
        string a = ""; 

        var data = GetPointerEventData(-1);
        if (data == null) return a;
        if (data.pointerEnter != null) a = data.pointerEnter.name;

        return a;
    }
}
