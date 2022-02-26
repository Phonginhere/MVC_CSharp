using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_EProject.Models.Request
{
    public class Group<K, T>
    {
        public K KeyRole;
        public K KeyProduct;
        public K KeyUnit;
        public K KeyQuantity;
        public K KeyPrice;
        public K KeyStatus;
        public K KeyPause;
        public K KeyNote;
        public IEnumerable<T> Values;
    }
}