using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace groups_backend.Models
{
    public class projects
    {
        #region Properties
        [Key]
        public int pId { get; set; }
        public string pName { get; set; }
        public string pDescription { get; set; }
        public DateTime pStartDate { get; set; }
        public int pBudget { get; set; }
        public string pStatus { get; set; }
        #endregion    
    }

}
