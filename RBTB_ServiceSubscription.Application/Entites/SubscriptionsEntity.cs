using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Entites
{
    public class SubscriptionsEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public SubscriptionsType Type { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("UsersEntity")]
        public Guid IdUser { get; set; }
        public UsersEntity UsersEntity { get; set; }
    }

    public enum SubscriptionsType
    {
        FirstType,
        SecondType,
        ThirdType
            //Testing data
    }
}
