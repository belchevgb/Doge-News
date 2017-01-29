﻿using System;
using System.Web.UI;

namespace DogeNews.Web.MVP.UserControls.NewsGrid.EventArguments
{
    public class ChangePageEventArgs : EventArgs
    {
        public int Page { get; set; }

        public StateBag ViewState { get; set; }
    }
}