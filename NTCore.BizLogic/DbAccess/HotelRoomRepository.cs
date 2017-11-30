using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.DataModel;
using NTCore.Utility;
using System;
using System.Linq;
using System.Transactions;
using static NTCore.DataModel.DataEnum;

namespace NTCore.BizLogic.DbAccess
{
    public class HotelRoomRepository : DbRepository<HotelRoomInfo>
    {
        protected ILogger<HotelRoomRepository> logger;
        protected ActionRecordRepository action;
        public HotelRoomRepository(ILogger<HotelRoomRepository> logger, MainContext dbContext, ActionRecordRepository actionRecordRepository) : base(dbContext)
        {
            this.logger = logger;
            this.action = actionRecordRepository;
        }

        /// <summary>
        /// 设置赶房
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roomNumber"></param>
        /// <param name="doer"></param>
        /// <returns></returns>
        public bool SetRushRoom(int userId, string[] roomNumber, UserInfo doer)
        {
            if (roomNumber != null)
            {
                var rows = 0;
                var rooms = this.dbContext.HotelRoom.Where(x => x.HotelId == doer.HotelId && roomNumber.Contains(x.RoomNumber)).ToList();

                try
                {
                    using (var tran = new TransactionScope(TransactionScopeOption.Required, DataDefine.DefaultTransactionOptions))
                    {
                        foreach (var item in rooms)
                        {
                            item.IsRush = true;


                            #region 新增工作单

                            var model = new WorkloadInfo()
                            {
                                CheckTime = DataDefine.NullDateTime,
                                CheckUserId = 0,
                                Coefficient = item.Coefficient,
                                CreateTime = DateTime.Now,
                                CreatorId = doer.Id,
                                DataSort = 0,
                                DataState = EnumState.Normal,
                                ToStatus = item.RoomStatus,
                                FinishStatus = DataEnum.WorkFinishStatus.Created,
                                FinishTime = DataDefine.NullDateTime,
                                FromStatus = item.RoomStatus,
                                HotelId = doer.HotelId,
                                IsChecked = false,
                                MessageText = string.Empty,
                                ReceiverId = 0,
                                RoomNumber = item.RoomNumber,
                                StarTime = DataDefine.NullDateTime,
                                UpdaterId = 0,
                                UpdateTime = DataDefine.NullDateTime,
                                UserId = userId,
                                WorkType = DataEnum.WorkloadType.RushRoom,
                                RaletionId = item.Id,

                            };
                            this.dbContext.Workload.Add(model);

                            #endregion

                            rows += this.dbContext.SaveChanges();

                            #region 增加工作步骤
                            var step = new WorkloadStepInfo()
                            {
                                CreatorId = doer.Id,
                                CreateTime = DateTime.Now,
                                DataSort = 0,
                                DataState = EnumState.Normal,
                                HotelId = doer.HotelId,
                                UserId = doer.Id,
                                WorkloadId = model.Id, //TODO
                                StepType = DataEnum.WorkloadStepType.Created,
                                UpdaterId = 0,
                                UpdateTime = DataDefine.NullDateTime,
                            };
                            this.dbContext.WorkloadStep.Add(step);
                            #endregion
                        }

                        rows += this.dbContext.SaveChanges();
                        tran.Complete();
                    }
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
                    this.logger.LogError(ex, ex.Message);
                    rows = 0;
                }

                return (rows > 0);

            }

            return false;
        }

