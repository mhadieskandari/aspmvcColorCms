using System.Linq;

namespace CMS_Golbarg.Core.Models
{
    public class UserInfo
    {

        ApplicationDbContext db =new  ApplicationDbContext();

        public int GetCoins(string UserId)
        {
            int coins = 0;

            var _coins = db.PayCoins.Where(m => m.UserID == UserId).ToList();

            foreach (var item in _coins)
            {
                if (item.InOutType == PayCoin.PayInType)
                {
                    coins += item.NumberOfCoins;
                }
                else
                {
                    coins -= item.NumberOfCoins;
                }
            }
            return coins;

        }
        

    }
}