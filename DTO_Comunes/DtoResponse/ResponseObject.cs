﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Comunes.DtoResponse
{
    public class ResponseObject
        
    {
        public ResponseObject()
        {
            HasError = false;
            MensajeError = String.Empty;
            Payload = null;
        }
    
        public object? Payload { get; set; } 
        public bool HasError { get; set; }
        public string MensajeError { get; set; }
        

    }
}
