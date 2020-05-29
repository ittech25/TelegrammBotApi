using TelegrammBotApi.SQL;

namespace TelegrammBotApi
{
    public class Cart
    {
        string userName;
        public Cart(string UserName)
        {
            userName = UserName;

            var cartList = new RequestBd().GetProductsToCart(UserName);

        }
    }
}
