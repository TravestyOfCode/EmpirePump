using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemPaymentRet")]
public class Payment : Item
{
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    public string? ItemDesc { get; set; }
    [XmlElement("DepositToAccountRef")]
    public ListRef? DepositToAccount { get; set; }
    [XmlElement("PaymentMethodRef")]
    public ListRef? PaymentMethod { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

