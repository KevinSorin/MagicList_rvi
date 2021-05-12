using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ShoppingReference
{
    public string name = "New reference";
    public string qrCodePrefix = "unknown";
    public string image = null;

    public ShoppingReference()
    {

    }

    public ShoppingReference(string name, string qrCodePrefix, string image) : this()
    {
        this.name = name;
        this.qrCodePrefix = qrCodePrefix;
        this.image = image;
    }
}
