﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDto.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BlogId { get; set; }
    }
}
