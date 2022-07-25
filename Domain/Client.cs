using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain
{
    public class Client
    {
        public int ClientId { get; private set; }
        public int ClientNumber { get; private set; }
        public string Name { get; private set; }
        public Client(string name) {
            this.Name = name;
        }
    }
}
