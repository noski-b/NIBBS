﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using POSReversalNIBBSBackground.Domain.Enums;

namespace POSReversalNIBBSBackground.Domain
{
    public class UploadedExcelDetail
    {
        [Key]
        public Guid BatchId { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }
        public DateTime DateUploaded { get; set; }
        public double? TotalTransaction { get; set; }
        public double? TotalAmount { get; set; }

        public StatusEnum Status { get; set; }
    }
}
