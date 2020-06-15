using System;
using System.Collections.Generic;
using System.Text;

namespace Meys.Common.Dto
{
    /// <summary>
    /// When a user has been autheticated, this model is created and send back to the client
    /// </summary>
    public class UserDto
    {
        public string token { get; set; }
    }
}
