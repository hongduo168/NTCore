using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTCore.WebFront.Model.Api
{
    public class AssignRoomGetInfo
    {
        /*RoomInfo*/
        public string RoomNumber { get; set; }
        public string PmsRoomNumber { get; set; }
        public string RoomTypeCode { get; set; }
        public string RoomStatus { get; set; }
        public decimal Coefficient { get; set; }
        public bool IsCleaning { get; set; }
        public bool IsChecked { get; set; }
        public bool IsDueOut { get; set; }
        public bool IsDueIn { get; set; }
        public bool IsRush { get; set; }
        public bool IsContradiction { get; set; }


        /*Assign*/
        public int UserId { get; set; }

        public DateTime AssignTime { get; set; }

        /*UserInfo*/
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string MobileNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public bool WorkReady { get; set; }
        public string Avatar { get; set; }
    }
}
