using NTCore.BizLogic.PMSInterface.PMS;
using NTCore.BizLogic.PMSInterface.ResponseModel;
using NTCore.DataModel;
using NTCore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NTCore.BizLogic.PMSInterface
{
    public class PMSFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appoint">指定PMS类型</param>
        /// <returns></returns>
        public static IPMS GetInstance(HotelInfo hotel, PmsProductDefineInfo pms, Type appoint = null)
        {
            if (hotel == null) throw new ArgumentException("hotel is not find");

            if (pms == null) throw new ArgumentException("PMS Product is not define");

            var request = new RequestInfo()
            {
                HotelId = hotel.Id,
                AppSecret = pms.Appkey,
                HotelCode = hotel.HotelCode,
                PmsName = pms.ProductName,
                AppKey = pms.Appid,
                HostUrl = hotel.InterfaceUrl,
                Source = pms.Source
            };

            //从缓存提取
            IPMS result = null;

            if (appoint != null && appoint.GetInterfaces().Contains(typeof(IPMS)))
            {
                result = (IPMS)Activator.CreateInstance(appoint, request);
                return result;
            }

            switch (Assister.ConvertToEnum<PMSType>(request.PmsName))
            {
                case PMSType.XPMS:
                    result = new XPMS(request);
                    break;
                case PMSType.HPMS:
                case PMSType.HPMSPlus:
                case PMSType.PMSPlus:
                    result = new PMSPlus(request);
                    break;
                case PMSType.ClubMedPMS:
                    result = new ClubMed(request);
                    break;
                case PMSType.OperaPMS:
                case PMSType.Opera:
                    result = new Opera(request);
                    break;
                default:
                    break;
            }
            return result;
        }



        #region PMS类型
        public enum PMSType
        {
            [Description("XPMS")]
            XPMS = 10,

            [Description("PMS+")]
            PMSPlus = 20,

            [Description("HPMS")]
            HPMS = 21,

            [Description("HPMS+")]
            HPMSPlus = 22,

            [Description("ClubMedPMS")]
            ClubMedPMS = 40,


            [Description("OperaPMS")]
            OperaPMS = 50,
            [Description("Opera")]
            Opera = 51,
            [Description("OperaNet")]
            OperaNet = 55
        }

        #endregion
    }
}
