using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class OperationResult
    {
        public string Operation { get; set; }
        public DateTime OperationDate { get; set; }
        public bool Success { get; set; }
        public int RecordId { get; set; }
        public string Message { get; set; }

        public OperationResult(string operation,int recordId)
        {
            this.Operation = operation;
            this.OperationDate = DateTime.Now;
            this.Success = false;
            this.RecordId = recordId;
        }
        public OperationResult(string operation)
        {
            this.Operation = operation;
           
        }
        public OperationResult Failed(string message, int? recordId)
        {
            this.Message = message;
            this.Success = false;
            if (recordId != null)
            {
                this.RecordId = recordId.Value;
            }
            return this;
        }
        public OperationResult Succeed(string message, int? recordId)
        {
            this.Message = message;
            this.Success = true;
            if (recordId != null)
            {
                this.RecordId = recordId.Value;
            }
            return this;
        }
    }
}
