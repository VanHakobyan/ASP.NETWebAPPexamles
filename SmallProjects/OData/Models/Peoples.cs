using System.Collections.Generic;

namespace OData.Models
{
    public class Peoples
    {
        public static List<People> p = new List<People>()
        {
            new People{Age=2,id=1,Name="bebe"},
            new People{Age=15,id=2,Name="Kaka"}
        };
        public static IEnumerable<People> GetAll()
        {
            return p;
        }
    }
}