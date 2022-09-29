using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace groups_backend.Models
{
    public class members
    {
        #region Properties
        [Key]
        public int mid { get; set; }
        public int mposition { get; set; }
        public string mFirstName { get; set; }
        public string mMiddleName { get; set; }
        public string mLastName { get; set; }
        public DateTime mDob { get; set; }
        public int mNationalId { get; set; }
        public int mPhoneNumber { get; set; }
        public string mEmail { get; set; }
        public DateTime mDofEntry { get; set; }
        public DateTime mDofExpiry { get; set; }
        public int mAddress { get; set; }
        public int status { get; set; }
        #endregion    
    }

}