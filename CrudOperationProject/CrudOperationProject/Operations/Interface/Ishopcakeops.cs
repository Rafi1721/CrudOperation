using System;
using System.Collections.Generic;
using CrudOperationProject.Model;

namespace CrudOperationProject.Operations.Interface
{
    public interface Ishopcakeops
    {

        public List<ShopCake> GetCakes();
        public ShopCake GetCakesById(int Id);
        public int SaveCakes(ShopCake shopcake);
        public int Updatecakes(ShopCake shopcake);
       // public byte[] Exportcakes(int id, string name);
     
    }
}
