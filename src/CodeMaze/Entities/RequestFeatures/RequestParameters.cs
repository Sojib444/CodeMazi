﻿namespace DataTransferObjects.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPagesixe = 50;
        public int pageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPagesixe ? maxPagesixe : value; }
        }

        public string Orderby { get; set; }
        public string? fields { get; set; }
    }
}
