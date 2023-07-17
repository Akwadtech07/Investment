﻿namespace New_folder.Models.Dtos
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }

    
}
