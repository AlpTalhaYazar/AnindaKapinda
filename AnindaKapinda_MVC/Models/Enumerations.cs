using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public static class Enumerations
    {
        public enum OrderStatus
        {
            [Description("Preparing.")]
            Status0,
            [Description("Shipped")]
            Status1
        }
        public enum DeliveryStatus
        {
            [Description("The order has been delivered.")]
            Status0,
            [Description("Address is missing/incorrect")]
            Status1,
            [Description("The customer was not at the address.")]
            Status2                
        }
        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
