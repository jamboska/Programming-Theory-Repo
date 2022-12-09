using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class CrossSymbol : Symbol
{
    // POLYMORPHISM
    public override string GetSymbolType()
    {
        return "cross";
    }
}
