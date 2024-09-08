using HotelProject.BussinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BussinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public int TAppUserCount()
        {
            return _appUserDal.AppUserCount();
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser TGetByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> TGetlist()
        {
            return _appUserDal.Getlist();
        }

        public void TInsert(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _appUserDal.Update(t);
        }

        public List<AppUser> TUserListWithWorkLocation()
        {
            return _appUserDal.UserListWithWorkLocation();
        }

        public List<AppUser> TUsersListWithWorkLocation()
        {
            return _appUserDal.UsersListWithWorkLocation();
        }
    }
}
