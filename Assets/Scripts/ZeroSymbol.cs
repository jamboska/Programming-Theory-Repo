using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class ZeroSymbol : Symbol
{
    // POLYMORPHISM
    public override string GetSymbolType()
    {
        return "zero";
    }
}
