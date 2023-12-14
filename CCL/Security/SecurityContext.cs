using CCL.Security.Identity;

namespace CCL.Security
{
    public static class SecurityContext
    {
        static Employee _user = null;

        public static Employee GetUser()
        {
            return _user;
        }

        public static void SetUser(Employee user)
        {
            _user = user;
        }
    }
}