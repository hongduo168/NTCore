using NTCore.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using NTCore.DataAccess;

namespace NTCore.BizLogic.DbAccess
{
    public class ActionRecordRepository : DbRepository<ActionRecordInfo>
    {
        public ActionRecordRepository(MainContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="doer"></param>
        /// <param name="message"></param>
        /// <param name="id"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        public int Logger(UserInfo doer, string message, int id, bool autoSave = true)
        {
            var model = new ActionRecordInfo
            {
                CreateTime = DateTime.Now,
                CreatorId = doer.Id,
                DataState = DataStateType.Normal,
                DataType = DataEnum.ActionRecordType.Request,
                SiteId = doer.SiteId,
                Text = message,
                TypeId = id,
                UpdaterId = doer.Id,
                UpdateTime = DateTime.Now
            };

            this.dbContext.ActionRecord.Add(model);
            if (autoSave)
            {
                return this.dbContext.SaveChanges();
            }
            return 0;
        }
    }
}
