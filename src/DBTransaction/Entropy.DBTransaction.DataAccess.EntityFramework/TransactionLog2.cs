﻿using System;
using System.Collections.Generic;

namespace Entropy.DBTransaction.DataAccess.EntityFramework
{
    public partial class TransactionLog2
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
