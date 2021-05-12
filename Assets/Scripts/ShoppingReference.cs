using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ShoppingReference
{
    public string name = "New reference";
    public string qrCodePrefix = "unknown";

    public ShoppingReference()
    {

    }

    public ShoppingReference(string name, string qrCodePrefix) : this()
    {
        this.name = name;
        this.qrCodePrefix = qrCodePrefix;
    }
}