        /// <summary>
        /// 排房
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roomNumber"></param>
        /// <param name="doer"></param>
        /// <returns></returns>
        public bool AssignRoom(int userId, string[] roomNumber, UserInfo doer)
        {
            if (roomNumber == null) return false;

            int rows = 0;
            try
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required, DataDefine.DefaultTransactionOptions))
                {

                    foreach (var item in roomNumber)
                    {
                        #region 执行排房

                        var data = this.dbContext.AssignRoom.FirstOrDefault(x => x.RoomNumber == item && x.HotelId == doer.HotelId);
                        if (data == null)
                        {
                            data = new AssignRoomInfo()
                            {
                                AssignTime = DateTime.Now,
                                Coefficient = 1.0M,
                                CreateTime = DateTime.Now,
                                CreatorId = doer.Id,
                                DataState = EnumState.Normal,
                                HotelId = doer.HotelId,
                                RoomNumber = item,
                                RoomStatus = string.Empty, //TODO
                                UpdaterId = 0,
                                DataSort = 0,
                                UpdateTime = DataDefine.NullDateTime,
                                UserId = userId
                            };
                            this.dbContext.AssignRoom.Add(data);
                        }
                        else
                        {
                            data.UserId = userId;
                            //this.dbContext.AssignRoom.Update(data);
                        }

                        #endregion

                        #region 填充排房结束时间

                        var lastRecord = this.dbContext.AssignRoomHistory.FirstOrDefault(x => x.RoomNumber == item && x.HotelId == doer.HotelId && x.Deadline == DataDefine.NullDateTime);
                        if (lastRecord != null)
                        {
                            lastRecord.Deadline = DateTime.Now; ;
                            //this.dbContext.AssignRoomHistory.Update(lastRecord);
                        }

                        #endregion

                        #region 增加历史记录

                        var history = new AssignRoomHistoryInfo()
                        {
                            Coefficient = 1.0M,
                            CreateTime = DateTime.Now,
                            CreatorId = doer.Id,
                            DataState = EnumState.Normal,
                            HotelId = doer.HotelId,
                            RoomNumber = item,
                            UpdaterId = 0,
                            UpdateTime = DataDefine.NullDateTime,
                            UserId = userId,
                            DataSort = 0,
                            FromTime = DateTime.Now,
                            Deadline = DataDefine.NullDateTime
                        };
                        this.dbContext.AssignRoomHistory.Add(history);
                        tran.Complete();

                        #endregion
                    }

                    rows = this.dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                rows = 0;
            }
            return (rows > 0);



        }

        /// <summary>
        /// 开始打扫
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="doer"></param>
        /// <returns></returns>
        public bool SweepStart(string roomNumber, UserInfo doer)
        {
            var rows = 0;
            try
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required, DataDefine.DefaultTransactionOptions))
                {
                    var room = this.dbContext.HotelRoom.FirstOrDefault(x => x.HotelId == doer.HotelId && x.RoomNumber == roomNumber);
                    if (room != null && !room.IsCleaning)
                    {
                        room.IsCleaning = true;

                        var model = new DataModel.WorkloadInfo
                        {
                            CheckTime = DataDefine.NullDateTime,
                            CheckUserId = 0,
                            Coefficient = room.Coefficient,
                            CreateTime = DateTime.Now,
                            CreatorId = doer.Id,
                            ToStatus = string.Empty,
                            DataSort = 0,
                            DataState = EnumState.Normal,
                            FinishStatus = DataEnum.WorkFinishStatus.Start,
                            FinishTime = DataDefine.NullDateTime,
                            FromStatus = room.RoomStatus,
                            HotelId = doer.HotelId,
                            IsChecked = false,
                            MessageText = string.Empty,
                            RaletionId = room.Id,
                            ReceiverId = doer.Id,
                            RoomNumber = roomNumber,
                            StarTime = DateTime.Now,
                            UpdaterId = 0,
                            UpdateTime = DataDefine.NullDateTime,
                            UserId = doer.Id,
                            WorkSeconds = 0,
                            WorkType = DataEnum.WorkloadType.CleanRoom,
                        };
                        this.dbContext.Workload.Add(model);
                        rows += this.dbContext.SaveChanges();

                        #region 增加工作步骤
                        var step = new WorkloadStepInfo()
                        {
                            CreateTime = DateTime.Now,
                            CreatorId = doer.Id,
                            DataSort = 0,
                            DataState = EnumState.Normal,
                            HotelId = doer.HotelId,
                            StepType = DataEnum.WorkloadStepType.Created,
                            UpdaterId = 0,
                            UpdateTime = DataDefine.NullDateTime,
                            UserId = doer.Id,
                            WorkloadId = model.Id, //TODO 关联ID是否正确
                        };
                        this.dbContext.WorkloadStep.Add(step);
                        #endregion

                        rows += this.dbContext.SaveChanges();
                    }

                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                rows = 0;
            }
            return (rows > 0);
        }

        /// <summary>
        /// 打扫完成
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="status"></param>
        /// <param name="doer"></param>
        /// <returns></returns>
        public bool SweepFinsh(string roomNumber, UserInfo doer)
        {
            var rows = 0;
            try
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required, DataDefine.DefaultTransactionOptions))
                {
                    var room = this.dbContext.HotelRoom.FirstOrDefault(x => x.HotelId == doer.HotelId && x.RoomNumber == roomNumber);
                    if (room != null && room.IsCleaning)
                    {
                        room.IsCleaning = false;
                        var toStatus = room.RoomStatus.Replace("D", "C");


                        //根据房号查找正在打扫
                        var model = this.dbContext.Workload.FirstOrDefault(x => x.HotelId == doer.HotelId && x.RoomNumber == roomNumber && x.WorkType == DataEnum.WorkloadType.RushRoom && x.FinishStatus == DataEnum.WorkFinishStatus.Start);
                        if (model != null)
                        {
                            model.FinishStatus = DataEnum.WorkFinishStatus.Finsh;
                            model.FinishTime = DateTime.Now;
                            model.UpdateTime = DateTime.Now;
                            model.UpdaterId = doer.Id;
                            model.ToStatus = toStatus;
                            model.WorkSeconds += (int)DateTime.Now.Subtract(model.StarTime).TotalSeconds;
                        }

                        #region 增加工作步骤
                        var step = new WorkloadStepInfo()
                        {
                            CreateTime = DateTime.Now,
                            CreatorId = doer.Id,
                            DataSort = 0,
                            DataState = EnumState.Normal,
                            HotelId = doer.HotelId,
                            StepType = DataEnum.WorkloadStepType.Finsh,
                            UpdaterId = 0,
                            UpdateTime = DataDefine.NullDateTime,
                            UserId = doer.Id,
                            WorkloadId = model.Id, //TODO 关联ID是否正确
                        };
                        this.dbContext.WorkloadStep.Add(step);
                        #endregion


                    }
                    rows += this.dbContext.SaveChanges();
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                rows = 0;

            }
            return (rows > 0);
        }


        /// <summary>
        /// 取消打扫
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="doer"></param>
        /// <returns></returns>
        public bool SweepCancel(string roomNumber, UserInfo doer)
        {
            var rows = 0;
            try
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required, DataDefine.DefaultTransactionOptions))
                {
                    var room = this.dbContext.HotelRoom.FirstOrDefault(x => x.HotelId == doer.HotelId && x.RoomNumber == roomNumber);
                    if (room != null && room.IsCleaning)
                    {
                        room.IsCleaning = false;

                        //根据房号查找正在打扫
                        var model = this.dbContext.Workload.FirstOrDefault(x => x.HotelId == doer.HotelId && x.RoomNumber == roomNumber && x.WorkType == DataEnum.WorkloadType.RushRoom && x.FinishStatus == DataEnum.WorkFinishStatus.Start);
                        if (model != null)
                        {
                            model.FinishStatus = DataEnum.WorkFinishStatus.Cancel;
                            model.UpdateTime = DateTime.Now;
                            model.UpdaterId = doer.Id;
                            model.WorkSeconds += (int)DateTime.Now.Subtract(model.StarTime).TotalSeconds;
                        }

                        #region 增加工作步骤
                        var step = new WorkloadStepInfo()
                        {
                            CreateTime = DateTime.Now,
                            CreatorId = doer.Id,
                            DataSort = 0,
                            DataState = EnumState.Normal,
                            HotelId = doer.HotelId,
                            StepType = DataEnum.WorkloadStepType.Finsh,
                            UpdaterId = 0,
                            UpdateTime = DataDefine.NullDateTime,
                            UserId = doer.Id,
                            WorkloadId = model.Id, //TODO 关联ID是否正确
                        };
                        this.dbContext.WorkloadStep.Add(step);
                        #endregion


                    }
                    rows += this.dbContext.SaveChanges();
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                rows = 0;
            }
            return (rows > 0);
        }

        /// <summary>
        /// 设置大清房
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doer"></param>
        /// <returns></returns>
        public bool SetDeepClean(int id, UserInfo doer)
        {
            var rows = 0;
            try
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required, DataDefine.DefaultTransactionOptions))
                {
                    //根据房号查找正在打扫
                    var model = this.dbContext.Workload.FirstOrDefault(x => x.Id == id);

                    if (model != null && model.WorkType == WorkloadType.CleanRoom && (model.FinishStatus == WorkFinishStatus.Finsh || model.FinishStatus == WorkFinishStatus.Checked))
                    {
                        model.UpdateTime = DateTime.Now;
                        model.UpdaterId = doer.Id;
                        model.WorkType = WorkloadType.DeepClean;

                        //设置到检查的状态
                        model.FinishStatus = WorkFinishStatus.Finsh;


                        #region 增加工作步骤
                        var step = new WorkloadStepInfo()
                        {
                            CreateTime = DateTime.Now,
                            CreatorId = doer.Id,
                            DataSort = 0,
                            DataState = EnumState.Normal,
                            HotelId = doer.HotelId,
                            StepType = DataEnum.WorkloadStepType.Switch,
                            UpdaterId = 0,
                            UpdateTime = DataDefine.NullDateTime,
                            UserId = doer.Id,
                            WorkloadId = model.Id,
                        };
                        this.dbContext.WorkloadStep.Add(step);
                        #endregion
                    }

                    rows += this.dbContext.SaveChanges();
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                rows = 0;
            }
            return (rows > 0);
        }


        /// <summary>
        /// 设置普通打扫
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doer"></param>
        /// <returns></returns>
        public bool SetNormalClean(int id, UserInfo doer)
        {
            var rows = 0;
            try
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required, DataDefine.DefaultTransactionOptions))
                {
                    //根据房号查找正在打扫
                    var model = this.dbContext.Workload.FirstOrDefault(x => x.Id == id);

                    if (model != null && model.WorkType == WorkloadType.DeepClean && (model.FinishStatus == WorkFinishStatus.Finsh))
                    {
                        model.UpdateTime = DateTime.Now;
                        model.UpdaterId = doer.Id;
                        model.WorkType = WorkloadType.CleanRoom;

                        //设置到检查的状态
                        model.FinishStatus = WorkFinishStatus.Finsh;


                        #region 增加工作步骤
                        var step = new WorkloadStepInfo()
                        {
                            CreateTime = DateTime.Now,
                            CreatorId = doer.Id,
                            DataSort = 0,
                            DataState = EnumState.Normal,
                            HotelId = doer.HotelId,
                            StepType = DataEnum.WorkloadStepType.Switch,
                            UpdaterId = 0,
                            UpdateTime = DataDefine.NullDateTime,
                            UserId = doer.Id,
                            WorkloadId = model.Id,
                        };
                        this.dbContext.WorkloadStep.Add(step);
                        #endregion
                    }

                    rows += this.dbContext.SaveChanges();
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                rows = 0;

            }
            return (rows > 0);
        }

    }
}
