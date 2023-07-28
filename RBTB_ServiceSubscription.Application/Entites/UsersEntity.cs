using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Entites
{
    public class UsersEntity
    {
        [Key]
        public Guid IdUser { get; set; } = Guid.NewGuid();
        public List<SubscriptionsEntity> SubscriptionsEntites { get; set; } = new();
    }
}
