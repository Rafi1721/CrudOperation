using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CrudOperationProject.Model;
using CrudOperationProject.Repository;
using CrudOperationProject.Helpers.Interface;



namespace CrudOperationProject.Helpers
{
    public class CSVHelper : ICSVHelper
    {
        public byte[] GenerateCSV<T>(List<T> data, PropertyInfo[] properties)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < properties.Length; i++)
            {
                sb.Append(properties[i].Name.ToString());
                sb.Append((i < properties.Length - 1) ? ',' : '\n');
            }
            foreach (var record in data)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    sb.Append(properties[i].GetValue(record));
                    sb.Append((i < properties.Length - 1) ? ',' : '\n');
                }
            }
            var buffer = Encoding.ASCII.GetBytes(sb.ToString());
            return buffer;
        }
    }
}

