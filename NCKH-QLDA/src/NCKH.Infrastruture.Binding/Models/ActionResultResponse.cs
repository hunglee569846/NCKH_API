
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NCKH.Infrastruture.Binding.Models
{
    public class ActionResultResponese
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public long Code { get; set; }
        public ActionResultResponese() { }
        public ActionResultResponese(long code, string message = "", string title = "")
        {
            Code = code;
            Title = title;
            Message = message.ToString();
        }
    }
    public class ActionResultResponese<T> : ActionResultResponese
    {
        public T Data { get; set; }
        public ActionResultResponese()
        {
            Code = 1;
        }
        public ActionResultResponese(long code, string messge = "", string title = "", T data = default)
        {
            Code = code;
            Title = title;
            Message = messge.ToString();
            Data = data;
        }
        public ActionResultResponese(T data)
        {
            Code = 1;
            Data = data;
        }

    }
}
