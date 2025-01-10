using APISample.Interface;
using APISample.Models;

namespace APISample.Sevices
{
    public class SUserDetails : IUserDetails
    {
        private readonly DatabaseContext Db;
        public SUserDetails(DatabaseContext Db)
        {
                this.Db = Db;
        }
        public UserDetails getUserDetails(UserDetails UD)
        {
            if(UD!= null)
            {
                UserDetails? ud = Db.SM_UserDetails_Mst.
                    FirstOrDefault(u => u.UserName == UD.UserName && u.Password==UD.Password);
                if ((ud != null))
                {
                    return ud;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
    }
}
