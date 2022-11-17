using System;
using System.Xml.Serialization;


[XmlInclude(typeof(Pillow))]
[XmlInclude(typeof(Lamp))]
[XmlInclude(typeof(Bed))]
public abstract class Furniture
{
    public long id;

    protected Furniture() { }

    protected Furniture(long id)
    {
        this.id = id;
    }
}