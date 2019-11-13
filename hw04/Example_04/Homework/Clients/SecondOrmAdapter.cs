using System.Linq;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    internal class SecondOrmAdapter : IOrmAdapter
    {
        private readonly ISecondOrm _secondOrm;

        public SecondOrmAdapter(ISecondOrm secondOrm)
        {
            _secondOrm = secondOrm;
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = _secondOrm.Context.Users.First(i => i.Id == userId);
            var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);
            return (user, userInfo);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _secondOrm.Context.Users.Add(user);
            _secondOrm.Context.UserInfos.Add(userInfo);
        }

        public void Remove(int userId)
        {
            _secondOrm.Context.Users.RemoveWhere(user => user.Id == userId);
            _secondOrm.Context.UserInfos.RemoveWhere(userInfo => userInfo.Id == userId);
        }
    }
}