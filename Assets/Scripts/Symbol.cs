using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    // Return the name of the symbol type. Default - "notype".
    public virtual string GetSymbolType()
    {
        return "notype";
    }
}
