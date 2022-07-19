using CrudOperationProject.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using CrudOperationProject.Operations.Interface;
using CrudOperationProject.Repository.Interface;

namespace CrudOperationProject.Operations
{
    public class shopcakeOps : Ishopcakeops
    {
        private readonly Ishopcakerepo _shopcakeRepo;
        private readonly ILogger<shopcakeOps> _logger;
        private readonly Helpers.Interface.ICSVHelper _csvHelper;

        public shopcakeOps(Ishopcakerepo shopcakeRepo,
                                    ILogger<shopcakeOps> logger,
                                    Helpers.Interface.ICSVHelper csvHelper)
        {
            this._shopcakeRepo = shopcakeRepo;
            this._logger = logger;
            this._csvHelper = csvHelper;
        }

        public List<ShopCake> GetCakes()
        {
            return _shopcakeRepo.GetCakes();
        }

      /*  public byte[] Exportcakes(int id, string name)
        {
            var shopcake = GetCakes(id, name);
            return _csvHelper.GenerateCSV(shopcake, typeof(ShopCake).GetProperties());
        }*/

        public ShopCake GetCakesById(int Id)
        {
            return _shopcakeRepo.GetCakesById(Id);
        }

        public int SaveCakes(ShopCake shopcake)
        {
            return _shopcakeRepo.SaveCakes(shopcake);
        }

        public int Updatecakes(ShopCake shopcake)
        {
            return _shopcakeRepo.Updatecakes(shopcake);
        }
    }
}

