using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseWork.Domain.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        USER,
        ADMIN
    }
}
