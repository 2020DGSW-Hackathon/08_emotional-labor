using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipSoGo.Models
{
    public class BulletinJson : Bulletin, IJson
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public BulletinJson(Bulletin b)
        {
            if (b == null)
            {
                return;
            }
            this.BulletinIdx = b.BulletinIdx;
            this.Title = b.Title;
            this.Contents = b.Contents;
            this.UserName = b.UserName;
            this.NumComments = b.NumComments;
            this.Topic = b.Topic;
            this.CreatedDate = b.CreatedDate;
        }
    }
}