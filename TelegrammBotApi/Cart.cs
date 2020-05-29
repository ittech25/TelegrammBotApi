using System.Linq;
using TelegrammBotApi.SQL;

namespace TelegrammBotApi
{
    public class Cart
    {
        string userName;
        /// <summary>Кол-во продуктов в корзине </summary>
        public int CountProductsToCart { get; private set; }
        public Cart(string UserName)
        {
            userName = UserName;

            var cartList = new RequestBd().GetProductsToCart(UserName);
            CountProductsToCart = cartList.Count();
        }
    }
}
