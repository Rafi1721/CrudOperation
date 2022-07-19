using CrudOperationProject.Model;

namespace CrudOperationProject.Repository.Interface

{
    public interface Ishopcakerepo
    {
       public List<ShopCake> GetCakes(string CName);
       public ShopCake GetCakesById(int Id);
       public int SaveCakes(ShopCake shopcake);
       public int Updatecakes(ShopCake shopcake);
       
    }
}
