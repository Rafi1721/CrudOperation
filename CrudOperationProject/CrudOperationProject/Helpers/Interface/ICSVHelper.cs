using CrudOperationProject.Model;
using CrudOperationProject.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;



namespace CrudOperationProject.Helpers.Interface
{
    public interface ICSVHelper
    {
        public byte[] GenerateCSV<T>(List<T> data, PropertyInfo[] properties);
    }
}


