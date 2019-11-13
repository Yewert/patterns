using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    internal class FirstOrmAdapter : IOrmAdapter
    {
        private readonly IFirstOrm<DbUserEntity> _users;
        private readonly IFirstOrm<DbUserInfoEntity> _userInfos;

        public FirstOrmAdapter(IFirstOrm<DbUserEntity> users, IFirstOrm<DbUserInfoEntity> userInfos)
        {
            _users = users;
            _userInfos = userInfos;
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = _users.Read(userId);
            var userInfo = _userInfos.Read(user.InfoId);
            return (user, userInfo);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _users.Add(user);
            _userInfos.Add(userInfo);
        }

        public void Remove(int userId)
        {
            var user = _users.Read(userId);
            var userInfo = _userInfos.Read(user.InfoId);

            _userInfos.Delete(userInfo);
            _users.Delete(user);
        }
    }
}