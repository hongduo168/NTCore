﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTCore.WebFront.Model.Api
{
    public class AssignRoomPostInfo
    {
        public int UserId { get; set; }

        public string[] RoomNumber { get; set; }
    }
}