﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipSoGo.Models
{
    public class CommentsJson : IJson
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<Comment> comments { get; set; }
    }
}