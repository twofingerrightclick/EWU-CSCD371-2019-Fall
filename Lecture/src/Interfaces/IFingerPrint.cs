using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IFingerPrint
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public void SetFingerPrintValues()
        {
            if (CreatedBy is null)
            {
                CreatedBy = 1; // <get current user id>
                CreatedOn = DateTime.UtcNow;
            }
            else
            {
                ModifiedBy = 1; // <get current user id>
                ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}
