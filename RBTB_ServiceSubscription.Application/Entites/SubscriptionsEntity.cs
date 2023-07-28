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

        public string GetSubscriptionTypeName =>
             this.Type switch
             {
                 SubscriptionsType.FirstType => "TestData1",
                 SubscriptionsType.SecondType => "TestData2",
                 SubscriptionsType.ThirdType => "TestData3",
                 _ => throw new NotImplementedException()
             };
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
